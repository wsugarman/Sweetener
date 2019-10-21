// Generated from Action.Extensions.tt
using System;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    static partial class ActionExtensions
    {
        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="action" />
        /// that will retry the operation based on the provided policies.
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
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, int maxRetries, ExceptionPolicy exceptionPolicy, DelayPolicy delayPolicy)
            => WithRetry(action, maxRetries, exceptionPolicy, (i, e) => delayPolicy(i));

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="action" />
        /// that will retry the operation based on the provided policies.
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
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, int maxRetries, ExceptionPolicy exceptionPolicy, ComplexDelayPolicy delayPolicy)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (maxRetries < Retries.Infinite)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));

            if (exceptionPolicy == null)
                throw new ArgumentNullException(nameof(exceptionPolicy));

            if (delayPolicy == null)
                throw new ArgumentNullException(nameof(delayPolicy));

            return (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
            {
                int attempt = 0;

            Attempt:
                attempt++;
                try
                {
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
                catch (Exception e)
                {
                    if (!exceptionPolicy(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw e;

                    Task.Delay(delayPolicy(attempt, e)).Wait();
                    goto Attempt;
                }
            };
        }
    }
}
