// Generated from ReliableAsyncFunc.Create.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    static partial class ReliableAsyncFunc
    {
        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, Task<TResult>> func,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, Task<TResult>> func,
            int                          maxRetries,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, Task<TResult>> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, Task<TResult>> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler              exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, CancellationToken, Task<TResult>> func,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, CancellationToken, Task<TResult>> func,
            int                          maxRetries,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, CancellationToken, Task<TResult>> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncFunc{T, TResult}"/>
        /// that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
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
        public static ReliableAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, CancellationToken, Task<TResult>> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler              exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableAsyncFunc<T, TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);
    }
}
