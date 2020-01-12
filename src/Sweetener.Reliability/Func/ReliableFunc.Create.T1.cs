// Generated from ReliableFunc.Create.tt
using System;
using System.Threading;

namespace Sweetener.Reliability
{
    /// <summary>
    /// Provides a set of methods for creating reliable functions.
    /// </summary>
    public static partial class ReliableFunc
    {
        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<TResult> func,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<TResult> func,
            int                          maxRetries,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<TResult> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<TResult> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler              exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<CancellationToken, TResult> func,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<CancellationToken, TResult> func,
            int                          maxRetries,
            ExceptionHandler             exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<CancellationToken, TResult> func,
            int                    maxRetries,
            ResultHandler<TResult> resultHandler,
            ExceptionHandler       exceptionHandler,
            DelayHandler           delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableFunc{TResult}"/>
        /// that executes the given function at most a specific number of times
        /// based on the provided policies.
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
        public static ReliableFunc<TResult> Create<TResult>(
            Func<CancellationToken, TResult> func,
            int                          maxRetries,
            ResultHandler<TResult>       resultHandler,
            ExceptionHandler              exceptionHandler,
            ComplexDelayHandler<TResult> delayHandler)
            => new ReliableFunc<TResult>(func, maxRetries, resultHandler, exceptionHandler, delayHandler);
    }
}
