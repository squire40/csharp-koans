using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutAsserts
    {
        private static readonly Int32 FILL_ME_IN = new Int32();
        private static readonly bool FILL_ME__IN;

        [TestMethod]
        public void AssertTruth()
        {
            Assert.IsTrue(true);   // Your long journey begins with a simple step.  We seek what's true, help us find it.
        }

        [TestMethod]
        public void AssertsShouldHaveMessages()
        {
            Assert.IsTrue(true, "This message should help you understand what failed. Please help us find truth.");
        }

        [TestMethod]
        public void AssertFalse()
        {
            Assert.IsFalse(false, "Truth comes in many forms. Here what is true should be false.");
        }

        [TestMethod]
        public void AssertEquality()
        {
            Assert.IsTrue(1 == 1, "Truth can be uncovered in boolean expressions when they are true.");
        }

        [TestMethod]
        public void AssertEqualityTheBetterWay()
        {
            var expectedValue = 2;
            var actualValue = 1 + 1;

            Assert.AreEqual(expectedValue, actualValue, "When your karma is broken it is more helpful to know what was expected and what it actually is.");
        }

        [TestMethod]
        public void AssertFail()
        {
            bool thePathToEnlightment = true;
            if (!thePathToEnlightment)
            {
                Assert.Fail("Taking an unfortunate code path breaks your karma. Change the path towards truth.");
            }
            
            Assert.IsTrue(thePathToEnlightment, "The path has been found.");
        }
    }
}
