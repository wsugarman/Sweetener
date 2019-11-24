// Generated from ReliableAction.Create.tt
using System;

namespace Sweetener.Reliability
{
    partial class ReliableAction
    {
        /// <summary>
        /// Creates a new <see cref="ReliableAction{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/>
        /// that executes the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> at most a
        /// specific number of times based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the underlying delegate.</typeparam>
        /// <param name="action">The underlying action to invoke.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionPolicy">The policy that determines which errors are transient.</param>
        /// <param name="delayPolicy">The policy that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionPolicy" />, or <paramref name="delayPolicy" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            int maxRetries,
            ExceptionPolicy exceptionPolicy,
            DelayPolicy delayPolicy)
            => new ReliableAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, maxRetries, exceptionPolicy, delayPolicy);

        /// <summary>
        /// Creates a new <see cref="ReliableAction{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/>
        /// that executes the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> at most a
        /// specific number of times based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the underlying delegate.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the underlying delegate.</typeparam>
        /// <param name="action">The underlying action to invoke.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionPolicy">The policy that determines which errors are transient.</param>
        /// <param name="delayPolicy">The policy that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionPolicy" />, or <paramref name="delayPolicy" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            int maxRetries,
            ExceptionPolicy exceptionPolicy,
            ComplexDelayPolicy delayPolicy)
            => new ReliableAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, maxRetries, exceptionPolicy, delayPolicy);
    }
}
