// Generated from Func.Extensions.Test.tt
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    // Define type aliases for the various generic types used below as they can become pretty cumbersome
    using TestFunc                   = Func     <int, int>;
    using InterruptableTestFunc      = Func     <int, CancellationToken, int>;
    using TestFuncProxy              = FuncProxy<int, int>;
    using InterruptableTestFuncProxy = FuncProxy<int, CancellationToken, int>;
    using DelayHandlerProxy          = FuncProxy<int, TimeSpan>;
    using ComplexDelayHandlerProxy   = FuncProxy<int, int, Exception?, TimeSpan>;

    partial class FuncExtensionsTest : FuncExtensionsTestBase
    {
        [TestMethod]
        public void WithRetryT2_DelayHandler()
        {
            TestFunc? nullFunc = null;
            TestFunc  func     = (arg) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, ExceptionPolicy.Transient, (DelayHandler)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, TestFuncProxy> funcFactory = f => new TestFuncProxy((arg) => f(CancellationToken.None));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<TestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, TimeSpan>, TestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, e, d.Invoke);
            Func<TestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg);

            Action<TestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int>(Arguments.Validate);
            Action<TestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>(), passResultHandler: false);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);
        }

        [TestMethod]
        public void WithRetryT2_ComplexDelayHandler()
        {
            TestFunc? nullFunc = null;
            TestFunc  func     = (arg) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                     , (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, ExceptionPolicy.Transient, (ComplexDelayHandler<int>)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, TestFuncProxy> funcFactory = f => new TestFuncProxy((arg) => f(CancellationToken.None));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, r, e) => t);
            Func<TestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, int, Exception?, TimeSpan>, TestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, e, d.Invoke);
            Func<TestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg);

            Action<TestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int>(Arguments.Validate);
            Action<TestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>(), passResultHandler: false);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);
        }

        [TestMethod]
        public void WithRetryT2_ResultPolicy_DelayHandler()
        {
            TestFunc? nullFunc = null;
            TestFunc  func     = (arg) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, r => ResultKind.Successful, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                      , ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (DelayHandler)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, TestFuncProxy> funcFactory = f => new TestFuncProxy((arg) => f(CancellationToken.None));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<TestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, TimeSpan>, TestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, r, e, d.Invoke);
            Func<TestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg);

            Action<TestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int>(Arguments.Validate);
            Action<TestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>(), passResultHandler: true);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);

            // Failure (Result)
            WithRetryT2_Failure_Result         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Result (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc());
            WithRetryT2_RetriesExhausted_Result(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc());

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);
        }

        [TestMethod]
        public void WithRetryT2_ResultPolicy_ComplexDelayHandler()
        {
            TestFunc? nullFunc = null;
            TestFunc  func     = (arg) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, r => ResultKind.Successful, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                      , ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, null                     , (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (ComplexDelayHandler<int>)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, TestFuncProxy> funcFactory = f => new TestFuncProxy((arg) => f(CancellationToken.None));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, r, e) => t);
            Func<TestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, int, Exception?, TimeSpan>, TestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, r, e, d.Invoke);
            Func<TestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg);

            Action<TestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int>(Arguments.Validate);
            Action<TestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>(), passResultHandler: true);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);

            // Failure (Result)
            WithRetryT2_Failure_Result         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Result (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e));
            WithRetryT2_RetriesExhausted_Result(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e));

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);
        }

        [TestMethod]
        public void WithRetryT2_WithToken_DelayHandler()
        {
            InterruptableTestFunc? nullFunc = null;
            InterruptableTestFunc  func     = (arg, token) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, ExceptionPolicy.Transient, (DelayHandler)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, InterruptableTestFuncProxy> funcFactory = f => new InterruptableTestFuncProxy((arg, token) => f(token));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<InterruptableTestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, TimeSpan>, InterruptableTestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, e, d.Invoke);
            Func<InterruptableTestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg, token);

            Action<InterruptableTestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int, CancellationToken>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>(), passResultHandler: false);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);

            // Cancel
            WithRetryT2_Canceled      (funcFactory, delayHandlerFactory, withRetry, invoke);
            WithRetryT2_Canceled_Func (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);
            WithRetryT2_Canceled_Delay(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: false);
        }

        [TestMethod]
        public void WithRetryT2_WithToken_ComplexDelayHandler()
        {
            InterruptableTestFunc? nullFunc = null;
            InterruptableTestFunc  func     = (arg, token) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                     , (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, ExceptionPolicy.Transient, (ComplexDelayHandler<int>)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, InterruptableTestFuncProxy> funcFactory = f => new InterruptableTestFuncProxy((arg, token) => f(token));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, r, e) => t);
            Func<InterruptableTestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, int, Exception?, TimeSpan>, InterruptableTestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, e, d.Invoke);
            Func<InterruptableTestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg, token);

            Action<InterruptableTestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int, CancellationToken>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>(), passResultHandler: false);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);

            // Cancel
            WithRetryT2_Canceled      (funcFactory, delayHandlerFactory, withRetry, invoke);
            WithRetryT2_Canceled_Func (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);
            WithRetryT2_Canceled_Delay(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.OnlyExceptionAsc<int>(e), passResultHandler: false);
        }

        [TestMethod]
        public void WithRetryT2_WithToken_ResultPolicy_DelayHandler()
        {
            InterruptableTestFunc? nullFunc = null;
            InterruptableTestFunc  func     = (arg, token) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, r => ResultKind.Successful, ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                      , ExceptionPolicy.Transient, DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, null                     , DelayPolicy.None));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (DelayHandler)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, InterruptableTestFuncProxy> funcFactory = f => new InterruptableTestFuncProxy((arg, token) => f(token));
            Func<TimeSpan, DelayHandlerProxy> delayHandlerFactory = t => new DelayHandlerProxy((i) => t);
            Func<InterruptableTestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, TimeSpan>, InterruptableTestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, r, e, d.Invoke);
            Func<InterruptableTestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg, token);

            Action<InterruptableTestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int, CancellationToken>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>(), passResultHandler: true);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);

            // Failure (Result)
            WithRetryT2_Failure_Result         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Result (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc());
            WithRetryT2_RetriesExhausted_Result(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc());

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);

            // Cancel
            WithRetryT2_Canceled      (funcFactory, delayHandlerFactory, withRetry, invoke);
            WithRetryT2_Canceled_Func (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);
            WithRetryT2_Canceled_Delay(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.Asc(), passResultHandler: true);
        }

        [TestMethod]
        public void WithRetryT2_WithToken_ResultPolicy_ComplexDelayHandler()
        {
            InterruptableTestFunc? nullFunc = null;
            InterruptableTestFunc  func     = (arg, token) => 12345;

#nullable disable

            Assert.ThrowsException<ArgumentNullException      >(() => nullFunc.WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => func    .WithRetry(-2, r => ResultKind.Successful, ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, null                      , ExceptionPolicy.Transient, (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, null                     , (i, r, e) => TimeSpan.Zero));
            Assert.ThrowsException<ArgumentNullException      >(() => func    .WithRetry( 4, r => ResultKind.Successful, ExceptionPolicy.Transient, (ComplexDelayHandler<int>)null));

#nullable enable

            // Create the delegates necessary to test the WithRetry overload
            Func<Func<CancellationToken, int>, InterruptableTestFuncProxy> funcFactory = f => new InterruptableTestFuncProxy((arg, token) => f(token));
            Func<TimeSpan, ComplexDelayHandlerProxy> delayHandlerFactory = t => new ComplexDelayHandlerProxy((i, r, e) => t);
            Func<InterruptableTestFunc, int, ResultHandler<int>, ExceptionHandler, Func<int, int, Exception?, TimeSpan>, InterruptableTestFunc> withRetry = (f, m, r, e, d) => f.WithRetry(m, r, e, d.Invoke);
            Func<InterruptableTestFunc, int, CancellationToken, int> invoke = (f, arg, token) => f(arg, token);

            Action<InterruptableTestFuncProxy>?           observeFunc      = f          => f.Invoking += Expect.Arguments<int, CancellationToken>(Arguments.Validate);
            Action<InterruptableTestFuncProxy, TimeSpan>? observeFuncDelay = (f, delay) => f.Invoking += Expect.ArgumentsAfterDelay<int, CancellationToken>(Arguments.Validate, delay);

            // Success
            WithRetryT2_Success        (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>(), passResultHandler: true);
            WithRetryT2_EventualSuccess(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);

            // Failure (Result)
            WithRetryT2_Failure_Result         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Result (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e));
            WithRetryT2_RetriesExhausted_Result(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e));

            // Failure (Exception)
            WithRetryT2_Failure_Exception         (funcFactory, delayHandlerFactory, withRetry, invoke, observeFunc     ,  d        => d.Invoking += Expect.Nothing<int, int, Exception>());
            WithRetryT2_EventualFailure_Exception (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);
            WithRetryT2_RetriesExhausted_Exception(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);

            // Cancel
            WithRetryT2_Canceled      (funcFactory, delayHandlerFactory, withRetry, invoke);
            WithRetryT2_Canceled_Func (funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);
            WithRetryT2_Canceled_Delay(funcFactory, delayHandlerFactory, withRetry, invoke, observeFuncDelay, (d, r, e) => d.Invoking += Expect.AlternatingAsc(r, e), passResultHandler: true);
        }
    }
}
