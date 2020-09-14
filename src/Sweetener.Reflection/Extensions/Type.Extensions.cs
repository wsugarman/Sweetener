using System;

namespace Sweetener.Reflection
{
    internal static class TypeExtensions
    {
        public static bool IsIntegralNumericType(this Type type)
            => type == typeof(sbyte )
            || type == typeof(byte  )
            || type == typeof(short )
            || type == typeof(ushort)
            || type == typeof(int   )
            || type == typeof(uint  )
            || type == typeof(long  )
            || type == typeof(ulong );
    }
}
