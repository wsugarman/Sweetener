// Generated from AsyncAction.Extensions.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    static partial class AsyncActionExtensions
    {
        #region Func<T, Task>

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="action" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<T, Task> WithAsyncRetry<T>(this Func<T, Task> action, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithAsyncRetry(action, maxRetries, exceptionHandler, delayHandler.ToComplex());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="action" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<T, Task> WithAsyncRetry<T>(this Func<T, Task> action, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler delayHandler)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (maxRetries < Retries.Infinite)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));

            if (exceptionHandler == null)
                throw new ArgumentNullException(nameof(exceptionHandler));

            if (delayHandler == null)
                throw new ArgumentNullException(nameof(delayHandler));

            return async (arg) =>
            {
                Task t = null;
                int attempt = 0;

            Attempt:
                attempt++;

                try
                {
                    t = action(arg);
                    await t.ConfigureAwait(false);
                    return;
                }
                catch (Exception e)
                {
                    if (!exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    await Task.Delay(delayHandler(attempt, e)).ConfigureAwait(false);
                    goto Attempt;
                }
            };
        }

        #endregion

        #region Func<T, CancellationToken, Task>

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="action" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<T, CancellationToken, Task> WithAsyncRetry<T>(this Func<T, CancellationToken, Task> action, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithAsyncRetry(action, maxRetries, exceptionHandler, delayHandler.ToComplex());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="action" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<T, CancellationToken, Task> WithAsyncRetry<T>(this Func<T, CancellationToken, Task> action, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler delayHandler)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (maxRetries < Retries.Infinite)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));

            if (exceptionHandler == null)
                throw new ArgumentNullException(nameof(exceptionHandler));

            if (delayHandler == null)
                throw new ArgumentNullException(nameof(delayHandler));

            return async (arg, cancellationToken) =>
            {
                Task t = null;
                int attempt = 0;

            Attempt:
                attempt++;

                try
                {
                    t = action(arg, cancellationToken);
                    await t.ConfigureAwait(false);
                    return;
                }
                catch (Exception e)
                {
                    if (t.IsCanceled || !exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    await Task.Delay(delayHandler(attempt, e), cancellationToken).ConfigureAwait(false);
                    goto Attempt;
                }
            };
        }

        #endregion
    }
}
