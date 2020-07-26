using System;
using System.Collections.Generic;

namespace Sweetener.Reflection
{
    internal static class ListExtensions
    {
        public static int IndexOf<TSource>(this IList<TSource> source, TSource value, IEqualityComparer<TSource> equalityComparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (equalityComparer == null)
                throw new ArgumentNullException(nameof(equalityComparer));

            for (int i = 0; i < source.Count; i++)
            {
                if (equalityComparer.Equals(source[i], value))
                    return i;
            }

            return -1;
        }
    }
}
