using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Sweetener.Reflection
{
    internal static class RuntimeCast
    {
        private readonly static ConcurrentDictionary<(Type, Type), Func<object?, object?>> s_castCache = new ConcurrentDictionary<(Type, Type), Func<object?, object?>>();

        [return: NotNullIfNotNull("obj")]
        public static object? Perform(object? obj, Type source, Type dest)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (dest == null)
                throw new ArgumentNullException(nameof(dest));

            if (!s_castCache.TryGetValue((source, dest), out Func<object?, object?> castFunc))
            {
                // We don't perform any type checks here if the cast is valid
                if (source == dest)
                {
                    castFunc = x => x;
                }
                else if (source == typeof(object))
                {
                    ParameterExpression objParam = Expression.Parameter(typeof(object));
                    castFunc = Expression.Lambda<Func<object?, object?>>(Expression.Convert(objParam, dest).Box(), objParam).Compile();
                }
                else
                {
                    ParameterExpression objParam = Expression.Parameter(typeof(object));
                    castFunc = Expression.Lambda<Func<object?, object?>>(Expression.Convert(Expression.Convert(objParam, source), dest).Box(), objParam).Compile();
                }

                s_castCache.TryAdd((source, dest), castFunc);
            }

            return castFunc(obj);
        }
    }
}
