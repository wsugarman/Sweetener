// Generated from Func.Extensions.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    /// <summary>
    /// A collection of methods to reliablty invoke user-defined functions.
    /// </summary>
    public static partial class FuncExtensions
    {
        #region Func<TResult>

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<TResult> WithRetry<TResult>(this Func<TResult> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<TResult> WithRetry<TResult>(this Func<TResult> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            => WithRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<TResult> WithRetry<TResult>(
            this Func<TResult> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => WithRetry(func, maxRetries, resultHandler, exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<TResult> WithRetry<TResult>(
            this Func<TResult> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (maxRetries < Retries.Infinite)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));

            if (resultHandler == null)
                throw new ArgumentNullException(nameof(resultHandler));

            if (exceptionHandler == null)
                throw new ArgumentNullException(nameof(exceptionHandler));

            if (delayHandler == null)
                throw new ArgumentNullException(nameof(delayHandler));

            return () =>
            {
                TResult result;
                int attempt = 0;

            Attempt:
                attempt++;

                try
                {
                    result = func();
                }
                catch (Exception e)
                {
                    if (!exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    Task.Delay(delayHandler(attempt, default, e)).Wait();
                    goto Attempt;
                }

                ResultKind kind = resultHandler(result);
                if (kind != ResultKind.Transient || (maxRetries != Retries.Infinite && attempt > maxRetries))
                    return result;

                Task.Delay(delayHandler(attempt, result, default)).Wait();
                goto Attempt;
            };
        }

        #endregion

        #region Func<CancellationToken, TResult>

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<CancellationToken, TResult> WithRetry<TResult>(this Func<CancellationToken, TResult> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<CancellationToken, TResult> WithRetry<TResult>(this Func<CancellationToken, TResult> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            => WithRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<CancellationToken, TResult> WithRetry<TResult>(
            this Func<CancellationToken, TResult> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => WithRetry(func, maxRetries, resultHandler, exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static Func<CancellationToken, TResult> WithRetry<TResult>(
            this Func<CancellationToken, TResult> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (maxRetries < Retries.Infinite)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));

            if (resultHandler == null)
                throw new ArgumentNullException(nameof(resultHandler));

            if (exceptionHandler == null)
                throw new ArgumentNullException(nameof(exceptionHandler));

            if (delayHandler == null)
                throw new ArgumentNullException(nameof(delayHandler));

            return (cancellationToken) =>
            {
                // Check for cancellation before invoking
                cancellationToken.ThrowIfCancellationRequested();

                TResult result;
                int attempt = 0;

            Attempt:
                attempt++;

                try
                {
                    result = func(cancellationToken);
                }
                catch (Exception e)
                {
                    if (e.IsCancellation(cancellationToken) || !exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    Task.Delay(delayHandler(attempt, default, e), cancellationToken).Wait(cancellationToken);
                    goto Attempt;
                }

                ResultKind kind = resultHandler(result);
                if (kind != ResultKind.Transient || (maxRetries != Retries.Infinite && attempt > maxRetries))
                    return result;

                Task.Delay(delayHandler(attempt, result, default), cancellationToken).Wait(cancellationToken);
                goto Attempt;
            };
        }

        #endregion
    }
}
