// Generated from AsyncFunc.Extensions.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    static partial class AsyncFuncExtensions
    {
        #region Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>>

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithAsyncRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            => WithAsyncRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => WithAsyncRetry(func, maxRetries, resultHandler, exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func,
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

            return async (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) =>
            {
                Task<TResult>? t;
                int attempt = 0;

            Attempt:
                t = null;
                attempt++;

                try
                {
                    t = func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    if (t == null)
                        goto Invalid;

                    await t.ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    if (!exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    await Task.Delay(delayHandler(attempt, default, e)).ConfigureAwait(false);
                    goto Attempt;
                }

                TResult result = t.Result;
                ResultKind kind = resultHandler(result);
                if (kind != ResultKind.Transient || (maxRetries != Retries.Infinite && attempt > maxRetries))
                    return result;

                await Task.Delay(delayHandler(attempt, result, default)).ConfigureAwait(false);
                goto Attempt;

            Invalid:
                throw new InvalidOperationException(SR.InvalidTaskResult);
            };
        }

        #endregion

        #region Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>>

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            => WithAsyncRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            => WithAsyncRetry(func, maxRetries, ResultPolicy.Default<TResult>(), exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => WithAsyncRetry(func, maxRetries, resultHandler, exceptionHandler, delayHandler.ToComplex<TResult>());

        /// <summary>
        /// Creates a reliable wrapper around the given asynchronous <paramref name="func" />
        /// that will retry the operation based on the provided policies.
        /// </summary>
        /// <remarks>
        /// The resulting function will throw <see cref="InvalidOperationException"/> if the given
        /// <paramref name="func"/> returns <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </remarks>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> WithAsyncRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, Task<TResult>> func,
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

            return async (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cancellationToken) =>
            {
                Task<TResult>? t;
                int attempt = 0;

            Attempt:
                t = null;
                attempt++;

                try
                {
                    t = func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cancellationToken);
                    if (t == null)
                        goto Invalid;

                    await t.ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    bool isCanceled = t != null ? t.IsCanceled : e.IsCancellation(cancellationToken);
                    if (isCanceled || !exceptionHandler(e) || (maxRetries != Retries.Infinite && attempt > maxRetries))
                        throw;

                    await Task.Delay(delayHandler(attempt, default, e), cancellationToken).ConfigureAwait(false);
                    goto Attempt;
                }

                TResult result = t.Result;
                ResultKind kind = resultHandler(result);
                if (kind != ResultKind.Transient || (maxRetries != Retries.Infinite && attempt > maxRetries))
                    return result;

                await Task.Delay(delayHandler(attempt, result, default), cancellationToken).ConfigureAwait(false);
                goto Attempt;

            Invalid:
                throw new InvalidOperationException(SR.InvalidTaskResult);
            };
        }

        #endregion
    }
}
