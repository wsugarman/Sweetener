using System.Linq.Expressions;

namespace Sweetener.Reflection
{
    internal static class ExpressionExtensions
    {
        internal static Expression Box(this Expression expression)
            => expression.Type.IsValueType ? Expression.Convert(expression, typeof(object)) : expression;
    }
}
