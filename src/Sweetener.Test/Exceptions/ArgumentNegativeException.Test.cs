﻿// Copyright © 2021 William Sugarman. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Test
{
    [TestClass]
    public class ArgumentNegativeExceptionTest
    {
        [TestMethod]
        public void Ctor()
        {
            ArgumentNegativeException exception = new ArgumentNegativeException();

            Assert.AreEqual(null                      , exception.ActualValue   );
            Assert.AreEqual(null                      , exception.InnerException);
            Assert.AreEqual(SR.ArgumentNegativeMessage, exception.Message       );
            Assert.AreEqual(null                      , exception.ParamName     );
        }

        [TestMethod]
        public void Ctor_ParameterName()
        {
            ArgumentNegativeException exception = new ArgumentNegativeException("parameter1");

            Assert.AreEqual(null        , exception.ActualValue   );
            Assert.AreEqual(null        , exception.InnerException);
            Assert.AreEqual("parameter1", exception.ParamName     );

            // There will be an additional line concerning the parameter name
            Assert.IsTrue(exception.Message.Contains(SR.ArgumentNegativeMessage, StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Ctor_Message_Message_InnerException()
        {
            Exception innerException = new FormatException();
            ArgumentNegativeException exception = new ArgumentNegativeException("Hello World", innerException);

            Assert.AreEqual(null          , exception.ActualValue   );
            Assert.AreSame (innerException, exception.InnerException);
            Assert.AreEqual("Hello World" , exception.Message       );
            Assert.AreEqual(null          , exception.ParamName     );
        }

        [TestMethod]
        public void Ctor_ParameterName_Message()
        {
            ArgumentNegativeException exception = new ArgumentNegativeException("parameter1", "Hello World");

            Assert.AreEqual(null        , exception.ActualValue   );
            Assert.AreEqual(null        , exception.InnerException);
            Assert.AreEqual("parameter1", exception.ParamName     );

            // Message will contain both the value from the ctor and a statement about the parameter
            Assert.IsTrue(exception.Message.Contains("Hello World"));
            Assert.IsTrue(exception.Message.Contains("parameter1" ));
        }

        [TestMethod]
        public void Ctor_ParameterName_ActualValue_Message()
        {
            object actualValue = -12345;
            ArgumentNegativeException exception = new ArgumentNegativeException("parameter1", actualValue, "Hello World");

            Assert.AreSame (actualValue , exception.ActualValue   );
            Assert.AreEqual(null        , exception.InnerException);
            Assert.AreEqual("parameter1", exception.ParamName     );

            // Message will contain the value from the ctor, a statement about the parameter, and the actual value
            Assert.IsTrue(exception.Message.Contains("Hello World"));
            Assert.IsTrue(exception.Message.Contains("parameter1" ));
            Assert.IsTrue(exception.Message.Contains("-12345"     ));
        }

        [TestMethod]
        public void Ctor_SerializationInfo_StreamingContext()
        {
            ArgumentNegativeException? after;
            ArgumentNegativeException before = new ArgumentNegativeException("parameter1", -12345, "Hello World");

            using (MemoryStream buffer = new MemoryStream())
            {
#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(buffer, before);

                Assert.IsTrue(buffer.Position > 0L);

                buffer.Seek(0, SeekOrigin.Begin);
                after = formatter.Deserialize(buffer) as ArgumentNegativeException;
#pragma warning restore SYSLIB0011
            }

            Assert.IsNotNull(after);
            Assert.AreEqual(-12345      , after!.ActualValue  );
            Assert.AreEqual(null        , after.InnerException);
            Assert.AreEqual("parameter1", after.ParamName     );

            // Message will contain the value from the ctor, a statement about the parameter, and the actual value
            Assert.IsTrue(after.Message.Contains("Hello World"));
            Assert.IsTrue(after.Message.Contains("parameter1" ));
            Assert.IsTrue(after.Message.Contains("-12345"     ));
        }
    }
}
