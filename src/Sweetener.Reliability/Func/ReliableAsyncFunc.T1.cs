// Generated from ReliableAsyncFunc.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    /// <summary>
    /// A wrapper to reliably invoke an asynchronous function despite transient issues.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value of the method that this reliable delegate encapsulates.</typeparam>
    public sealed class ReliableAsyncFunc<TResult> : ReliableDelegate<TResult>
    {
        private readonly Func<CancellationToken, Task<TResult>> _func;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : this(func.IgnoreInterruption(), maxRetries, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            : this(func.IgnoreInterruption(), maxRetries, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<Task<TResult>> func, int maxRetries, ResultHandler<TResult> resultHandler, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : this(func.IgnoreInterruption(), maxRetries, resultHandler, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<Task<TResult>> func, int maxRetries, ResultHandler<TResult> resultHandler, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            : this(func.IgnoreInterruption(), maxRetries, resultHandler, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<CancellationToken, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : base(maxRetries, exceptionHandler, delayHandler)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<CancellationToken, Task<TResult>> func, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            : base(maxRetries, exceptionHandler, delayHandler)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<CancellationToken, Task<TResult>> func, int maxRetries, ResultHandler<TResult> resultHandler, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : base(maxRetries, resultHandler, exceptionHandler, delayHandler)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAsyncFunc{TResult}"/>
        /// class that executes the given asynchronous function at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="func">The function to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="resultHandler">A function that determines which results are valid.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func" />, <paramref name="resultHandler" /> <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAsyncFunc(Func<CancellationToken, Task<TResult>> func, int maxRetries, ResultHandler<TResult> resultHandler, ExceptionHandler exceptionHandler, ComplexDelayHandler<TResult> delayHandler)
            : base(maxRetries, resultHandler, exceptionHandler, delayHandler)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        /// <summary>
        /// Asynchronously invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains the return value of the method that this reliable delegate encapsulates.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The encapsulated method returned <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </exception>
        public async Task<TResult> InvokeAsync()
            => await InvokeAsync(CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Asynchronously invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the operation to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains the return value of the method that this reliable delegate encapsulates.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The encapsulated method returned <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public async Task<TResult> InvokeAsync(CancellationToken cancellationToken)
        {
            Task<TResult> t;
            int attempt = 0;

        Attempt:
            t = null;
            attempt++;

            try
            {
                t = _func(cancellationToken);
                if (t == null)
                    goto Invalid;

                await t.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                bool isCanceled = t != null ? t.IsCanceled : e.IsCancellation(cancellationToken);
                if (isCanceled || !await CanRetryAsync(attempt, e, cancellationToken).ConfigureAwait(false))
                    throw;

                goto Attempt;
            }

            TResult result = t.Result;
            if (await MoveNextAsync(attempt, result, cancellationToken).ConfigureAwait(false) != FunctionState.Retry)
                return result;

            goto Attempt;

        Invalid:
            throw new InvalidOperationException("Method resulted in an invalid Task.");
        }

         /// <summary>
        /// Asynchronously attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains a named <see cref="ValueTuple{T1, T2}"/> that contains both a <see cref="bool"/>
        /// flag, indicating the success of the encapsulated method, and its result, if it succeeded.
        /// Otherwise the result is the default value if the encapsulated method failed.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The encapsulated method returned <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </exception>
        public async Task<(bool Success, TResult Result)> TryInvokeAsync()
            => await TryInvokeAsync(CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Asynchronously attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the operation to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains a named <see cref="ValueTuple{T1, T2}"/> that contains both a <see cref="bool"/>
        /// flag, indicating the success of the encapsulated method, and its result, if it succeeded.
        /// Otherwise the result is the default value if the encapsulated method failed.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The encapsulated method returned <see langword="null"/> instead of a valid <see cref="Task{TResult}"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public async Task<(bool Success, TResult Result)> TryInvokeAsync(CancellationToken cancellationToken)
        {
            Task<TResult> t;
            int attempt = 0;

        Attempt:
            t = null;
            attempt++;

            try
            {
                t = _func(cancellationToken);
                if (t == null)
                    goto Invalid;

                await t.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (e.IsCancellation(cancellationToken))
                    throw;

                if (!await CanRetryAsync(attempt, e, cancellationToken).ConfigureAwait(false))
                    goto Fail;

                goto Attempt;
            }

            TResult result = t.Result;
            switch (await MoveNextAsync(attempt, result, cancellationToken).ConfigureAwait(false))
            {
                case FunctionState.ReturnSuccess:
                    return (Success: true, Result: result);
                case FunctionState.ReturnFailure:
                    goto Fail;
                default:
                    goto Attempt;
            }

        Fail:
            return (Success: false, Result: default);

        Invalid:
            throw new InvalidOperationException("Method resulted in an invalid Task.");
        }
    }
}
