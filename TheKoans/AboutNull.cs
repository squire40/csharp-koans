using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    // In Corey's Ruby Koans, this is called AboutNil. We've renamed it to AboutNull to match the C# convention
    [TestClass]
    public class AboutNull : KoanHelper
    {
        [TestMethod]
        public void NilIsNotAnObject()
        {
            //not everything is an object
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(int)), "To quote from South Park's World of Warcraft episode: 'Can you kill that which has no life?'"); 
        }

        [TestMethod]
        public void NullIsNotAnInstanceOfObjectAndInvokingAMethodThrowsNullReferenceException()
        {
            Object nullReference = null;

            try
            {
                nullReference.GetHashCode();
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", exception.Message, "If you're still unsure, take a look at the name of this method...");
            }
        }

        [TestMethod]
        public void CheckingThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsTrue(obj == null);
        }

        [TestMethod]
        public void ABetterWayToCheckThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsNull(obj, "If only we had an object passed in as a parameter...");
        }

        [TestMethod]
        public void AWayNotToCheckThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsTrue(obj == null); // What do they want here?
        }


        // RJG Begin Under Construction

        // Passing Null Objects to C# Extension Methods... is allowed?!?!?
        // http://www.peteonsoftware.com/index.php/2012/06/21/c-extension-methods-on-null-objects/

        // RJG End
    }
}
