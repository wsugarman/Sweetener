using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sweetener.Reflection
{
    internal class Reflected<T> : DynamicObject
    {
        [NotNull]
        public T Target { get; }

        private const BindingFlags InstanceBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private const BindingFlags StaticBindingFlags   = BindingFlags.Static   | BindingFlags.Public | BindingFlags.NonPublic;

        private static readonly ConcurrentDictionary<string, Func<T, object?>>                          s_getters          = new ConcurrentDictionary<string, Func<T, object?>>();
        private static readonly ConcurrentDictionary<string, (Action<T, object?>, Type)>                s_setters          = new ConcurrentDictionary<string, (Action<T, object?>, Type)>();
        private static readonly ConcurrentDictionary<MethodInfo, Func<T, object?[], object?>>           s_memberInvokers   = new ConcurrentDictionary<MethodInfo, Func<T, object?[], object?>>();
        private static readonly ConcurrentDictionary<Type, Func<T, object?>>                            s_converters       = new ConcurrentDictionary<Type, Func<T, object?>>();
        private static readonly ConcurrentDictionary<ExpressionType, Func<T, object?>>                  s_unaryOperations  = new ConcurrentDictionary<ExpressionType, Func<T, object?>>();
        private static readonly ConcurrentDictionary<(ExpressionType, Type), Func<T, object?, object?>> s_binaryOperations = new ConcurrentDictionary<(ExpressionType, Type), Func<T, object?, object?>>();

        private static readonly MethodInfo[] s_operatorOverloads   = GetOperatorMethodInfo();
        private static readonly MethodInfo[] s_allInstanceMethods = typeof(T).GetMethods(InstanceBindingFlags);
        private static readonly string[] s_allInstanceMembers     = typeof(T).GetMembers(InstanceBindingFlags)
            .Select(x => x.Name)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        public Reflected(T value)
            => Target = value ?? throw new ArgumentNullException(nameof(value));

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            // First check cache for the getter
            if (!s_getters.TryGetValue(binder.Name, out Func<T, object?>? getter))
            {
                if (!TryCreateGetter(binder, out getter))
                {
                    result = default;
                    return false;
                }

                s_getters.TryAdd(binder.Name, getter);
            }

            result = getter(Target);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            // First check cache for the setter
            (Action<T, object?> Setter, Type InputType) pair;
            if (!s_setters.TryGetValue(binder.Name, out pair))
            {
                if (!TryCreateSetter(binder, out Action<T, object?>? setter, out Type? setterType))
                    return false;

                pair = (setter, setterType);
                s_setters.TryAdd(binder.Name, pair);
            }

            // Check that we can cast the input to the appropriate type
            if (!TryMapValue(pair.InputType, value, out object? formattedValue))
                return false;

            pair.Setter(Target, formattedValue);
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[] args, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            return TryInvokeMember(new InvokeMemberMetadata(binder), args, out result);
        }

        public override bool TryConvert(ConvertBinder binder, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            // First check cache for the converter
            if (!s_converters.TryGetValue(binder.Type, out Func<T, object?> converter))
            {
                // Create a converter -- even if there is no way to actual perform this operation
                converter = CreateConverter(binder.Type);
                s_converters.TryAdd(binder.Type, converter);
            }

            result = converter(Target);
            return true;
        }

        public override bool TryUnaryOperation(UnaryOperationBinder binder, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            // First check cache for the unary operation
            if (!s_unaryOperations.TryGetValue(binder.Operation, out Func<T, object?>? operation))
            {
                if (!TryCreateUnaryOperation(binder.Operation, out operation))
                {
                    result = default;
                    return false;
                }

                s_unaryOperations.TryAdd(binder.Operation, operation);
            }

            result = operation(Target);
            return true;
        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object? arg, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            (ExpressionType, Type) key;
            object? formattedArg;

            // First, find the operation
            // Unfortunately, not all operations can be discovered via reflection with a MethodInfo object,
            // so we have to bifurcate the logic below (and in turn accommodate different ways to create the cached function)
            MethodInfo? binaryOperatorMethod = null;
            Expression<Func<T, object?, object?>>? lambdaExpr = null;
            if (arg != null && TryCreateBinaryExpression(binder.Operation, arg, out lambdaExpr, out formattedArg))
            {
                key = (binder.Operation, formattedArg.GetType());
            }
            else if (TryFindBinaryOperatorMethod(binder.Operation, arg, out binaryOperatorMethod, out formattedArg))
            {
                key = (binder.Operation, binaryOperatorMethod.GetParameters()[1].ParameterType);
            }
            else
            {
                result = default;
                return false;
            }

            // Like the other methods, first we'll check the cache
            if (!s_binaryOperations.TryGetValue(key, out Func<T, object?, object?>? operation))
            {
                operation = binaryOperatorMethod != null ? CreateBinaryOperation(binaryOperatorMethod) : lambdaExpr!.Compile();
                s_binaryOperations.TryAdd(key, operation);
            }

            result = operation(Target, formattedArg);
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object?[] args, out object? result)
        {
            if (binder == null)
                throw new ArgumentNullException(nameof(binder));

            if (typeof(T) != typeof(Delegate) && !typeof(T).IsSubclassOf(typeof(Delegate)))
            {
                result = default;
                return false;
            }

            return TryInvokeMember(new InvokeMemberMetadata(binder), args, out result);
        }

        public override bool TryCreateInstance(CreateInstanceBinder binder, object[] args, out object result)
            => throw new NotSupportedException();

        public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
            => throw new NotSupportedException();

        public override bool TryDeleteMember(DeleteMemberBinder binder)
            => throw new NotSupportedException();

        public override IEnumerable<string> GetDynamicMemberNames()
            => s_allInstanceMembers;

        public override bool Equals(object? other)
            => Target.Equals(other);

        public override int GetHashCode()
            => Target.GetHashCode();

        public override string? ToString()
            => Target.ToString();

        private bool TryInvokeMember(InvokeMemberMetadata metadata, object?[] args, out object? result)
        {
            if (!TryFindInstanceMethod(metadata, args, out MethodInfo? methodInfo, out object?[]? formattedArgs))
            {
                result = default;
                return false;
            }

            // First check cache for the "invoker"
            if (!s_memberInvokers.TryGetValue(methodInfo, out Func<T, object?[], object?>? memberInvoker))
            {
                memberInvoker = CreateMemberInvoker(methodInfo);
                s_memberInvokers.TryAdd(methodInfo, memberInvoker);
            }

            result = memberInvoker(Target, formattedArgs);
            return true;
        }

        private static bool TryCreateGetter(GetMemberBinder binder, [NotNullWhen(true)] out Func<T, object?>? getter)
        {
            if (TryFindPropertyOrField(binder.Name, binder.IgnoreCase, out MemberInfo? member))
            {
                // Create the getter
                if (member is FieldInfo fieldInfo)
                {
                    ParameterExpression inputParam = Expression.Parameter(typeof(T), "input");
                    getter = Expression.Lambda<Func<T, object?>>(Expression.Field(inputParam, fieldInfo).Box(), inputParam).Compile();
                    return true;
                }
                else if (member is PropertyInfo propertyInfo && propertyInfo.CanRead)
                {
                    ParameterExpression inputParam = Expression.Parameter(typeof(T), "input");
                    getter = Expression.Lambda<Func<T, object?>>(Expression.Property(inputParam, propertyInfo).Box(), inputParam).Compile();
                    return true;
                }
            }

            getter = default;
            return false;
        }

        private static bool TryCreateSetter(SetMemberBinder binder, [NotNullWhen(true)] out Action<T, object?>? setter, [NotNullWhen(true)] out Type? inputType)
        {
            if (TryFindPropertyOrField(binder.Name, binder.IgnoreCase, out MemberInfo? member))
            {
                // Create the setter
                if (member is FieldInfo fieldInfo && !fieldInfo.IsInitOnly && !fieldInfo.IsLiteral)
                {
                    ParameterExpression targetParam = Expression.Parameter(typeof(T)     , "target");
                    ParameterExpression valueParam  = Expression.Parameter(typeof(object), "value" );
                    Expression body = Expression.Assign(
                        Expression.Field(targetParam, fieldInfo),
                        fieldInfo.FieldType == typeof(object)
                            ? (Expression)valueParam
                            : Expression.Convert(valueParam, fieldInfo.FieldType));

                    setter    = Expression.Lambda<Action<T, object?>>(body, targetParam, valueParam).Compile();
                    inputType = fieldInfo.FieldType;
                    return true;
                }
                else if (member is PropertyInfo propertyInfo && propertyInfo.CanWrite)
                {
                    ParameterExpression targetParam = Expression.Parameter(typeof(T)     , "target");
                    ParameterExpression valueParam  = Expression.Parameter(typeof(object), "value" );
                    Expression body = Expression.Call(
                        targetParam,
                        propertyInfo.GetSetMethod(nonPublic: true),
                        propertyInfo.PropertyType == typeof(object)
                            ? (Expression)valueParam
                            : Expression.Convert(valueParam, propertyInfo.PropertyType));

                    setter    = Expression.Lambda<Action<T, object?>>(body, targetParam, valueParam).Compile();
                    inputType = propertyInfo.PropertyType;
                    return true;
                }
            }

            setter    = default;
            inputType = default;
            return false;
        }

        private static Func<T, object?> CreateConverter(Type targetType)
        {
            ParameterExpression inputParam = Expression.Parameter(typeof(T), "input");
            Expression body = targetType == typeof(T)
                ? (Expression)inputParam
                : Expression.Convert(inputParam, targetType);

            return Expression.Lambda<Func<T, object?>>(body, inputParam).Compile();
        }

        private static bool TryCreateUnaryOperation(ExpressionType unaryType, [NotNullWhen(true)] out Func<T, object?>? operation)
        {
            UnaryExpression unaryExpr;
            ParameterExpression inputParam = Expression.Parameter(typeof(T), "input");

            try
            {
                unaryExpr = Expression.MakeUnary(unaryType, inputParam, null);
            }
            catch (InvalidOperationException)
            {
                operation = default;
                return false;
            }

            operation = Expression.Lambda<Func<T, object?>>(unaryExpr, inputParam).Compile();
            return true;
        }

        private static Func<T, object?, object?> CreateBinaryOperation(MethodInfo binaryOperatorMethodInfo)
        {
            ParameterExpression leftParam  = Expression.Parameter(typeof(T)     , "left" );
            ParameterExpression rightParam = Expression.Parameter(typeof(object), "right");

            Type rightParamType = binaryOperatorMethodInfo.GetParameters()[1].ParameterType;
            Expression convertedRightParam = rightParamType == typeof(object) ? (Expression)rightParam : Expression.Convert(rightParam, rightParamType);
            return Expression.Lambda<Func<T, object?, object?>>(
                Expression.Call(null, binaryOperatorMethodInfo, leftParam, convertedRightParam).Box(),
                leftParam,
                rightParam).Compile();
        }

        private static Func<T, object?[], object?> CreateMemberInvoker(MethodInfo methodInfo)
        {
            ParameterExpression targetParam = Expression.Parameter(typeof(T)       , "target");
            ParameterExpression argsParam   = Expression.Parameter(typeof(object[]), "args"  );

            MethodInfo indexMethod = typeof(object[]).GetMethod("Get");

            ParameterInfo[] parameterInfo = methodInfo.GetParameters();
            Expression[] input = new Expression[parameterInfo.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Expression getIthParameter = Expression.Call(argsParam, indexMethod, Expression.Constant(i));
                input[i] = parameterInfo[i].ParameterType == typeof(object)
                    ? getIthParameter
                    : Expression.Convert(getIthParameter, parameterInfo[i].ParameterType);
            }

            Expression body = methodInfo.ReturnType != typeof(void)
                ? Expression.Call(targetParam, methodInfo, input).Box()
                : Expression.Block(Expression.Call(targetParam, methodInfo, input), Expression.Constant(null));

            return Expression.Lambda<Func<T, object?[], object?>>(body, targetParam, argsParam).Compile();
        }

        [ExcludeFromCodeCoverage] // TODO: How could amiguity happen?
        private static bool TryFindPropertyOrField(string name, bool ignoreCase, [NotNullWhen(true)] out MemberInfo? memberInfo)
        {
            const MemberTypes memberTypes = MemberTypes.Field | MemberTypes.Property; // TODO: include events?

            // Find the member
            StringComparison stringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            MemberInfo[] members = typeof(T).FindMembers(
                memberTypes,
                InstanceBindingFlags,
                (m, c) =>
                {
                    (string targetName, StringComparison targetComparison) = ((string, StringComparison))c;
                    return m.Name.Equals(targetName, targetComparison);
                },
                (name, stringComparison));

            if (members.Length > 1)
                throw new AmbiguousMatchException($"There are {members.Length} members with the name '{name}' for type {typeof(T)}");

            if (members.Length == 0)
            {
                memberInfo = default;
                return false;
            }

            memberInfo = members[0];
            return true;
        }

        private static bool TryFindInstanceMethod(InvokeMemberMetadata metadata, object?[] args, [NotNullWhen(true)] out MethodInfo? methodInfo, [NotNullWhen(true)] out object?[]? formattedArgs)
        {
            StringComparer stringComparer = metadata.IgnoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
            int distinctArgNames = metadata.CallInfo.ArgumentNames.Distinct(stringComparer).Count();

            if (metadata.CallInfo.ArgumentNames.Count == distinctArgNames)
            {
                // Find all of the candidate methods with the same name and
                // refine the search based on the provided arguments and candidate signatures
                List<(MethodInfo Method, object?[] Args)> candidates = new List<(MethodInfo Method, object?[] Args)>();
                foreach (MethodInfo candidateMethodInfo in s_allInstanceMethods.Where(m => stringComparer.Equals(m.Name, metadata.Name)))
                {
                    if (TryMapArguments(candidateMethodInfo, metadata.CallInfo, args, stringComparer, out object?[]? candidateArgs))
                    {
                        candidates.Add((candidateMethodInfo, candidateArgs));
                    }
                }

                if (candidates.Count != 0)
                {
                    if (candidates.Count == 1)
                    {
                        (methodInfo, formattedArgs) = candidates[0];
                        return true;
                    }
                    else
                    {
                        // If we're here, it means there is potential ambiguity
                        // So we'll try to pick the method whose signature matches the call pattern exactly
                        // However, if we are unable to find an exact match, it must mean there is > 1 equally plausible methods
                        (MethodInfo Method, object?[] Args)? exactMatch = null;
                        foreach ((MethodInfo Method, object?[] Args) match in candidates)
                        {
                            if (match.Method.GetParameters().Length == metadata.CallInfo.ArgumentCount)
                            {
                                if (exactMatch != null)
                                {
                                    throw new AmbiguousMatchException($"There are multiple methods with the name '{metadata.Name}' for type {typeof(T)} that could match the method signature");
                                }

                                exactMatch = match;
                            }
                        }

                        if (exactMatch == null)
                        {
                            throw new AmbiguousMatchException($"There are {candidates.Count} methods with the name '{metadata.Name}' for type {typeof(T)} that could match the method signature");
                        }

                        (methodInfo, formattedArgs) = exactMatch.GetValueOrDefault();
                        return true;
                    }
                }
            }

            methodInfo    = default;
            formattedArgs = default;
            return false;
        }

        private static bool TryCreateBinaryExpression(ExpressionType binaryType, object value, [NotNullWhen(true)] out Expression<Func<T, object?, object?>>? lambdaExpr, [NotNullWhen(true)] out object? formattedArg)
        {
            BinaryExpression binaryExpr;
            ParameterExpression leftParam  = Expression.Parameter(typeof(T)     , "left" );
            ParameterExpression rightParam = Expression.Parameter(typeof(object), "right");

            Type rightType = GetBinaryOperatorArgType(binaryType, typeof(T), value.GetType());
            Expression convertedRightParam = rightType == typeof(object) ? (Expression)rightParam : Expression.Convert(rightParam, rightType);
            try
            {
                binaryExpr = Expression.MakeBinary(binaryType, leftParam, convertedRightParam);
            }
            catch (InvalidOperationException)
            {
                lambdaExpr   = default;
                formattedArg = default;
                return false;
            }

            // Even though BinaryExpression has a Method property, it may be null!
            lambdaExpr   = Expression.Lambda<Func<T, object?, object?>>(binaryExpr.Box(), leftParam, rightParam);
            formattedArg = MapValue(binaryExpr.Right.Type, value);
            return true;
        }

        private static bool TryFindBinaryOperatorMethod(ExpressionType binaryType, object? arg, [NotNullWhen(true)] out MethodInfo? methodInfo, out object? formattedArg)
        {
            // Find all of the candidate methods with the same name where the argument would be valid
            List<(MethodInfo Method, object? Arg)> candidates = new List<(MethodInfo Method, object? Arg)>();
            string specialName = BinaryOperation.GetSpecialName(binaryType);
            foreach (MethodInfo candidateMethodInfo in s_operatorOverloads.Where(m => m.Name.Equals(specialName, StringComparison.Ordinal)))
            {
                if (TryMapArgument(candidateMethodInfo.GetParameters()[1], arg, out object? candidateArg))
                {
                    candidates.Add((candidateMethodInfo, candidateArg));
                }
            }

            if (candidates.Count == 1)
            {
                (methodInfo, formattedArg) = candidates[0];
                return true;
            }

            methodInfo   = default;
            formattedArg = default;
            return false;
        }

        private static bool TryMapArguments(MethodInfo method, CallInfo callInfo, object?[] args, StringComparer comparer, [NotNullWhen(true)] out object?[]? formattedArgs)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (args.Length > parameters.Length)
            {
                formattedArgs = default;
                return false;
            }

            formattedArgs = parameters.Length == 0 ? Array.Empty<object?>() : new object?[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo p = parameters[i];

                // Do we need to shuffle some arguments around?
                // Note: Compilers should protect us from encountering this case twice
                if (callInfo.ArgumentNames.Contains(p.Name, comparer))
                {
                    for (int j = 0; j < callInfo.ArgumentNames.Count; j++)
                    {
                        (ParameterInfo? np, int k) = parameters.Select((x, i) => (Parameter: x, Index: i)).FirstOrDefault(t => comparer.Equals(t.Parameter.Name, callInfo.ArgumentNames[j]));
                        if (np == null || !TryMapArgument(np, args[i + j], out object? formattedNamedArg))
                        {
                            formattedArgs = default;
                            return false;
                        }

                        formattedArgs[k] = formattedNamedArg;
                    }

                    return true;
                }

                // Otherwise try to map the arguments in order
                object? formattedArg;
                if (i < args.Length)
                {
                    if (!TryMapArgument(p, args[i], out formattedArg))
                    {
                        formattedArgs = default;
                        return false;
                    }
                }
                else if (!TryMapArgument(p, Optional<object?>.Undefined, out formattedArg))
                {
                    formattedArgs = default;
                    return false;
                }

                formattedArgs[i] = formattedArg;
            }

            return true;
        }

        private static bool TryMapArgument(ParameterInfo parameter, Optional<object?> optionalValue, out object? formattedValue)
        {
            if (!optionalValue.TryGetValue(out object? arg))
            {
                if (parameter.HasDefaultValue)
                {
                    formattedValue = parameter.DefaultValue;
                    return true;
                }
            }

            return TryMapValue(parameter.ParameterType, arg, out formattedValue);
        }

        private static bool TryMapValue(Type parameterType, object? value, out object? formattedValue)
        {
            if (value == null)
            {
                if (!parameterType.IsValueType || (parameterType.IsGenericType && parameterType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    formattedValue = null;
                    return true;
                }
            }
            else if (parameterType.IsAssignableFrom(value.GetType()))
            {
                formattedValue = MapValue(parameterType, value);
                return true;
            }

            formattedValue = default;
            return false;
        }

        private static object MapValue(Type type, object arg)
        {
            // Note: if we receive a type is that usually convertable to another, we'll need to first cast it to its
            // original type (as opposed to object) before casting to its intended type
            Type argType = arg.GetType();
            return argType == typeof(object) || argType == type || argType.IsSubclassOf(type) || (type.IsInterface && argType.GetInterfaces().Contains(type))
                ? arg
                : RuntimeCast.Perform(arg, argType, type);
        }

        private static Type GetBinaryOperatorArgType(ExpressionType binaryType, Type left, Type right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            // Be on the look out for Nullable<T>
            Type adjustedLeft = left.IsValueType && left.IsGenericType && left.GetGenericTypeDefinition() == typeof(Nullable<>)
                ? left.GetGenericArguments()[0]
                : left;

            // The integral numeric types and boolean do not expose their operators as methods through reflection,
            // so cannot discover their operators via name and checking the arguments. Instead, we have to
            // special-case the various operators on these operators
            switch (binaryType)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.Assign:
                case ExpressionType.Equal:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.SubtractAssign:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.ModuloAssign:
                case ExpressionType.AddAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.DivideAssign:
                    if (right != left && adjustedLeft.IsIntegralNumericType() && adjustedLeft.IsAssignableFrom(right))
                        return left;
                    break;
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                    if (right != left && adjustedLeft == typeof(bool) && adjustedLeft.IsAssignableFrom(right))
                        return left;
                    break;
                case ExpressionType.ExclusiveOr:
                case ExpressionType.And:
                case ExpressionType.Or:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.AndAssign:
                case ExpressionType.OrAssign:
                    if (right != left && (adjustedLeft.IsIntegralNumericType() || adjustedLeft == typeof(bool)) && adjustedLeft.IsAssignableFrom(right))
                        return left;
                    break;
                case ExpressionType.LeftShift:
                case ExpressionType.RightShift:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.LeftShiftAssign:
                    if (right != typeof(int) && adjustedLeft.IsIntegralNumericType() && typeof(int).IsAssignableFrom(right))
                        return typeof(int);
                    break;
            }

            return right;
        }

        private static MethodInfo[] GetOperatorMethodInfo()
        {
            IEnumerable<MethodInfo> staticMethods = typeof(T).GetMethods(StaticBindingFlags);
            if (typeof(T).IsValueType && typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
                staticMethods = staticMethods.Concat(typeof(T).GetGenericArguments()[0].GetMethods(StaticBindingFlags));

            return staticMethods.Where(x => x.IsSpecialName).ToArray();
        }

        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Target property alternative is already defined")]
        public static explicit operator T(Reflected<T> value)
            => value != null ? value.Target : throw new ArgumentNullException(nameof(value));

        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Constructor alternative is already defined")]
        public static implicit operator Reflected<T>(T value)
            => new Reflected<T>(value);

        private sealed class InvokeMemberMetadata
        {
            public string Name { get; }

            public bool IgnoreCase { get; }

            public CallInfo CallInfo { get; }

            public InvokeMemberMetadata(InvokeMemberBinder binder)
            {
                Name       = binder.Name;
                IgnoreCase = binder.IgnoreCase;
                CallInfo   = binder.CallInfo;
            }

            public InvokeMemberMetadata(InvokeBinder binder)
            {
                Name       = nameof(Action.Invoke);
                IgnoreCase = true;
                CallInfo   = binder.CallInfo;
            }
        }
    }
}
