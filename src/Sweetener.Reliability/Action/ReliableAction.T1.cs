// Generated from ReliableAction.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    /// <summary>
    /// A wrapper to reliably invoke an action despite transient issues.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this reliable delegate encapsulates.</typeparam>
    public sealed class ReliableAction<T> : ReliableDelegate
    {
        private readonly Action<T, CancellationToken> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAction{T}"/>
        /// class that executes the given action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAction(Action<T> action, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : this(action.IgnoreInterruption(), maxRetries, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAction{T}"/>
        /// class that executes the given action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAction(Action<T> action, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler delayHandler)
            : this(action.IgnoreInterruption(), maxRetries, exceptionHandler, delayHandler)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAction{T}"/>
        /// class that executes the given action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAction(Action<T, CancellationToken> action, int maxRetries, ExceptionHandler exceptionHandler, DelayHandler delayHandler)
            : base(maxRetries, exceptionHandler, delayHandler)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableAction{T}"/>
        /// class that executes the given action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public ReliableAction(Action<T, CancellationToken> action, int maxRetries, ExceptionHandler exceptionHandler, ComplexDelayHandler delayHandler)
            : base(maxRetries, exceptionHandler, delayHandler)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        public void Invoke(T arg)
            => Invoke(arg, CancellationToken.None);

        /// <summary>
        /// Invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to observe while waiting for the operation to complete.
        /// </param>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public void Invoke(T arg, CancellationToken cancellationToken)
        {
            // Check for cancellation before invoking
            cancellationToken.ThrowIfCancellationRequested();

            int attempt = 0;

        Attempt:
            attempt++;

            try
            {
                _action(arg, cancellationToken);
            }
            catch (Exception e)
            {
                if (e.IsCancellation(cancellationToken) || !CanRetry(attempt, e, cancellationToken))
                    throw;

                goto Attempt;
            }
        }

        /// <summary>
        /// Asynchronously invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <remarks>
        /// If the encapsulated method succeeds without retrying, the method executes synchronously.
        /// </remarks>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <returns>A task that represents the asynchronous invoke operation.</returns>
        public Task InvokeAsync(T arg)
            => InvokeAsync(arg, CancellationToken.None);

        /// <summary>
        /// Asynchronously invokes the encapsulated method despite transient errors.
        /// </summary>
        /// <remarks>
        /// If the encapsulated method succeeds without retrying, the method executes synchronously.
        /// </remarks>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to observe while waiting for the operation to complete.
        /// </param>
        /// <returns>A task that represents the asynchronous invoke operation.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public async Task InvokeAsync(T arg, CancellationToken cancellationToken)
        {
            // Check for cancellation before invoking
            cancellationToken.ThrowIfCancellationRequested();

            int attempt = 0;

        Attempt:
            attempt++;

            try
            {
                _action(arg, cancellationToken);
                return;
            }
            catch (Exception e)
            {
                if (e.IsCancellation(cancellationToken) || !await CanRetryAsync(attempt, e, cancellationToken).ConfigureAwait(false))
                    throw;

                goto Attempt;
            }
        }

        /// <summary>
        /// Attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <returns>
        /// <see langword="true"/> if the encapsulated method completed without throwing an exception
        /// within the maximum number of retries; otherwise, <see langword="false"/>.
        /// </returns>
        public bool TryInvoke(T arg)
            => TryInvoke(arg, CancellationToken.None);

        /// <summary>
        /// Attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to observe while waiting for the operation to complete.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the encapsulated method completed without throwing an exception
        /// within the maximum number of retries; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public bool TryInvoke(T arg, CancellationToken cancellationToken)
        {
            // Check for cancellation before invoking
            cancellationToken.ThrowIfCancellationRequested();

            int attempt = 0;

        Attempt:
            attempt++;

            try
            {
                _action(arg, cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                if (e.IsCancellation(cancellationToken))
                    throw;

                if (!CanRetry(attempt, e, cancellationToken))
                    return false;

                goto Attempt;
            }
        }

        /// <summary>
        /// Asynchronously attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains <see langword="true"/> if the encapsulated method completed without throwing
        /// an exception within the maximum number of retries; otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> TryInvokeAsync(T arg)
            => TryInvokeAsync(arg, CancellationToken.None);

        /// <summary>
        /// Asynchronously attempts to successfully invoke the encapsulated method despite transient errors.
        /// </summary>
        /// <param name="arg">The parameter of the method that this reliable delegate encapsulates.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to observe while waiting for the operation to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous invoke operation. The value of the <c>TResult</c>
        /// parameter contains <see langword="true"/> if the encapsulated method completed without throwing
        /// an exception within the maximum number of retries; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// The underlying <see cref="CancellationTokenSource" /> has already been disposed.
        /// </exception>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was canceled.</exception>
        public async Task<bool> TryInvokeAsync(T arg, CancellationToken cancellationToken)
        {
            // Check for cancellation before invoking
            cancellationToken.ThrowIfCancellationRequested();

            int attempt = 0;

        Attempt:
            attempt++;

            try
            {
                _action(arg, cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                if (e.IsCancellation(cancellationToken))
                    throw;

                if (!await CanRetryAsync(attempt, e, cancellationToken).ConfigureAwait(false))
                    return false;

                goto Attempt;
            }
        }
    }
}
