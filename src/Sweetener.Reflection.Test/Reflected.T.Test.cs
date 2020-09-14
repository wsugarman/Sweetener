using System;
using System.Globalization;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reflection.Test
{
    [TestClass]
    public class ReflectedTest
    {
        [TestMethod]
        public void GetMember()
        {
            TestRecord r = new TestRecord
            {
                InternalObject = -1L,
                InternalString = "foo",
                PublicBool     = true,
                PublicInt      = 42,
            };

            r.SetPrivateChar('F');
            r.SetPrivateObject(TimeSpan.FromSeconds(5));

            // Validate Getter
            dynamic actual = new Reflected<TestRecord>(r);
            Assert.ThrowsException<RuntimeBinderException>(() => actual.Unused);

            Assert.AreEqual(-1L                    , actual.InternalObject);
            Assert.AreEqual("foo"                  , actual.InternalString);
            Assert.AreEqual(true                   , actual.PublicBool    );
            Assert.AreEqual(42                     , actual.PublicInt     );
            Assert.AreEqual(TimeSpan.FromSeconds(5), actual._privateObject);
            Assert.AreEqual('F'                    , actual._privateChar  );
        }

        [TestMethod]
        public void SetMember()
        {
            TestRecord r = new TestRecord
            {
                InternalObject = -1L,
                InternalString = "foo",
                PublicBool     = true,
                PublicInt      = 42,
            };

            r.SetPrivateChar('F');
            r.SetPrivateObject(TimeSpan.FromSeconds(5));

            // Validate
            Assert.AreEqual(-1L                    , r.InternalObject    );
            Assert.AreEqual("foo"                  , r.InternalString    );
            Assert.AreEqual(true                   , r.PublicBool        );
            Assert.AreEqual(42                     , r.PublicInt         );
            Assert.AreEqual(TimeSpan.FromSeconds(5), r.GetPrivateObject());
            Assert.AreEqual('F'                    , r.GetPrivateChar  ());

            // Use Setter
            dynamic actual = new Reflected<TestRecord>(r);
            Assert.ThrowsException<RuntimeBinderException>(() => actual.Unused = 1);
            Assert.ThrowsException<RuntimeBinderException>(() => actual._privateChar = "not a char");

            actual.InternalObject = null;
            actual.InternalString = "bar";
            actual.PublicBool     = false;
            actual.PublicInt      = 12345;
            actual._privateObject = Guid.Empty;
            actual._privateChar   = 'p';

            // Re-Validate
            Assert.AreEqual(null      , r.InternalObject    );
            Assert.AreEqual("bar"     , r.InternalString    );
            Assert.AreEqual(false     , r.PublicBool        );
            Assert.AreEqual(12345     , r.PublicInt         );
            Assert.AreEqual(Guid.Empty, r.GetPrivateObject());
            Assert.AreEqual('p'       , r.GetPrivateChar  ());
        }

        [TestMethod]
        public void InvokeMember()
        {
            dynamic actual = new Reflected<StatefulObject>(new StatefulObject(42));

            // Validate
            Assert.ThrowsException<RuntimeBinderException>(() => actual.NonexistentMethod());                        // Method name doesn't exist
            Assert.ThrowsException<RuntimeBinderException>(() => actual.GetSecret("foo"));                           // Wrong number of args
            Assert.ThrowsException<RuntimeBinderException>(() => actual.TransformSecret(1, 1.0));                    // Wrong argument type
            Assert.ThrowsException<RuntimeBinderException>(() => actual.TransformSecret(slope: 1, translations: 2)); // Wrong argument names

            Assert.AreEqual( 42    , actual.GetSecret());
            Assert.AreEqual( 42    , actual.TransformSecret());
            Assert.AreEqual( 84    , actual.TransformSecret(2));
            Assert.AreEqual(100    , actual.TransformSecret(2, 16));
            Assert.AreEqual(127    , actual.TransformSecret(translation: 1, slope: 3));
            Assert.AreEqual("42"   , actual.ToString());
            Assert.AreEqual("42.00", actual.ToString("F"));
            Assert.AreEqual("42,00", actual.ToString("F", CultureInfo.GetCultureInfo("fr-FR")));
            Assert.AreEqual("42!"  , actual.Echo("!"));
        }

        [TestMethod]
        public void BinaryOperation()
        {
            dynamic dynamicInt         = new Reflected<int>(2);
            dynamic dynamicNullableInt = new Reflected<int?>(4);
            dynamic dynamicTimeSpan    = new Reflected<TimeSpan>(TimeSpan.FromHours(10));
            dynamic dynamicString      = new Reflected<string>("Hello");
            dynamic dynamicUdt         = new Reflected<StatefulObject>(new StatefulObject(42));

            Assert.ThrowsException<RuntimeBinderException>(() => dynamicUdt - new StatefulObject(42)); // Non-existant operator
            Assert.ThrowsException<RuntimeBinderException>(() => dynamicUdt + 10);                     // Wrong type argument

            Assert.AreEqual(0                     , dynamicInt - 2);
            Assert.AreEqual(8                     , dynamicNullableInt * 2);
            Assert.AreEqual(TimeSpan.FromHours(11), dynamicTimeSpan + TimeSpan.FromHours(1));
            Assert.AreEqual("Hello World"         , dynamicString + " World");
            Assert.AreEqual(true                  , dynamicUdt < 24);
        }

        private sealed class TestRecord
        {
            public int PublicInt { get; set; }

            internal string? InternalString { get; set; }

            private object? _privateObject { get; set; }

            public bool PublicBool;

            internal object? InternalObject;

            private char _privateChar;

            public char GetPrivateChar()
                => _privateChar;

            public void SetPrivateChar(char c)
                => _privateChar = c;

            public object? GetPrivateObject()
                => _privateObject;

            public void SetPrivateObject(object? obj)
                => _privateObject = obj;
        }

        private sealed class StatefulObject
        {
            private int _secret;

            public StatefulObject(int secret)
                => _secret = secret;

            // Methods
            private long GetSecret()
                => _secret;

            internal long TransformSecret(int slope = 1, int translation = 0)
                => _secret * slope + translation;

            public override string ToString()
                => _secret.ToString(CultureInfo.InvariantCulture);

            public string ToString(string? format)
                => _secret.ToString(format, CultureInfo.InvariantCulture);

            public string ToString(string? format, IFormatProvider? provider)
                => _secret.ToString(format, provider);

            private object Echo(object? obj)
                => _secret.ToString(CultureInfo.InvariantCulture) + obj?.ToString();

            // Unary Operators
            public static StatefulObject? operator ++(StatefulObject? obj)
            {
                if (obj == null)
                    return null;

                obj._secret++;
                return obj;
            }

            // Binary Operators
            public static StatefulObject? operator +(StatefulObject? x, StatefulObject? y)
                => x == null && y == null ? null : new StatefulObject((x?._secret).GetValueOrDefault() + (y?._secret).GetValueOrDefault());

            public static bool operator <(StatefulObject obj, IComparable<int>? x)
                => x == null ? false : x.CompareTo(obj._secret) < 0;

            public static bool operator >(StatefulObject obj, IComparable<int>? x)
                => x == null ? false : x.CompareTo(obj._secret) > 0;
        }
    }
}
