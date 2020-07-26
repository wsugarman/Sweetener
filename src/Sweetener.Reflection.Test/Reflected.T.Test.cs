using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reflection.Test
{
    [TestClass]
    public class ReflectedTest
    {
        [TestMethod]
        public void GetMember()
        {
            Secrets secrets = new Secrets();
            dynamic leakedData = new Reflected<Secrets>(secrets);

            Assert.AreEqual(17           , leakedData.Passcode );
            Assert.AreEqual("Hello World", leakedData._password);
        }

        [TestMethod]
        public void SetMember()
        {
            Secrets secrets = new Secrets();
            dynamic leakedData = new Reflected<Secrets>(secrets);

            leakedData.Passcode  = 42;
            leakedData._password = "Hello _phrase";

            Assert.AreEqual(42             , secrets.Get(SecretKind.Passcode));
            Assert.AreEqual("Hello _phrase", secrets.Get(SecretKind.Password));
        }

        [TestMethod]
        public void InvokeMember()
        {
            Secrets secrets = new Secrets();
            dynamic leakedData = new Reflected<Secrets>(secrets);

            leakedData.Delete();

            Assert.AreEqual(0 , secrets.Get(SecretKind.Passcode));
            Assert.AreEqual("", secrets.Get(SecretKind.Password));

            Assert.AreEqual("user@email.com", leakedData.Change("password"));
            Assert.AreEqual("user@email.com", secrets.UserName);
            Assert.AreEqual("password"      , secrets.Get(SecretKind.Password));

            Assert.AreEqual("first.last@email.com", leakedData.Change("password", "first.last@email.com"));
            Assert.AreEqual("first.last@email.com", secrets.UserName);
            Assert.AreEqual("password"            , secrets.Get(SecretKind.Password));
        }

        private sealed class Secrets
        {
            public string UserName { get; private set; } = "user@email.com";

            private int Passcode { get; set; } = 17;

            private string _password = "Hello World";

            private void Delete()
            {
                Passcode  = 0;
                _password = "";
            }

            private string Change(string password)
            {
                _password = password;
                return UserName;
            }

            private string Change(string password, string userName = "placeholder")
            {
                UserName = userName;
                _password = password;
                return UserName;
            }

            public object Get(SecretKind kind)
            {
                switch (kind)
                {
                    case SecretKind.Passcode: return Passcode;
                    case SecretKind.Password: return _password;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(kind));
                }
            }
        }

        private enum SecretKind
        {
            Passcode = 0,
            Password = 1,
        }
    }
}
