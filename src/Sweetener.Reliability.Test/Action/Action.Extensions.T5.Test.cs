// Generated from ReliableAction.Extensions.Test.tt
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    partial class ActionExtensionsTest
    {
        [TestMethod]
        public void WithRetryT5_DelayPolicy()
        {
            Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry = (a, r, e, d) => a.WithRetry(r, e, d);

            WithRetryT5_DelayPolicy_Success         (withRetry);
            WithRetryT5_DelayPolicy_Failure         (withRetry);
            WithRetryT5_DelayPolicy_EventualSuccess (withRetry);
            WithRetryT5_DelayPolicy_EventualFailure (withRetry);
            WithRetryT5_DelayPolicy_RetriesExhausted(withRetry);
        }

        [TestMethod]
        public void WithRetryT5_DelayPolicy_CancellationToken()
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry = (a, r, e, d) => a.WithRetry(r, e, d);

            WithRetryT5_DelayPolicy_Success         (withRetry, useToken: true);
            WithRetryT5_DelayPolicy_Failure         (withRetry, useToken: true);
            WithRetryT5_DelayPolicy_EventualSuccess (withRetry, useToken: true);
            WithRetryT5_DelayPolicy_EventualFailure (withRetry, useToken: true);
            WithRetryT5_DelayPolicy_RetriesExhausted(withRetry, useToken: true);
            WithRetryT5_DelayPolicy_Canceled        (withRetry);
        }

        [TestMethod]
        public void WithRetryT5_ComplexDelayPolicy()
        {
            Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry = (a, r, e, d) => a.WithRetry(r, e, d);

            WithRetryT5_ComplexDelayPolicy_Success         (withRetry);
            WithRetryT5_ComplexDelayPolicy_Failure         (withRetry);
            WithRetryT5_ComplexDelayPolicy_EventualSuccess (withRetry);
            WithRetryT5_ComplexDelayPolicy_EventualFailure (withRetry);
            WithRetryT5_ComplexDelayPolicy_RetriesExhausted(withRetry);
        }

        [TestMethod]
        public void WithRetryT5_ComplexDelayPolicy_CancellationToken()
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry = (a, r, e, d) => a.WithRetry(r, e, d);

            WithRetryT5_ComplexDelayPolicy_Success         (withRetry, useToken: true);
            WithRetryT5_ComplexDelayPolicy_Failure         (withRetry, useToken: true);
            WithRetryT5_ComplexDelayPolicy_EventualSuccess (withRetry, useToken: true);
            WithRetryT5_ComplexDelayPolicy_EventualFailure (withRetry, useToken: true);
            WithRetryT5_ComplexDelayPolicy_RetriesExhausted(withRetry, useToken: true);
            WithRetryT5_ComplexDelayPolicy_Canceled        (withRetry);
        }

        private void WithRetryT5_DelayPolicy_Success(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_Success((a, r, e, d) => withRetry(a, r, e, d.Invoke), () => PolicyValidator.IgnoreDelayPolicy(), useToken);

        private void WithRetryT5_ComplexDelayPolicy_Success(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_Success((a, r, e, d) => withRetry(a, r, e, d.Invoke), () => PolicyValidator.IgnoreComplexDelayPolicy(), useToken);

        private void WithRetryT5_Success<T>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, T, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<T> delayPolicyFactory, bool useToken = false)
            where T : ObservableFunc
        {
            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.IgnoreExceptionPolicy();
            T delayPolicy = delayPolicyFactory();

            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) => Arguments.Validate(arg1, arg2, arg3, arg4, arg5),
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy);

            if (useToken)
            {
                using CancellationTokenSource tokenSource = new CancellationTokenSource();
                reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token);
            }
            else
            {
                reliableAction(42, "foo", 3.14D, 1000L, (ushort)1);
            }

            Assert.AreEqual(0, exceptionPolicy.Calls);
            Assert.AreEqual(0, delayPolicy    .Calls);
        }

        private void WithRetryT5_DelayPolicy_Failure(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_Failure((a, r, e, d) => withRetry(a, r, e, d.Invoke), () => PolicyValidator.IgnoreDelayPolicy(), useToken);

        private void WithRetryT5_ComplexDelayPolicy_Failure(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_Failure((a, r, e, d) => withRetry(a, r, e, d.Invoke), () => PolicyValidator.IgnoreComplexDelayPolicy(), useToken);

        private void WithRetryT5_Failure<T>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, T, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<T> delayPolicyFactory, bool useToken = false)
            where T : ObservableFunc
        {
            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.Create<FormatException>(ExceptionPolicies.Fail<FormatException>());
            T delayPolicy = delayPolicyFactory();

            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) =>
                {
                    Arguments.Validate(arg1, arg2, arg3, arg4, arg5);
                    throw new FormatException();
                },
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy);

            try
            {
                if (useToken)
                {
                    using CancellationTokenSource tokenSource = new CancellationTokenSource();
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token);
                }
                else
                {
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1);
                }

                Assert.Fail();
            }
            catch (FormatException)
            { }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.AreEqual(1, exceptionPolicy.Calls);
            Assert.AreEqual(0, delayPolicy    .Calls);
        }

        private void WithRetryT5_DelayPolicy_EventualSuccess(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_EventualSuccess<IOException, ObservableFunc<int, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create(DelayPolicies.Constant(t)), useToken);

        private void WithRetryT5_ComplexDelayPolicy_EventualSuccess(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_EventualSuccess<IOException, ObservableFunc<int, Exception, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create<IOException>((i, e) => t), useToken);

        private void WithRetryT5_EventualSuccess<TException, TFunc>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, TFunc, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<TimeSpan, TFunc> delayPolicyFactory, bool useToken = false)
            where TException : Exception, new()
            where TFunc      : ObservableFunc
        {
            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.Create<TException>(ExceptionPolicies.Retry<TException>());
            TFunc delayPolicy = delayPolicyFactory(Constants.Delay);

            Action eventualSuccess = FlakyAction.Create<TException>(1);
            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) =>
                {
                    Arguments.Validate(arg1, arg2, arg3, arg4, arg5);
                    eventualSuccess();
                },
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy);

            DateTime delayStartUtc = DateTime.UtcNow;
            if (useToken)
            {
                using CancellationTokenSource tokenSource = new CancellationTokenSource();
                reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token);
            }
            else
            {
                reliableAction(42, "foo", 3.14D, 1000L, (ushort)1);
            }
            TimeSpan delay = DateTime.UtcNow - delayStartUtc;

            Assert.IsTrue(delay > Constants.MinDelay);
            Assert.AreEqual(1, exceptionPolicy.Calls);
            Assert.AreEqual(1, delayPolicy    .Calls);
        }

        private void WithRetryT5_DelayPolicy_EventualFailure(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_EventualFailure<IOException, ObservableFunc<int, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create(DelayPolicies.Constant(t)), useToken);

        private void WithRetryT5_ComplexDelayPolicy_EventualFailure(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_EventualFailure<IOException, ObservableFunc<int, Exception, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create<IOException>((i, e) => t), useToken);

        private void WithRetryT5_EventualFailure<TTransient, TFunc>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, TFunc, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<TimeSpan, TFunc> delayPolicyFactory, bool useToken = false)
            where TTransient : Exception, new()
            where TFunc      : ObservableFunc
        {
            Assert.AreNotEqual(typeof(TTransient), typeof(InvalidOperationException));

            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.Create<TTransient, InvalidOperationException>(ExceptionPolicies.Retry<TTransient>());
            TFunc delayPolicy = delayPolicyFactory(Constants.Delay);

            Action eventualFailure = FlakyAction.Create<TTransient, InvalidOperationException>(2);
            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) =>
                {
                    Arguments.Validate(arg1, arg2, arg3, arg4, arg5);
                    eventualFailure();
                },
                4,
                exceptionPolicy.Invoke,
                delayPolicy);

            DateTime delayStartUtc = DateTime.UtcNow;

            try
            {
                if (useToken)
                {
                    using CancellationTokenSource tokenSource = new CancellationTokenSource();
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token);
                }
                else
                {
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1);
                }

                Assert.Fail();
            }
            catch (InvalidOperationException)
            { }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            TimeSpan delay = DateTime.UtcNow - delayStartUtc;
            Assert.IsTrue(delay > TimeSpan.FromMilliseconds(Constants.Delay.TotalMilliseconds * 2 * Constants.MinFactor));

            Assert.AreEqual(3, exceptionPolicy.Calls);
            Assert.AreEqual(2, delayPolicy    .Calls);
        }

        private void WithRetryT5_DelayPolicy_RetriesExhausted(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_RetriesExhausted<IOException, ObservableFunc<int, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create(DelayPolicies.Constant(t)), useToken);

        private void WithRetryT5_ComplexDelayPolicy_RetriesExhausted(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry, bool useToken = false)
            => WithRetryT5_RetriesExhausted<IOException, ObservableFunc<int, Exception, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create<IOException>((i, e) => t), useToken);

        private void WithRetryT5_RetriesExhausted<TException, TFunc>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, TFunc, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<TimeSpan, TFunc> delayPolicyFactory, bool useToken = false)
            where TException : Exception, new()
            where TFunc      : ObservableFunc
        {
            DateTime delayStartUtc = DateTime.MinValue;
            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.Create<TException>(ExceptionPolicies.Retry<TException>());
            TFunc delayPolicy = delayPolicyFactory(Constants.Delay);

            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) =>
                {
                    Arguments.Validate(arg1, arg2, arg3, arg4, arg5);
                    throw new TException();
                },
                2,
                exceptionPolicy.Invoke,
                delayPolicy);

            try
            {
                if (useToken)
                {
                    using CancellationTokenSource tokenSource = new CancellationTokenSource();
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token);
                }
                else
                {
                    reliableAction(42, "foo", 3.14D, 1000L, (ushort)1);
                }

                Assert.Fail();
            }
            catch (TException)
            { }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            TimeSpan delay = DateTime.UtcNow - delayStartUtc;
            Assert.IsTrue(delay > TimeSpan.FromMilliseconds(Constants.Delay.TotalMilliseconds * 2 * Constants.MinFactor));

            Assert.AreEqual(3, exceptionPolicy.Calls);
            Assert.AreEqual(2, delayPolicy    .Calls);
        }

        private void WithRetryT5_DelayPolicy_Canceled(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, DelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry)
            => WithRetryT5_Canceled<IOException, ObservableFunc<int, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create(DelayPolicies.Constant(t)));

        private void WithRetryT5_ComplexDelayPolicy_Canceled(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, ComplexDelayPolicy, InterruptableAction<int, string, double, long, ushort>> withRetry)
            => WithRetryT5_Canceled<IOException, ObservableFunc<int, Exception, TimeSpan>>((a, r, e, d) => withRetry(a, r, e, d.Invoke), t => PolicyValidator.Create<IOException>((i, e) => t));

        private void WithRetryT5_Canceled<TException, TFunc>(Func<Action<int, string, double, long, ushort>, int, ExceptionPolicy, TFunc, InterruptableAction<int, string, double, long, ushort>> withRetry, Func<TimeSpan, TFunc> delayPolicyFactory)
            where TException : Exception, new()
            where TFunc      : ObservableFunc
        {
            using ManualResetEvent        retryEvent  = new ManualResetEvent(false);
            using CancellationTokenSource tokenSource = new CancellationTokenSource();

            ObservableFunc<Exception, bool> exceptionPolicy = PolicyValidator.Create<TException>(ExceptionPolicies.Retry<TException>());
            TFunc delayPolicy = delayPolicyFactory(Constants.Delay);

            exceptionPolicy.Invoking += e =>
            {
                if (exceptionPolicy.Calls > 1)
                    retryEvent.Set();
            };

            InterruptableAction<int, string, double, long, ushort> reliableAction = withRetry(
                (arg1, arg2, arg3, arg4, arg5) =>
                {
                    Arguments.Validate(arg1, arg2, arg3, arg4, arg5);
                    throw new TException();
                },
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy);

            // While waiting for the reliable action to complete, we'll cancel it
            Task invocation = Task.Run(() => reliableAction(42, "foo", 3.14D, 1000L, (ushort)1, tokenSource.Token), tokenSource.Token);

            // Cancel after at least 1 retry has occurred
            retryEvent.WaitOne();
            tokenSource.Cancel();

            // Try to get the result
            try
            {
                invocation.Wait();
                Assert.Fail();
            }
            catch (AggregateException agg)
            {
                Assert.AreEqual(1, agg.InnerExceptions.Count);
                switch (agg.InnerException)
                {
                    case AssertFailedException afe:
                        throw afe;
                    case TaskCanceledException _:
                        Assert.IsTrue(exceptionPolicy.Calls > 0);
                        Assert.IsTrue(delayPolicy    .Calls > 0);
                        Assert.AreEqual(exceptionPolicy.Calls, delayPolicy.Calls);
                        return; // Successfully cancelled
                    default:
                        Assert.Fail();
                        break;
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}