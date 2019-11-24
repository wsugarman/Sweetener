// Generated from ReliableAction.Test.tt
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    [TestClass]
    public sealed class ReliableAction11Test : ReliableDelegateTest
    {
        private static readonly Func<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>> s_getAction = DynamicGetter.ForField<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>>("_action");

        [TestMethod]
        public void Ctor_DelayPolicy()
        {
            Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => Operation.Null();
            ExceptionPolicy          exceptionPolicy = ExceptionPolicies.Fatal;
            FuncProxy<int, TimeSpan> delayPolicy     = new FuncProxy<int, TimeSpan>(i => Constants.Delay);

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(null  , Retries.Infinite, exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, -2              , exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, Retries.Infinite, null           , delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, Retries.Infinite, exceptionPolicy, (DelayPolicy)null ));

            // Create a ReliableAction and validate
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> actual = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, 37, exceptionPolicy, delayPolicy.Invoke);

            // DelayPolicies are wrapped in ComplexDelayPolicies, so we can only validate the correct assignment by invoking the policy
            Ctor(actual, action, 37, exceptionPolicy, actualPolicy =>
            {
                delayPolicy.Invoking += (i, c) => Assert.AreEqual(i, 42);
                Assert.AreEqual(Constants.Delay, actualPolicy(42, new ArgumentOutOfRangeException()));
                Assert.AreEqual(1, delayPolicy.Calls);
            });
        }

        [TestMethod]
        public void Ctor_ComplexDelayPolicy()
        {
            Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => Operation.Null();
            ExceptionPolicy    exceptionPolicy    = ExceptionPolicies.Fatal;
            ComplexDelayPolicy complexDelayPolicy = (i, e) => TimeSpan.FromHours(1);

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(null  , Retries.Infinite, exceptionPolicy, complexDelayPolicy));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, -2              , exceptionPolicy, complexDelayPolicy));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, Retries.Infinite, null           , complexDelayPolicy));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, Retries.Infinite, exceptionPolicy, (ComplexDelayPolicy)null));

            // Create a ReliableAction and validate
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> actual = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(action, 37, exceptionPolicy, complexDelayPolicy);
            Ctor(actual, action, 37, exceptionPolicy, complexDelayPolicy);
        }

        private void Ctor(ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction, Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> expectedAction, int expectedMaxRetries, ExceptionPolicy expectedExceptionPolicy, ComplexDelayPolicy expectedDelayPolicy)
            => Ctor(reliableAction, expectedAction, expectedMaxRetries, expectedExceptionPolicy, actual => Assert.AreSame(expectedDelayPolicy, actual));

        private void Ctor(ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction, Action<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> expectedAction, int expectedMaxRetries, ExceptionPolicy expectedExceptionPolicy, Action<ComplexDelayPolicy> validateDelayPolicy)
        {
            Assert.AreSame (expectedAction         , s_getAction(reliableAction)         );
            Assert.AreEqual(expectedMaxRetries     , reliableAction.MaxRetries           );
            Assert.AreSame (expectedExceptionPolicy, s_getExceptionPolicy(reliableAction));

            validateDelayPolicy(s_getDelayPolicy(reliableAction));
        }

        [TestMethod]
        public void Invoke_NoCancellationToken()
            => Invoke((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => r.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));

        [TestMethod]
        public void Invoke_CancellationToken()
        {
            using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                Invoke((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => r.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, tokenSource.Token));

            // Ensure CancellationToken prevents additional retry
            Invoke_Canceled((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, token) => r.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, token));
        }

        [TestMethod]
        public void TryInvoke_NoCancellationToken()
            => TryInvoke((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => r.TryInvoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));

        [TestMethod]
        public void TryInvoke_CancellationToken()
        {
            using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                TryInvoke((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => r.TryInvoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, tokenSource.Token));
        
            // Ensure CancellationToken prevents additional retry
            Invoke_Canceled((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, token) => r.TryInvoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, token));
        }

        private void Invoke(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> invoke)
        {
            Invoke_Success        (invoke);
            Invoke_EventualSuccess(invoke);

            Invoke_Failure         ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.That.ThrowsException(() => invoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), e));
            Invoke_EventualFailure ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.That.ThrowsException(() => invoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), e));
            Invoke_RetriesExhausted((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.That.ThrowsException(() => invoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), e));
        }

        private void TryInvoke(Func<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong, bool> tryInvoke)
        {
            Invoke_Success         ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11   ) => Assert.IsTrue (tryInvoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
            Invoke_EventualSuccess ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11   ) => Assert.IsTrue (tryInvoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
            Invoke_Failure         ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.IsFalse(tryInvoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
            Invoke_EventualFailure ((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.IsFalse(tryInvoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
            Invoke_RetriesExhausted((r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, e) => Assert.IsFalse(tryInvoke(r, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
        }

        private void Invoke_Success(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> assertInvoke)
        {
            // Create a "successful" user-defined action
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => Operation.Null());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>();
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>();

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.Arguments<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate);
            exceptionPolicy .Invoking += Expect.Nothing<Exception>();
            delayPolicy     .Invoking += Expect.Nothing<int, Exception>();
            retryHandler    .Invoking += Expect.Nothing<int, Exception>();
            failedHandler   .Invoking += Expect.Nothing<Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<Exception>();

            // Invoke
            assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL);

            // Validate the number of calls
            Assert.AreEqual(1, action          .Calls);
            Assert.AreEqual(0, exceptionPolicy .Calls);
            Assert.AreEqual(0, delayPolicy     .Calls);
            Assert.AreEqual(0, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_Failure(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong, Type> assertInvoke)
        {
            // Create an "unsuccessful" user-defined action
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => throw new InvalidOperationException());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>(ExceptionPolicies.Fail<InvalidOperationException>().Invoke);
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>((i, e) => Constants.Delay);

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.Arguments<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate);
            exceptionPolicy .Invoking += Expect.Exception(typeof(InvalidOperationException));
            delayPolicy     .Invoking += Expect.Nothing<int, Exception>();
            retryHandler    .Invoking += Expect.Nothing<int, Exception>();
            failedHandler   .Invoking += Expect.Exception(typeof(InvalidOperationException));
            exhaustedHandler.Invoking += Expect.Nothing<Exception>();

            // Invoke
            assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL, typeof(InvalidOperationException));

            // Validate the number of calls
            Assert.AreEqual(1, action          .Calls);
            Assert.AreEqual(1, exceptionPolicy .Calls);
            Assert.AreEqual(0, delayPolicy     .Calls);
            Assert.AreEqual(0, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_EventualSuccess(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> assertInvoke)
        {
            // Create a "successful" user-defined action that completes after 1 IOException
            Action flakyAction = FlakyAction.Create<IOException>(1);
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => flakyAction());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>((i, e) => Constants.Delay);

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate, Constants.MinDelay);
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.ExceptionAsc(typeof(IOException));
            retryHandler    .Invoking += Expect.ExceptionAsc(typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<Exception>();

            // Invoke
            assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL);

            // Validate the number of calls
            Assert.AreEqual(2, action          .Calls);
            Assert.AreEqual(1, exceptionPolicy .Calls);
            Assert.AreEqual(1, delayPolicy     .Calls);
            Assert.AreEqual(1, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_EventualFailure(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong, Type> assertInvoke)
        {
            // Create an "unsuccessful" user-defined action that fails after 2 transient exceptions
            Action flakyAction = FlakyAction.Create<IOException, InvalidOperationException>(2);
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => flakyAction());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>((i, e) => Constants.Delay);

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate, Constants.MinDelay);
            exceptionPolicy .Invoking += Expect.Exceptions(typeof(IOException), typeof(InvalidOperationException), 2);
            delayPolicy     .Invoking += Expect.ExceptionAsc(typeof(IOException));
            retryHandler    .Invoking += Expect.ExceptionAsc(typeof(IOException));
            failedHandler   .Invoking += Expect.Exception(typeof(InvalidOperationException));
            exhaustedHandler.Invoking += Expect.Nothing<Exception>();

            // Invoke
            assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL, typeof(InvalidOperationException));

            // Validate the number of calls
            Assert.AreEqual(3, action          .Calls);
            Assert.AreEqual(3, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_RetriesExhausted(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong, Type> assertInvoke)
        {
            // Create an "unsuccessful" user-defined action that exhausts the configured number of retries
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => throw new IOException());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>((i, e) => Constants.Delay);

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                2,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate, Constants.MinDelay);
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.ExceptionAsc(typeof(IOException));
            retryHandler    .Invoking += Expect.ExceptionAsc(typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<Exception>();
            exhaustedHandler.Invoking += Expect.Exception(typeof(IOException));

            // Invoke
            assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL, typeof(IOException));

            // Validate the number of calls
            Assert.AreEqual(3, action          .Calls);
            Assert.AreEqual(3, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(1, exhaustedHandler.Calls);
        }

        private void Invoke_Canceled(Action<ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>, int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong, CancellationToken> assertInvoke)
        {
            using ManualResetEvent        cancellationTrigger = new ManualResetEvent(false);
            using CancellationTokenSource tokenSource         = new CancellationTokenSource();

            // Create an "unsuccessful" user-defined action that continues to fail with transient exceptions until it's canceled
            ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> action = new ActionProxy<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => throw new IOException());

            // Declare the various policy and event handler proxies
            FuncProxy<Exception, bool>          exceptionPolicy  = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, Exception, TimeSpan> delayPolicy      = new FuncProxy<int, Exception, TimeSpan>((i, e) => Constants.Delay);

            ActionProxy<int, Exception>         retryHandler     = new ActionProxy<int, Exception>();
            ActionProxy<Exception>              failedHandler    = new ActionProxy<Exception>();
            ActionProxy<Exception>              exhaustedHandler = new ActionProxy<Exception>();

            // Create ReliableAction
            ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong> reliableAction = new ReliableAction<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(
                action.Invoke,
                Retries.Infinite,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableAction.Retrying         += retryHandler    .Invoke;
            reliableAction.Failed           += failedHandler   .Invoke;
            reliableAction.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            action          .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, ushort, byte, TimeSpan, uint, Tuple<bool, ulong>, DateTime, ulong>(Arguments.Validate, Constants.MinDelay);
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.ExceptionAsc(typeof(IOException));
            retryHandler    .Invoking += Expect.ExceptionAsc(typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<Exception>();

            // Trigger the event upon retry
            retryHandler    .Invoking += (i, e, c) => cancellationTrigger.Set();

            // Create a task whose job is to cancel the invocation after at least 1 retry
            Task cancellationTask = Task.Factory.StartNew((state) =>
            {
                (ManualResetEvent e, CancellationTokenSource s) = ((ManualResetEvent, CancellationTokenSource))state;
                e.WaitOne();
                s.Cancel();

            }, (cancellationTrigger, tokenSource));

            // Begin the invocation
            Assert.That.ThrowsException<OperationCanceledException>(() => assertInvoke(reliableAction, 42, "foo", 3.14D, 1000L, (ushort)1, (byte)255, TimeSpan.FromDays(30), 112U, Tuple.Create(true, 64UL), new DateTime(2019, 10, 06), 321UL, tokenSource.Token));

            // Validate the number of calls
            int calls = action.Calls;
            Assert.IsTrue(calls > 1);

            Assert.AreEqual(calls    , action          .Calls);
            Assert.AreEqual(calls    , exceptionPolicy .Calls);
            Assert.AreEqual(calls    , delayPolicy     .Calls);
            Assert.AreEqual(calls - 1, retryHandler    .Calls);
            Assert.AreEqual(0        , failedHandler   .Calls);
            Assert.AreEqual(0        , exhaustedHandler.Calls);
        }
    }
}
