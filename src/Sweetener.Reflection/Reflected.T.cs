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

        private static readonly ConcurrentDictionary<string, Func<T, object?>>   s_getters = new ConcurrentDictionary<string, Func<T, object?>>();
        private static readonly ConcurrentDictionary<string, Action<T, object?>> s_setters = new ConcurrentDictionary<string, Action<T, object?>>();
        private static readonly ConcurrentDictionary<MethodInfo, Func<T, object[], object?>> s_memberInvokers = new ConcurrentDictionary<MethodInfo, Func<T, object[], object?>>();


        private static readonly MethodInfo[] s_allMethods = typeof(T).GetMethods(InstanceBindingFlags);
        private static readonly string[] s_allMembers = typeof(T).GetMembers(InstanceBindingFlags)
            .Select(x => x.Name)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        public Reflected(T value)
        {
            Target = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            if (binder == null)
            {
                throw new ArgumentNullException(nameof(binder));
            }

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
            {
                throw new ArgumentNullException(nameof(binder));
            }

            // First check cache for the setter
            if (!s_setters.TryGetValue(binder.Name, out Action<T, object?>? setter))
            {
                if (!TryCreateSetter(binder, out setter))
                    return false;

                s_setters.TryAdd(binder.Name, setter);
            }
            
            setter(Target, value);
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object? result)
        {
            if (binder == null)
            {
                throw new ArgumentNullException(nameof(binder));
            }

            if (!TryFindMethod(binder, args, out MethodInfo? methodInfo, out object?[]? formattedArgs))
            {
                result = default;
                return false;
            }

            // First check cache for the "invoker"
            if (!s_memberInvokers.TryGetValue(methodInfo, out Func<T, object[], object?>? memberInvoker))
            {
                memberInvoker = CreateMemberInvoker(methodInfo);
                s_memberInvokers.TryAdd(methodInfo, memberInvoker);
            }

            result = memberInvoker(Target, args);
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
            => s_allMembers;

        public override bool Equals(object? other)
            => Target.Equals(other);

        public override int GetHashCode()
            => Target.GetHashCode();

        public override string? ToString()
            => Target.ToString();

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

        private static bool TryCreateSetter(SetMemberBinder binder, [NotNullWhen(true)] out Action<T, object?>? setter)
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

                    setter = Expression.Lambda<Action<T, object?>>(body, targetParam, valueParam).Compile();
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

                    setter = Expression.Lambda<Action<T, object?>>(body, targetParam, valueParam).Compile();
                    return true;
                }
            }

            setter = default;
            return false;
        }

        private static Func<T, object[], object?> CreateMemberInvoker(MethodInfo methodInfo)
        {
            ParameterExpression targetParam = Expression.Parameter(typeof(T)       , "target");
            ParameterExpression argsParam   = Expression.Parameter(typeof(object[]), "args"  );

            MethodInfo indexMethod = typeof(object[]).GetMethod("Get");

            ParameterInfo[] parameterInfo = methodInfo.GetParameters();
            Expression[] input = new Expression[parameterInfo.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Expression getIthParameter = Expression.Call(argsParam, indexMethod, Expression.Constant(i));
                input[i] = parameterInfo[0].ParameterType == typeof(object)
                    ? getIthParameter
                    : Expression.Convert(getIthParameter, parameterInfo[0].ParameterType);
            }

            Expression body = methodInfo.ReturnType != typeof(void)
                ? Expression.Call(targetParam, methodInfo, input).Box()
                : Expression.Block(Expression.Call(targetParam, methodInfo, input), Expression.Constant(null));

            return Expression.Lambda<Func<T, object[], object?>>(body, targetParam, argsParam).Compile();
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

        private static bool TryFindMethod(InvokeMemberBinder binder, object?[] args, [NotNullWhen(true)] out MethodInfo? methodInfo, [NotNullWhen(true)] out object?[]? formattedArgs)
        {
            StringComparer stringComparer = binder.IgnoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
            int distinctArgNames = binder.CallInfo.ArgumentNames.Distinct(stringComparer).Count();

            if (binder.CallInfo.ArgumentNames.Count == distinctArgNames)
            {
                // Find all of the candidate methods with the same name and
                // refine the search based on the provided arguments and candidate signatures
                List<(MethodInfo Method, object?[] Args)> candidates = new List<(MethodInfo Method, object?[] Args)>();
                foreach (MethodInfo candidateMethodInfo in s_allMethods.Where(m => stringComparer.Equals(m.Name, binder.Name)))
                {
                    if (TryMapArgs(candidateMethodInfo, binder.CallInfo, args, stringComparer, out object?[]? candidateArgs))
                    {
                        candidates.Add((candidateMethodInfo, candidateArgs));
                    }
                }

                if (candidates.Count != 0)
                {
                    if (candidates.Count == 1)
                    {
                        methodInfo    = candidates[0].Method;
                        formattedArgs = candidates[0].Args;
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
                            if (match.Method.GetParameters().Length == binder.CallInfo.ArgumentCount)
                            {
                                if (exactMatch != null)
                                {
                                    throw new AmbiguousMatchException($"There are multiple methods with the name '{binder.Name}' for type {typeof(T)} that could match the method signature");
                                }

                                exactMatch = match;
                            }
                        }

                        if (exactMatch == null)
                        {
                            throw new AmbiguousMatchException($"There are {candidates.Count} methods with the name '{binder.Name}' for type {typeof(T)} that could match the method signature");
                        }

                        methodInfo    = exactMatch.GetValueOrDefault().Method;
                        formattedArgs = exactMatch.GetValueOrDefault().Args;
                        return true;
                    }
                }
            }

            methodInfo    = default;
            formattedArgs = default;
            return false;
        }

        private static bool TryMapArgs(MethodInfo method, CallInfo callInfo, object?[] args, StringComparer comparer, [NotNullWhen(true)] out object?[]? formattedArgs)
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
                        if (np == null || !TryMapArg(np, args[i + j], out object? formattedNamedArg))
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
                    if (!TryMapArg(p, args[i], out formattedArg))
                    {
                        formattedArgs = default;
                        return false;
                    }
                }
                else if (!TryMapArg(p, Optional<object?>.Undefined, out formattedArg))
                {
                    formattedArgs = default;
                    return false;
                }

                formattedArgs[i] = formattedArg;
            }

            return true;
        }

        private static bool TryMapArg(ParameterInfo parameter, Optional<object?> optionalArg, out object? formattedArg)
        {
            if (!optionalArg.TryGetValue(out object? arg))
            {
                if (parameter.HasDefaultValue)
                {
                    formattedArg = parameter.DefaultValue;
                    return true;
                }
            }
            else if (arg == null)
            {
                if (!parameter.ParameterType.IsValueType || (parameter.ParameterType.IsGenericType && parameter.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    formattedArg = null;
                    return true;
                }
            }
            else if (parameter.ParameterType.IsAssignableFrom(arg.GetType()))
            {
                formattedArg = arg;
                return true;
            }

            formattedArg = default;
            return false;
        }

        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Target property alternative is already defined")]
        public static explicit operator T(Reflected<T> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return value.Target;
        }

        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Constructor alternative is already defined")]
        public static implicit operator Reflected<T>(T value)
            => new Reflected<T>(value);
    }
}
