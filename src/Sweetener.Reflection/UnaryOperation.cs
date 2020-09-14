using System;
using System.Linq.Expressions;

namespace Sweetener.Reflection
{
    /// <summary>
    /// A collection of utilities related to unary operators.
    /// </summary>
    internal static class UnaryOperation
    {
        /// <summary>
        /// The name of the decrement operator.
        /// </summary>
        /// <remarks>
        /// The decrement operator (<c>--</c> in C#) decrements its operand by <c>1</c>.
        /// </remarks>
        public const string Decrement = "op_Decrement";

        /// <summary>
        /// The name of the increment operator.
        /// </summary>
        /// <remarks>
        /// The increment operator (<c>++</c> in C#) increments its operand by <c>1</c>.
        /// </remarks>
        public const string Increment = "op_Increment";

        /// <summary>
        /// The name of the unary negation operator (also known as the unary minus operator).
        /// </summary>
        /// <remarks>
        /// The unary negation operator (<c>-</c> in C#) computes the numeric negation of its operand.
        /// </remarks>
        public const string UnaryNegation = "op_UnaryNegation";

        /// <summary>
        /// The name of the unary plus operator.
        /// </summary>
        /// <remarks>
        /// The unary plus operator (<c>+</c> in C#) computes the numeric negation of its operand.
        /// </remarks>
        public const string UnaryPlus = "op_UnaryPlus";

        /// <summary>
        /// The name of the logical negation operator.
        /// </summary>
        /// <remarks>
        /// The logical negation operator (the prefix <c>!</c> in C#) produces <see langword="true"/>, if the operand
        /// evaluates to <see langword="false"/>, and <see langword="false"/>, if the operand evaluates to
        /// <see langword="true"/>.
        /// </remarks>
        public const string LogicalNot = "op_LogicalNot";

        /// <summary>
        /// The name of the true operator.
        /// </summary>
        /// <remarks>
        /// The unary true operator produces <see langword="true"/> if the operand evaluates to <see langword="true"/>;
        /// otherwise it produces <see langword="false"/>.
        /// </remarks>
        public const string True = "op_True";

        /// <summary>
        /// The name of the false operator.
        /// </summary>
        /// <remarks>
        /// The unary false operator produces <see langword="true"/> if the operand evaluates to <see langword="false"/>;
        /// otherwise it produces <see langword="false"/>.
        /// </remarks>
        public const string False = "op_False";

        /// <summary>
        /// The name of the address-of operator.
        /// </summary>
        /// <remarks>
        /// The address-of operator (<c>&amp;</c> in C#) returns the address of its operand.
        /// </remarks>
        public const string AddressOf = "op_AddressOf";

        /// <summary>
        /// The name of the one's complement operator (also known as the bitwise complement operator).
        /// </summary>
        /// <remarks>
        /// The one's complement operator (<c>~</c> in C#) reverses each bit of its operand.
        /// </remarks>
        public const string OnesComplement = "op_OnesComplement";

        /// <summary>
        /// The name of the pointer dereference operator (also known as the pointer indirection operator).
        /// </summary>
        /// <remarks>
        /// The pointer dereference operator (<c>*</c> in C#) obtains the variable to which its operand points.
        /// The operand must be of a pointer type.
        /// </remarks>
        public const string PointerDereference = "op_PointerDereference";

        /// <summary>
        /// Retrieves the special name for the unary operator overloading method.
        /// </summary>
        /// <param name="expressionType">An <see cref="ExpressionType"/> for a unary expression.</param>
        /// <returns>The unary operator's special name as defined by ECMA-335.</returns>
        public static string GetSpecialName(ExpressionType expressionType)
            => expressionType switch
            {
                ExpressionType.Decrement      => Decrement,
                ExpressionType.Increment      => Increment,
                ExpressionType.Negate         => UnaryNegation,
                ExpressionType.NegateChecked  => UnaryNegation,
                ExpressionType.UnaryPlus      => UnaryPlus,
                ExpressionType.Not            => LogicalNot,
                ExpressionType.OnesComplement => OnesComplement,
                _                             => throw new ArgumentOutOfRangeException(nameof(expressionType), expressionType, SR.UnrecognizedUnaryOperatorMessage),
            };
    }
}
