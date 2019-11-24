// Generated from ReliableFunc.Test.tt
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    [TestClass]
    public sealed class ReliableFunc4Test : ReliableDelegateTest<string>
    {
        private static readonly Func<ReliableFunc<int, string, double, long, string>, Func<int, string, double, long, string>> s_getFunc = DynamicGetter.ForField<ReliableFunc<int, string, double, long, string>, Func<int, string, double, long, string>>("_func");

        [TestMethod]
        public void Ctor_DelayPolicy()
        {
            Func<int, string, double, long, string> func = (arg1, arg2, arg3, arg4) => "Hello World";
            ExceptionPolicy          exceptionPolicy = ExceptionPolicies.Retry<IOException>();
            FuncProxy<int, TimeSpan> delayPolicy     = new FuncProxy<int, TimeSpan>(i => Constants.Delay);

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(null, Retries.Infinite, exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableFunc<int, string, double, long, string>(func, -2              , exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, null           , delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, exceptionPolicy, (DelayPolicy)null ));

            // Create a ReliableFunc and validate
            ReliableFunc<int, string, double, long, string> actual = new ReliableFunc<int, string, double, long, string>(func, 37, exceptionPolicy, delayPolicy.Invoke);

            // DelayPolicies are wrapped in ComplexDelayPolicies, so we can only validate the correct assignment by invoking the policy
            Ctor(actual, func, 37, ReliableDelegate<string>.DefaultResultPolicy, exceptionPolicy, actualPolicy =>
            {
                delayPolicy.Invoking += (i, c) => Assert.AreEqual(i, 42);
                Assert.AreEqual(Constants.Delay, actualPolicy(42, "foo", new ArgumentOutOfRangeException()));
                Assert.AreEqual(1, delayPolicy.Calls);
            });
        }

        [TestMethod]
        public void Ctor_ComplexDelayPolicy()
        {
            Func<int, string, double, long, string> func = (arg1, arg2, arg3, arg4) => "Hello World";
            ExceptionPolicy            exceptionPolicy    = ExceptionPolicies.Retry<IOException>();
            ComplexDelayPolicy<string> complexDelayPolicy = (i, r, e) => TimeSpan.FromSeconds(3);

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(null, Retries.Infinite, exceptionPolicy, complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableFunc<int, string, double, long, string>(func, -2              , exceptionPolicy, complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, null           , complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, exceptionPolicy, (ComplexDelayPolicy<string>)null));

            // Create a ReliableFunc and validate
            ReliableFunc<int, string, double, long, string> actual = new ReliableFunc<int, string, double, long, string>(func, 37, exceptionPolicy, complexDelayPolicy);
            Ctor(actual, func, 37, ReliableDelegate<string>.DefaultResultPolicy, exceptionPolicy, complexDelayPolicy);
        }

        [TestMethod]
        public void Ctor_ResultPolicy_DelayPolicy()
        {
            Func<int, string, double, long, string> func = (arg1, arg2, arg3, arg4) => "Hello World";
            ResultPolicy<string>     resultPolicy    = r => ResultKind.Retryable;
            ExceptionPolicy          exceptionPolicy = ExceptionPolicies.Retry<IOException>();
            FuncProxy<int, TimeSpan> delayPolicy     = new FuncProxy<int, TimeSpan>(i => Constants.Delay);

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(null, Retries.Infinite, resultPolicy, exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableFunc<int, string, double, long, string>(func, -2              , resultPolicy, exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, null        , exceptionPolicy, delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, resultPolicy, null           , delayPolicy.Invoke));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, resultPolicy, exceptionPolicy, (DelayPolicy)null ));

            // Create a ReliableFunc and validate
            ReliableFunc<int, string, double, long, string> actual = new ReliableFunc<int, string, double, long, string>(func, 37, resultPolicy, exceptionPolicy, delayPolicy.Invoke);

            // DelayPolicies are wrapped in ComplexDelayPolicies, so we can only validate the correct assignment by invoking the policy
            Ctor(actual, func, 37, resultPolicy, exceptionPolicy, actualPolicy =>
            {
                delayPolicy.Invoking += (i, c) => Assert.AreEqual(i, 42);
                Assert.AreEqual(Constants.Delay, actualPolicy(42, "foo", new ArgumentOutOfRangeException()));
                Assert.AreEqual(1, delayPolicy.Calls);
            });
        }

        [TestMethod]
        public void Ctor_ResultPolicy_ComplexDelayPolicy()
        {
            Func<int, string, double, long, string> func = (arg1, arg2, arg3, arg4) => "Hello World";
            ResultPolicy<string>       resultPolicy       = r => r == "foo" ? ResultKind.Successful : ResultKind.Fatal;
            ExceptionPolicy            exceptionPolicy    = ExceptionPolicies.Fail<FormatException>();
            ComplexDelayPolicy<string> complexDelayPolicy = (i, r, e) => TimeSpan.Zero;

            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(null, Retries.Infinite, resultPolicy, exceptionPolicy, complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ReliableFunc<int, string, double, long, string>(func, -2              , resultPolicy, exceptionPolicy, complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, null        , exceptionPolicy, complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, resultPolicy, null           , complexDelayPolicy              ));
            Assert.ThrowsException<ArgumentNullException      >(() => new ReliableFunc<int, string, double, long, string>(func, Retries.Infinite, resultPolicy, exceptionPolicy, (ComplexDelayPolicy<string>)null));

            // Create a ReliableFunc and validate
            ReliableFunc<int, string, double, long, string> actual = new ReliableFunc<int, string, double, long, string>(func, 37, resultPolicy, exceptionPolicy, complexDelayPolicy);
            Ctor(actual, func, 37, resultPolicy, exceptionPolicy, complexDelayPolicy);
        }

        private void Ctor(
            ReliableFunc<int, string, double, long, string> reliableFunc,
            Func<int, string, double, long, string>         expectedFunc,
            int                        expectedMaxRetries,
            ResultPolicy<string>       expectedResultPolicy,
            ExceptionPolicy            expectedExceptionPolicy,
            ComplexDelayPolicy<string> expectedDelayPolicy)
            => Ctor(reliableFunc, expectedFunc, expectedMaxRetries, expectedResultPolicy, expectedExceptionPolicy, actual => Assert.AreSame(expectedDelayPolicy, actual));

        private void Ctor(
            ReliableFunc<int, string, double, long, string> reliableFunc,
            Func<int, string, double, long, string>         expectedFunc,
            int                                expectedMaxRetries,
            ResultPolicy<string>               expectedResultPolicy,
            ExceptionPolicy                    expectedExceptionPolicy,
            Action<ComplexDelayPolicy<string>> validateDelayPolicy)
        {
            Assert.AreEqual(expectedMaxRetries, reliableFunc.MaxRetries);

            Assert.AreSame(expectedFunc           , s_getFunc           (reliableFunc));
            Assert.AreSame(expectedResultPolicy   , s_getResultPolicy   (reliableFunc));
            Assert.AreSame(expectedExceptionPolicy, s_getExceptionPolicy(reliableFunc));

            validateDelayPolicy(s_getDelayPolicy(reliableFunc));
        }

        [TestMethod]
        public void Invoke_NoCancellationToken()
            => Invoke((reliableFunc, arg1, arg2, arg3, arg4) => reliableFunc.Invoke(arg1, arg2, arg3, arg4));
        
        [TestMethod]
        public void Invoke_CancellationToken()
        {
            using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                Invoke((reliableFunc, arg1, arg2, arg3, arg4) => reliableFunc.Invoke(arg1, arg2, arg3, arg4, tokenSource.Token));
        
            // Ensure CancellationToken prevents additional retry
            Invoke_Canceled((reliableFunc, arg1, arg2, arg3, arg4, token) => reliableFunc.Invoke(arg1, arg2, arg3, arg4, token));
        }

        [TestMethod]
        public void TryInvoke_NoCancellationToken()
        {
            TryInvoke(TryInvokeFunc);

            static bool TryInvokeFunc(ReliableFunc<int, string, double, long, string> reliableFunc, int arg1, string arg2, double arg3, long arg4, out string result)
                => reliableFunc.TryInvoke(arg1, arg2, arg3, arg4, out result);
        }

        [TestMethod]
        public void TryInvoke_CancellationToken()
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            TryInvoke(TryInvokeFunc);

            // Ensure CancellationToken prevents additional retry
            Invoke_Canceled((reliableFunc, arg1, arg2, arg3, arg4, token) => reliableFunc.TryInvoke(arg1, arg2, arg3, arg4, token, out string _));

            bool TryInvokeFunc(ReliableFunc<int, string, double, long, string> reliableFunc, int arg1, string arg2, double arg3, long arg4, out string result)
                => reliableFunc.TryInvoke(arg1, arg2, arg3, arg4, tokenSource.Token, out result);
        }

        private void Invoke(Func<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> invoke)
        {
            // Success
            Invoke_Success                ((f, arg1, arg2, arg3, arg4, r) => Assert.AreEqual(r, invoke(f, arg1, arg2, arg3, arg4)));
            Invoke_EventualSuccess        ((f, arg1, arg2, arg3, arg4, r) => Assert.AreEqual(r, invoke(f, arg1, arg2, arg3, arg4)));

            // Failure (Result)
            Invoke_Failure_Result         ((f, arg1, arg2, arg3, arg4, r) => Assert.AreEqual(r, invoke(f, arg1, arg2, arg3, arg4)));
            Invoke_EventualFailure_Result ((f, arg1, arg2, arg3, arg4, r) => Assert.AreEqual(r, invoke(f, arg1, arg2, arg3, arg4)));
            Invoke_RetriesExhausted_Result((f, arg1, arg2, arg3, arg4, r) => Assert.AreEqual(r, invoke(f, arg1, arg2, arg3, arg4)));

            // Failure (Exception)
            Invoke_Failure_Exception         ((f, arg1, arg2, arg3, arg4, t) => Assert.That.ThrowsException(() => invoke(f, arg1, arg2, arg3, arg4), t));
            Invoke_EventualFailure_Exception ((f, arg1, arg2, arg3, arg4, t) => Assert.That.ThrowsException(() => invoke(f, arg1, arg2, arg3, arg4), t));
            Invoke_RetriesExhausted_Exception((f, arg1, arg2, arg3, arg4, t) => Assert.That.ThrowsException(() => invoke(f, arg1, arg2, arg3, arg4), t));
        }

        private void TryInvoke(TryFunc<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> tryInvoke)
        {
            Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertSuccess =
                (f, arg1, arg2, arg3, arg4, r) =>
                {
                    Assert.IsTrue(tryInvoke(f, arg1, arg2, arg3, arg4, out string actual));
                    Assert.AreEqual(r, actual);
                };

            Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertResultFailure =
                (f, arg1, arg2, arg3, arg4, r) =>
                {
                    Assert.IsFalse(tryInvoke(f, arg1, arg2, arg3, arg4, out string actual));
                    Assert.AreEqual(default, actual);
                };

            Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, Type> assertExceptionFailure =
                (f, arg1, arg2, arg3, arg4, r) =>
                {
                    Assert.IsFalse(tryInvoke(f, arg1, arg2, arg3, arg4, out string actual));
                    Assert.AreEqual(default, actual);
                };

            // Success
            Invoke_Success                (assertSuccess);
            Invoke_EventualSuccess        (assertSuccess);

            // Failure (Result)
            Invoke_Failure_Result         (assertResultFailure);
            Invoke_EventualFailure_Result (assertResultFailure);
            Invoke_RetriesExhausted_Result(assertResultFailure);

            // Failure (Exception)
            Invoke_Failure_Exception         (assertExceptionFailure);
            Invoke_EventualFailure_Exception (assertExceptionFailure);
            Invoke_RetriesExhausted_Exception(assertExceptionFailure);
        }

        private void Invoke_Success(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertInvoke)
        {
            // Create a "successful" user-defined function
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => "Success");

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Success" ? ResultKind.Successful : ResultKind.Fatal);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>();
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>();

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            resultPolicy    .Invoking += Expect.Result("Success");
            exceptionPolicy .Invoking += Expect.Nothing<Exception>();
            delayPolicy     .Invoking += Expect.Nothing<int, string, Exception>();
            retryHandler    .Invoking += Expect.Nothing<int, string, Exception>();
            failedHandler   .Invoking += Expect.Nothing<string, Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, "Success");

            // Validate the number of calls
            Assert.AreEqual(1, func            .Calls);
            Assert.AreEqual(1, resultPolicy    .Calls);
            Assert.AreEqual(0, exceptionPolicy .Calls);
            Assert.AreEqual(0, delayPolicy     .Calls);
            Assert.AreEqual(0, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_Failure_Result(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertInvoke)
        {
            // Create an "unsuccessful" user-defined function that returns a fatal result
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => "Failure");

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Failure" ? ResultKind.Fatal : ResultKind.Successful);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>();
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>();

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            resultPolicy    .Invoking += Expect.Result("Failure");
            exceptionPolicy .Invoking += Expect.Nothing<Exception>();
            delayPolicy     .Invoking += Expect.Nothing<int, string, Exception>();
            retryHandler    .Invoking += Expect.Nothing<int, string, Exception>();
            failedHandler   .Invoking += Expect.OnlyResult("Failure");
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, "Failure");

            // Validate the number of calls
            Assert.AreEqual(1, func            .Calls);
            Assert.AreEqual(1, resultPolicy    .Calls);
            Assert.AreEqual(0, exceptionPolicy .Calls);
            Assert.AreEqual(0, delayPolicy     .Calls);
            Assert.AreEqual(0, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_Failure_Exception(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, Type> assertInvoke)
        {
            // Create an "unsuccessful" user-defined function that throws a fatal exception
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => throw new InvalidOperationException());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>();
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Fail<InvalidOperationException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>();

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            resultPolicy    .Invoking += Expect.Nothing<string>();
            exceptionPolicy .Invoking += Expect.Exception(typeof(InvalidOperationException));
            delayPolicy     .Invoking += Expect.Nothing<int, string, Exception>();
            retryHandler    .Invoking += Expect.Nothing<int, string, Exception>();
            failedHandler   .Invoking += Expect.OnlyException<string>(typeof(InvalidOperationException));
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, typeof(InvalidOperationException));

            // Validate the number of calls
            Assert.AreEqual(1, func            .Calls);
            Assert.AreEqual(0, resultPolicy    .Calls);
            Assert.AreEqual(1, exceptionPolicy .Calls);
            Assert.AreEqual(0, delayPolicy     .Calls);
            Assert.AreEqual(0, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_EventualSuccess(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertInvoke)
        {
            // Create a user-defined function that eventually succeeds after a transient result and exception
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException>("Retry", "Success", 2);
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r =>
                r switch
                {
                    "Retry"   => ResultKind.Retryable,
                    "Success" => ResultKind.Successful,
                    _         => ResultKind.Fatal,
                });
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.Arguments<int, string, double, long>(Arguments.Validate);
            resultPolicy    .Invoking += Expect.Results("Retry", "Success", 1);
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<string, Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, "Success");

            // Validate the number of calls
            Assert.AreEqual(3, func            .Calls);
            Assert.AreEqual(2, resultPolicy    .Calls);
            Assert.AreEqual(1, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_EventualFailure_Result(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertInvoke)
        {
            // Create a user-defined function that eventually fails after a transient result and exception
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException>("Retry", "Failure", 2);
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r =>
                r switch
                {
                    "Retry"   => ResultKind.Retryable,
                    "Failure" => ResultKind.Fatal,
                    _         => ResultKind.Successful,
                });
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, Constants.MinDelay);
            resultPolicy    .Invoking += Expect.Results("Retry", "Failure", 1);
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.OnlyResult("Failure");
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, "Failure");

            // Validate the number of calls
            Assert.AreEqual(3, func            .Calls);
            Assert.AreEqual(2, resultPolicy    .Calls);
            Assert.AreEqual(1, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_EventualFailure_Exception(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, Type> assertInvoke)
        {
            // Create a user-defined function that eventually fails after a transient result and exception
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException, InvalidOperationException>("Retry", 2);
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Retry" ? ResultKind.Retryable : ResultKind.Successful);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, Constants.MinDelay);
            resultPolicy    .Invoking += Expect.Result("Retry");
            exceptionPolicy .Invoking += Expect.Exceptions(typeof(IOException), typeof(InvalidOperationException), 1);
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.OnlyException<string>(typeof(InvalidOperationException));
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, typeof(InvalidOperationException));

            // Validate the number of calls
            Assert.AreEqual(3, func            .Calls);
            Assert.AreEqual(1, resultPolicy    .Calls);
            Assert.AreEqual(2, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(1, failedHandler   .Calls);
            Assert.AreEqual(0, exhaustedHandler.Calls);
        }

        private void Invoke_RetriesExhausted_Result(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, string> assertInvoke)
        {
            // Create a user-defined function that eventually exhausts the maximum number of retries after transient results and exceptions
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException>("Retry");
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Retry" ? ResultKind.Retryable : ResultKind.Successful);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                3, // Exception, Result, Exception, Result, ...
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, Constants.MinDelay);
            resultPolicy    .Invoking += Expect.Result("Retry");
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<string, Exception>();
            exhaustedHandler.Invoking += Expect.OnlyResult("Retry");

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, "Retry");

            // Validate the number of calls
            Assert.AreEqual(4, func            .Calls);
            Assert.AreEqual(2, resultPolicy    .Calls);
            Assert.AreEqual(2, exceptionPolicy .Calls);
            Assert.AreEqual(3, delayPolicy     .Calls);
            Assert.AreEqual(3, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(1, exhaustedHandler.Calls);
        }

        private void Invoke_RetriesExhausted_Exception(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, Type> assertInvoke)
        {
            // Create a user-defined function that eventually exhausts the maximum number of retries after transient results and exceptions
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException>("Retry");
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Retry" ? ResultKind.Retryable : ResultKind.Successful);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                2, // Exception, Result, Exception, ...
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, Constants.MinDelay);
            resultPolicy    .Invoking += Expect.Result("Retry");
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<string, Exception>();
            exhaustedHandler.Invoking += Expect.OnlyException<string>(typeof(IOException));

            // Invoke
            assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, typeof(IOException));

            // Validate the number of calls
            Assert.AreEqual(3, func            .Calls);
            Assert.AreEqual(1, resultPolicy    .Calls);
            Assert.AreEqual(2, exceptionPolicy .Calls);
            Assert.AreEqual(2, delayPolicy     .Calls);
            Assert.AreEqual(2, retryHandler    .Calls);
            Assert.AreEqual(0, failedHandler   .Calls);
            Assert.AreEqual(1, exhaustedHandler.Calls);
        }

        private void Invoke_Canceled(Action<ReliableFunc<int, string, double, long, string>, int, string, double, long, CancellationToken> assertInvoke)
        {
            using ManualResetEvent        cancellationTrigger = new ManualResetEvent(false);
            using CancellationTokenSource tokenSource         = new CancellationTokenSource();

            // Create an "unsuccessful" user-defined function that continues to fail with transient results and exceptions until it's canceled
            Func<string> flakyFunc = FlakyFunc.Create<string, IOException>("Retry");
            FuncProxy<int, string, double, long, string> func = new FuncProxy<int, string, double, long, string>((arg1, arg2, arg3, arg4) => flakyFunc());

            // Declare the various policy and event handler proxies
            FuncProxy<string, ResultKind>               resultPolicy    = new FuncProxy<string, ResultKind>(r => r == "Retry" ? ResultKind.Retryable : ResultKind.Successful);
            FuncProxy<Exception, bool>                  exceptionPolicy = new FuncProxy<Exception, bool>(ExceptionPolicies.Retry<IOException>().Invoke);
            FuncProxy<int, string, Exception, TimeSpan> delayPolicy     = new FuncProxy<int, string, Exception, TimeSpan>((i, r, e) => Constants.Delay);

            ActionProxy<int, string, Exception> retryHandler     = new ActionProxy<int, string, Exception>();
            ActionProxy<string, Exception>      failedHandler    = new ActionProxy<string, Exception>();
            ActionProxy<string, Exception>      exhaustedHandler = new ActionProxy<string, Exception>();

            // Create ReliableFunc
            ReliableFunc<int, string, double, long, string> reliableFunc = new ReliableFunc<int, string, double, long, string>(
                func.Invoke,
                Retries.Infinite,
                resultPolicy   .Invoke,
                exceptionPolicy.Invoke,
                delayPolicy    .Invoke);

            reliableFunc.Retrying         += retryHandler    .Invoke;
            reliableFunc.Failed           += failedHandler   .Invoke;
            reliableFunc.RetriesExhausted += exhaustedHandler.Invoke;

            // Define expectations
            func            .Invoking += Expect.ArgumentsAfterDelay<int, string, double, long>(Arguments.Validate, Constants.MinDelay);
            resultPolicy    .Invoking += Expect.Result("Retry");
            exceptionPolicy .Invoking += Expect.Exception(typeof(IOException));
            delayPolicy     .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            retryHandler    .Invoking += Expect.AlternatingAsc("Retry", typeof(IOException));
            failedHandler   .Invoking += Expect.Nothing<string, Exception>();
            exhaustedHandler.Invoking += Expect.Nothing<string, Exception>();

            // Trigger the event upon retry
            retryHandler    .Invoking += (i, r, e, c) => cancellationTrigger.Set();

            // Create a task whose job is to cancel the invocation after at least 1 retry
            Task cancellationTask = Task.Factory.StartNew((state) =>
            {
                (ManualResetEvent e, CancellationTokenSource s) = ((ManualResetEvent, CancellationTokenSource))state;
                e.WaitOne();
                s.Cancel();

            }, (cancellationTrigger, tokenSource));

            // Begin the invocation
            Assert.That.ThrowsException<OperationCanceledException>(() => assertInvoke(reliableFunc, 42, "foo", 3.14D, 1000L, tokenSource.Token));

            // Validate the number of calls
            int calls      = func.Calls;
            int results    = calls / 2;
            int exceptions = calls - results;
            Assert.IsTrue(calls > 1);

            Assert.AreEqual(results   , resultPolicy    .Calls);
            Assert.AreEqual(exceptions, exceptionPolicy .Calls);
            Assert.AreEqual(calls     , delayPolicy     .Calls);
            Assert.AreEqual(calls - 1 , retryHandler    .Calls);
            Assert.AreEqual(0         , failedHandler   .Calls);
            Assert.AreEqual(0         , exhaustedHandler.Calls);
        }
    }
}
