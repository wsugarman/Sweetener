// Generated from Action.Extensions.Test.tt
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    // Define type aliases for the various generic types used below as they can become pretty cumbersome
    using TestAction                   = Action     <int, string, double, long>;
    using InterruptableTestAction      = Action     <int, string, double, long, CancellationToken>;
    using TestActionProxy              = ActionProxy<int, string, double, long>;
    using InterruptableTestActionProxy = ActionProxy<int, string, double, long, CancellationToken>;
    using DelayHandlerProxy            = FuncProxy<int, TimeSpan>;
    using ComplexDelayHandlerProxy     = FuncProxy<int, Exception, TimeSpan>;

    partial class ActionExtensionsTest
    {
        [TestMethod]
        public void WithRetryT5_DelayHandler()
        {
            TestAction nullAction = null;
            TestAction action     = (arg1, arg2, arg3, arg4) => Operation.Null();
            Assert.ThrowsException<ArgumentNullException      >(() => nullAction.WithRetry( 4, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => action    .WithRetry(-2, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, ExceptionPolicy.Transient, (DelayHandler)null));

            // Create the delegates necessary to test the WithRetry overload
            Func<Action<CancellationToken>, TestActionProxy> actionFactory = a => new TestActionProxy((arg1, arg2, arg3, arg4) => a(CancellationToken.None));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<TestAction, int, ExceptionHandler, Func<int, TimeSpan>, TestAction> withRetry = (a, r, e, d) => a.WithRetry(r, e, d.Invoke);
            Action<TestAction, int, string, double, long, CancellationToken> invoke = (action, arg1, arg2, arg3, arg4, token) => action(arg1, arg2, arg3, arg4);

            Action<TestActionProxy>           observeAction      = a          => a.Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            Action<TestActionProxy, TimeSpan> observeActionDelay = (a, delay) => a.Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, delay);

            // Test each scenario
            WithRetryT5_Success         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int>());
            WithRetryT5_Failure         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int>());
            WithRetryT5_EventualSuccess (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_EventualFailure (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_RetriesExhausted(actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
        }

        [TestMethod]
        public void WithRetryT5_ComplexDelayHandler()
        {
            TestAction nullAction = null;
            TestAction action     = (arg1, arg2, arg3, arg4) => Operation.Null();
            Assert.ThrowsException<ArgumentNullException      >(() => nullAction.WithRetry( 4, ExceptionPolicy.Transient, (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => action    .WithRetry(-2, ExceptionPolicy.Transient, (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, null                     , (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, ExceptionPolicy.Transient, (ComplexDelayHandler)null));

            // Create the delegates necessary to test the WithRetry overload
            Func<Action<CancellationToken>, TestActionProxy> actionFactory = a => new TestActionProxy((arg1, arg2, arg3, arg4) => a(CancellationToken.None));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, e) => t);
            Func<TestAction, int, ExceptionHandler, Func<int, Exception, TimeSpan>, TestAction> withRetry = (a, r, e, d) => a.WithRetry(r, e, d.Invoke);
            Action<TestAction, int, string, double, long, CancellationToken> invoke = (action, arg1, arg2, arg3, arg4, token) => action(arg1, arg2, arg3, arg4);

            Action<TestActionProxy>           observeAction      = a          => a.Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            Action<TestActionProxy, TimeSpan> observeActionDelay = (a, delay) => a.Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, delay);

            // Test each scenario
            WithRetryT5_Success         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int, Exception>());
            WithRetryT5_Failure         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int, Exception>());
            WithRetryT5_EventualSuccess (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_EventualFailure (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_RetriesExhausted(actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
        }

        [TestMethod]
        public void WithRetryT5_WithToken_DelayHandler()
        {
            InterruptableTestAction nullAction = null;
            InterruptableTestAction action     = (arg1, arg2, arg3, arg4, token) => Operation.Null();
            Assert.ThrowsException<ArgumentNullException      >(() => nullAction.WithRetry( 4, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => action    .WithRetry(-2, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, ExceptionPolicy.Transient, (DelayHandler)null));

            // Create the delegates necessary to test the WithRetry overload
            Func<Action<CancellationToken>, InterruptableTestActionProxy> actionFactory = a => new InterruptableTestActionProxy((arg1, arg2, arg3, arg4, token) => a(token));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<InterruptableTestAction, int, ExceptionHandler, Func<int, TimeSpan>, InterruptableTestAction> withRetry = (a, r, e, d) => a.WithRetry(r, e, d.Invoke);
            Action<InterruptableTestAction, int, string, double, long, CancellationToken> invoke = (action, arg1, arg2, arg3, arg4, token) => action(arg1, arg2, arg3, arg4, token);

            Action<InterruptableTestActionProxy>           observeAction      = a          => a.Invoking += Expect.Arguments<int, string, double, long, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestActionProxy, TimeSpan> observeActionDelay = (a, delay) => a.Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, CancellationToken>(Arguments.Validate, delay);

            // Test each scenario
            WithRetryT5_Success         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int>());
            WithRetryT5_Failure         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int>());
            WithRetryT5_EventualSuccess (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_EventualFailure (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_RetriesExhausted(actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_Canceled_Action (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
            WithRetryT5_Canceled_Delay  (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.Asc());
        }
        [TestMethod]
        public void WithRetryT5_WithToken_ComplexDelayHandler()
        {
            InterruptableTestAction nullAction = null;
            InterruptableTestAction action     = (arg1, arg2, arg3, arg4, token) => Operation.Null();
            Assert.ThrowsException<ArgumentNullException      >(() => nullAction.WithRetry( 4, ExceptionPolicy.Transient, (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => action    .WithRetry(-2, ExceptionPolicy.Transient, (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, null                     , (i, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => action    .WithRetry( 4, ExceptionPolicy.Transient, (ComplexDelayHandler)null));

            // Create the delegates necessary to test the WithRetry overload
            Func<Action<CancellationToken>, InterruptableTestActionProxy> actionFactory = a => new InterruptableTestActionProxy((arg1, arg2, arg3, arg4, token) => a(token));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, e) => t);
            Func<InterruptableTestAction, int, ExceptionHandler, Func<int, Exception, TimeSpan>, InterruptableTestAction> withRetry = (a, r, e, d) => a.WithRetry(r, e, d.Invoke);
            Action<InterruptableTestAction, int, string, double, long, CancellationToken> invoke = (action, arg1, arg2, arg3, arg4, token) => action(arg1, arg2, arg3, arg4, token);

            Action<InterruptableTestActionProxy>           observeAction      = a          => a.Invoking += Expect.Arguments<int, string, double, long, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestActionProxy, TimeSpan> observeActionDelay = (a, delay) => a.Invoking += Expect.ArgumentsAfterDelay<int, string, double, long, CancellationToken>(Arguments.Validate, delay);

            // Test each scenario
            WithRetryT5_Success         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int, Exception>());
            WithRetryT5_Failure         (actionFactory, delayHandlerFactory, withRetry, invoke, observeAction     ,  d     => d.Invoking += Expect.Nothing<int, Exception>());
            WithRetryT5_EventualSuccess (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_EventualFailure (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_RetriesExhausted(actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_Canceled_Action (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
            WithRetryT5_Canceled_Delay  (actionFactory, delayHandlerFactory, withRetry, invoke, observeActionDelay, (d, e) => d.Invoking += Expect.ExceptionAsc(e));
        }
    }
}
