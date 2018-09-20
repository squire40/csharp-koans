using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutObjects
    {
        private object FILL_ME_IN = new Object();

        [TestMethod]
        public void EverythingIsAnObject()
        {
            Assert.AreEqual(true, 1 is Object);
            Assert.AreEqual(true, 1.5 is Object);
            Assert.AreEqual(true, "string" is Object);
            Assert.AreEqual(true, true is Object);
        }

        [TestMethod]
        public void ExceptNullIsNotAnObject()
        {
            Assert.AreEqual(false, null is Object);
        }

        [TestMethod]
        public void ObjectLiteralIsAnObject()
        {
            Assert.AreEqual(true, new { } is Object);
        }

        //TODO - finish remaining object tests from the RubyKoans AboutObjects
    }
}
