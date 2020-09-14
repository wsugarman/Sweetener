using System;
using System.Linq.Expressions;

namespace Sweetener.Reflection
{
    /// <summary>
    /// A collection of utilities related to binary operators.
    /// </summary>
    public static class BinaryOperation
    {
        /// <summary>
        /// The name of the addition operator.
        /// </summary>
        /// <remarks>
        /// The addition operator (<c>+</c> in C#) computes the sum of its operands.
        /// </remarks>
        public const string Addition = "op_Addition";

        /// <summary>
        /// The name of the subtraction operator.
        /// </summary>
        /// <remarks>
        /// The subtraction operator (<c>-</c> in C#) subtracts its right-hand operand from its left-hand operand.
        /// </remarks>
        public const string Subtraction = "op_Subtraction";

        /// <summary>
        /// The name of the multiplication operator.
        /// </summary>
        /// <remarks>
        /// The multiplication operator (<c>*</c> in C#) computes the product of its operands.
        /// </remarks>
        public const string Multiply = "op_Multiply";

        /// <summary>
        /// The name of the division operator.
        /// </summary>
        /// <remarks>
        /// The division operator (<c>/</c> in C#) divides its left-hand operand by its right-hand operand.
        /// </remarks>
        public const string Division = "op_Division";

        /// <summary>
        /// The name of the modulo operator (also known as the remainder operator).
        /// </summary>
        /// <remarks>
        /// The modulo operator (<c>%</c> in C#) computes the remainder after dividing its
        /// left-hand operand by its right-hand operand.
        /// </remarks>
        public const string Modulus = "op_Modulus";

        /// <summary>
        /// The name of the exclusive OR operator (also known as the XOR operator).
        /// </summary>
        /// <remarks>
        /// The exclusive OR operator (<c>^</c> in C#) produces <see langword="true"/>, if its left-hand operand
        /// evaluates to <see langword="true"/> and its right-hand operand evaluates to <see langword="false"/>,
        /// or its left-hand operand evaluates to <see langword="false"/> and its right-hand operand evaluates to
        /// <see langword="true"/>. Otherwise, the result is <see langword="false"/>.
        /// </remarks>
        public const string ExclusiveOr = "op_ExclusiveOr";

        /// <summary>
        /// The name of the bitwise AND operator.
        /// </summary>
        /// <remarks>
        /// The bitwise AND operator (<c>&amp;</c> in C#) compares each bit of its left-hand operand to the corresponding
        /// bit of its right-hand operand. If both bits are <c>1</c>, the corresponding result bit is set to 1. Otherwise,
        /// the corresponding result bit is set to <c>0</c>.
        /// </remarks>
        public const string BitwiseAnd = "op_BitwiseAnd";

        /// <summary>
        /// The name of the bitwise OR operator (also known as the bitwise inclusive OR operator).
        /// </summary>
        /// <remarks>
        /// The bitwise OR operator (<c>&amp;</c> in C#) compares each bit of its left-hand operand to the corresponding
        /// bit of its right-hand operand. If either bit is <c>1</c>, the corresponding result bit is set to 1. Otherwise,
        /// the corresponding result bit is set to 0.
        /// </remarks>
        public const string BitwiseOr = "op_BitwiseOr";

        /// <summary>
        /// The name of the logical AND operator.
        /// </summary>
        /// <remarks>
        /// The logical AND operator (<c>&amp;&amp;</c> in C#) produces <see langword="true"/> if both operands
        /// evaluate to <see langword="true"/> and returns <see langword="false"/> otherwise.
        /// </remarks>
        public const string LogicalAnd = "op_LogicalAnd";

        /// <summary>
        /// The name of the logical OR operator.
        /// </summary>
        /// <remarks>
        /// The logical OR operator (<c>||</c> in C#) produces <see langword="true"/> if either operand
        /// evaluates to <see langword="true"/> and returns <see langword="false"/> otherwise.
        /// </remarks>
        public const string LogicalOr = "op_LogicalOr";

        /// <summary>
        /// The name of the assignment operator.
        /// </summary>
        /// <remarks>
        /// The assignment operator (<c>=</c> in C#) assigns the value of its right-hand operand to the variable,
        /// property, or indexer element given by its left-hand operand. The assignment operator produces the value
        /// assigned to its left-hand operand.
        /// </remarks>
        public const string Assign = "op_Assign";

        /// <summary>
        /// The name of the left-shift operator.
        /// </summary>
        /// <remarks>
        /// The left-shift operator (<c>&lt;&lt;</c> in C#) shifts its left-hand operand left by the number of bits
        /// defined by its right-hand operand.
        /// </remarks>
        public const string LeftShift = "op_LeftShift";

        /// <summary>
        /// The name of the right-shift operator.
        /// </summary>
        /// <remarks>
        /// The right-shift operator (<c>&gt;&gt;</c> in C#) shifts its left-hand operand right by the number of bits
        /// defined by its right-hand operand.
        /// </remarks>
        public const string RightShift = "op_RightShift";

        /// <summary>
        /// The name of the signed right-shift operator.
        /// </summary>
        /// <remarks>
        /// The signed right-shift operator shifts its left-hand operand right by the number of bits
        /// defined by its right-hand operand. The high-order empty bit positions are set based on the sign
        /// of the left-hand operand.
        /// </remarks>
        public const string SignedRightShift = "op_SignedRightShift";

        /// <summary>
        /// The name of the unsigned right-shift operator.
        /// </summary>
        /// <remarks>
        /// The unsigned right-shift operator shifts its left-hand operand right by the number of bits
        /// defined by its right-hand operand. The high-order empty bit positions are always set to <c>0</c>.
        /// </remarks>
        public const string UnsignedRightShift = "op_UnsignedRightShift";

        /// <summary>
        /// The name of the equality operator.
        /// </summary>
        /// <remarks>
        /// The equality operator (<c>==</c> in C#) produces <see langword="true"/> if both of its operands are equal.
        /// Otherwise, it produces <see langword="false"/>.
        /// </remarks>
        public const string Equality = "op_Equality";

        /// <summary>
        /// The name of the greater than operator.
        /// </summary>
        /// <remarks>
        /// The greater than operator (<c>&gt;</c> in C#) produces <see langword="true"/> if its left-hand operand
        /// is greater than its right-hand operand. Otherwise, it produces <see langword="false"/>.
        /// </remarks>
        public const string GreaterThan = "op_GreaterThan";

        /// <summary>
        /// The name of the less than operator.
        /// </summary>
        /// <remarks>
        /// The less than operator (<c>&lt;</c> in C#) produces <see langword="true"/> if its left-hand operand
        /// is less than its right-hand operand. Otherwise, it produces <see langword="false"/>.
        /// </remarks>
        public const string LessThan = "op_LessThan";

        /// <summary>
        /// The name of the inequality operator.
        /// </summary>
        /// <remarks>
        /// The inequality operator (<c>!=</c> in C#) produces <see langword="true"/> if both of its operands are
        /// not equal. Otherwise it produces <see langword="false"/>.
        /// </remarks>
        public const string Inequality = "op_Inequality";

        /// <summary>
        /// The name of the greater than or equal operator.
        /// </summary>
        /// <remarks>
        /// The greater than or equal operator (<c>&gt;=</c> in C#) produces <see langword="true"/> if its left-hand
        /// operand is greater than or equal to its right-hand operand. Otherwise, it produces <see langword="false"/>.
        /// </remarks>
        public const string GreaterThanOrEqual = "op_GreaterThanOrEqual";

        /// <summary>
        /// The name of the less than or equal operator.
        /// </summary>
        /// <remarks>
        /// The less than or equal operator (<c>&lt;=</c> in C#) produces <see langword="true"/> if its left-hand
        /// operand is less than or equal to its right-hand operand. Otherwise, it produces <see langword="false"/>.
        /// </remarks>
        public const string LessThanOrEqual = "op_LessThanOrEqual";

        /// <summary>
        /// The name of the unsigned right-shift assignment operator.
        /// </summary>
        /// <remarks>
        /// The unsigned right-shift assignment operator is a compound assignment that performs an unsigned right-shift
        /// operation on the operands and assigns its result to the variable, property, or indexer element given by
        /// its left-hand operand.
        /// </remarks>
        public const string UnsignedRightShiftAssignment = "op_UnsignedRightShiftAssignment";

        /// <summary>
        /// The name of the member selection operator.
        /// </summary>
        /// <remarks>
        /// The member selection operator (<c>.</c> in C#) produces the value of a type or namespace member depending
        /// on its usage. This operator may also refer to pointer member access operator (<c>-&gt;</c> in C#) when its
        /// left-hand operand is of a pointer type.
        /// </remarks>
        public const string MemberSelection = "op_MemberSelection";

        /// <summary>
        /// The name of the right-shift assignment operator.
        /// </summary>
        /// <remarks>
        /// The right-shift assignment operator (<c>&gt;&gt;=</c> in C#) is a compound assignment that performs a
        /// right-shift operation on the operands and assigns its result to the variable, property, or indexer element
        /// given by its left-hand operand.
        /// </remarks>
        public const string RightShiftAssignment = "op_RightShiftAssignment";

        /// <summary>
        /// The name of the multiplication assignment operator.
        /// </summary>
        /// <remarks>
        /// The multiplication assignment operator (<c>*=</c> in C#) is a compound assignment that performs a
        /// multiplication operation on the operands and assigns its result to the variable, property, or indexer
        /// element given by its left-hand operand.
        /// </remarks>
        public const string MultiplicationAssignment = "op_MultiplicationAssignment";

        /// <summary>
        /// The name of the pointer-to-member operator.
        /// </summary>
        /// <remarks>
        /// The pointer-to-member operator (<c>-&gt;*</c> in C++) produces the value of the class member for the
        /// object specified in its left-hand operand whose name matches its right-hand operand. The right-hand
        /// operand must specify a member of the class.
        /// </remarks>
        public const string PointerToMemberSelection = "op_PointerToMemberSelection";

        /// <summary>
        /// The name of the subtraction assignment operator.
        /// </summary>
        /// <remarks>
        /// The subtraction assignment operator (<c>-=</c> in C#) is a compound assignment that performs a subtraction
        /// operation on the operands and assigns its result to the variable, property, or indexer element given
        /// by its left-hand operand.
        /// </remarks>
        public const string SubtractionAssignment = "op_SubtractionAssignment";

        /// <summary>
        /// The name of the exclusive OR assignment operator (also known as the XOR assignment operator).
        /// </summary>
        /// <remarks>
        /// The exclusive OR assignment operator (<c>^=</c> in C#) is a compound assignment that performs an
        /// exclusive OR operation on the operands and assigns its result to the variable, property, or indexer
        /// element given by its left-hand operand.
        /// </remarks>
        public const string ExclusiveOrAssignment = "op_ExclusiveOrAssignment";

        /// <summary>
        /// The name of the left-shift assignment operator.
        /// </summary>
        /// <remarks>
        /// The left-shift assignment operator (<c>&lt;&lt;=</c> in C#) is a compound assignment that performs a
        /// left-shift operation on the operands and assigns its result to the variable, property, or indexer
        /// element given by its left-hand operand.
        /// </remarks>
        public const string LeftShiftAssignment = "op_LeftShiftAssignment";

        /// <summary>
        /// The name of the modulo assignment operator.
        /// </summary>
        /// <remarks>
        /// The modulo assignment operator (<c>%=</c> in C#) is a compound assignment that performs a modulo
        /// operation on the operands and assigns its result to the variable, property, or indexer element given
        /// by its left-hand operand.
        /// </remarks>
        public const string ModulusAssignment = "op_ModulusAssignment";

        /// <summary>
        /// The name of the addition assignment operator.
        /// </summary>
        /// <remarks>
        /// The addition assignment operator (<c>+=</c> in C#) is a compound assignment that performs an addition
        /// operation on the operands and assigns its result to the variable, property, or indexer element given
        /// by its left-hand operand.
        /// </remarks>
        public const string AdditionAssignment = "op_AdditionAssignment";

        /// <summary>
        /// The name of the bitwise AND assignment operator.
        /// </summary>
        /// <remarks>
        /// The bitwise AND assignment operator (<c>&amp;=</c> in C#) is a compound assignment that performs a
        /// bitwise AND operation on the operands and assigns its result to the variable, property, or indexer
        /// element given by its left-hand operand.
        /// </remarks>
        public const string BitwiseAndAssignment = "op_BitwiseAndAssignment";

        /// <summary>
        /// The name of the bitwise OR assignment operator.
        /// </summary>
        /// <remarks>
        /// The bitwise OR assignment operator (<c>|=</c> in C#) is a compound assignment that performs a bitwise OR
        /// operation on the operands and assigns its result to the variable, property, or indexer element given
        /// by its left-hand operand.
        /// </remarks>
        public const string BitwiseOrAssignment = "op_BitwiseOrAssignment";

        /// <summary>
        /// The name of the comma operator.
        /// </summary>
        /// <remarks>
        /// The comma operator (<c>,</c> in C++) evaluates its left-hand operand, including all side effects, before
        /// evaluating its right-hand operand.
        /// </remarks>
        public const string Comma = "op_Comma";

        /// <summary>
        /// The name of the division assignment operator.
        /// </summary>
        /// <remarks>
        /// The division assignment operator (<c>/=</c> in C#) is a compound assignment that performs a division
        /// operation on the operands and assigns its result to the variable, property, or indexer element given
        /// by its left-hand operand.
        /// </remarks>
        public const string DivisionAssignment = "op_DivisionAssignment";

        /// <summary>
        /// Retrieves the special name for the binary operator overloading method.
        /// </summary>
        /// <param name="expressionType">An <see cref="ExpressionType"/> for a binary expression.</param>
        /// <returns>The binary operator's special name as defined by ECMA-335.</returns>
        public static string GetSpecialName(ExpressionType expressionType)
            => expressionType switch
            {
                ExpressionType.Add                   => Addition,
                ExpressionType.AddChecked            => Addition,
                ExpressionType.Subtract              => Subtraction,
                ExpressionType.SubtractChecked       => Subtraction,
                ExpressionType.Multiply              => Multiply,
                ExpressionType.MultiplyChecked       => Multiply,
                ExpressionType.Divide                => Division,
                ExpressionType.Modulo                => Modulus,
                ExpressionType.ExclusiveOr           => ExclusiveOr,
                ExpressionType.And                   => BitwiseAnd,
                ExpressionType.Or                    => BitwiseOr,
                ExpressionType.AndAlso               => LogicalAnd,
                ExpressionType.OrElse                => LogicalOr,
                ExpressionType.Assign                => Assign,
                ExpressionType.LeftShift             => LeftShift,
                ExpressionType.RightShift            => RightShift,
                ExpressionType.Equal                 => Equality,
                ExpressionType.GreaterThan           => GreaterThan,
                ExpressionType.LessThan              => LessThan,
                ExpressionType.NotEqual              => Inequality,
                ExpressionType.GreaterThanOrEqual    => GreaterThanOrEqual,
                ExpressionType.LessThanOrEqual       => LessThanOrEqual,
                ExpressionType.MemberAccess          => MemberSelection,
                ExpressionType.RightShiftAssign      => RightShiftAssignment,
                ExpressionType.MultiplyAssign        => MultiplicationAssignment,
                ExpressionType.MultiplyAssignChecked => MultiplicationAssignment,
                ExpressionType.SubtractAssign        => SubtractionAssignment,
                ExpressionType.SubtractAssignChecked => SubtractionAssignment,
                ExpressionType.ExclusiveOrAssign     => ExclusiveOrAssignment,
                ExpressionType.LeftShiftAssign       => LeftShiftAssignment,
                ExpressionType.ModuloAssign          => ModulusAssignment,
                ExpressionType.AddAssign             => AdditionAssignment,
                ExpressionType.AddAssignChecked      => AdditionAssignment,
                ExpressionType.AndAssign             => BitwiseAndAssignment,
                ExpressionType.OrAssign              => BitwiseOrAssignment,
                ExpressionType.DivideAssign          => DivisionAssignment,
                _                                    => throw new ArgumentOutOfRangeException(nameof(expressionType), expressionType, SR.UnrecognizedBinaryOperatorMessage),
            };
    }
}
