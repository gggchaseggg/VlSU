using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestisTrue()
        {
            Assert.AreEqual(true, ForTest.isTrue("true"));
            Assert.AreEqual(false, ForTest.isTrue("false"));
        }

        [Test]
        public void TestisTrueInt()
        {
            Assert.AreEqual(true, ForTest.isTrue(1));
            Assert.AreEqual(false, ForTest.isTrue(0));
            Assert.AreEqual(false, ForTest.isTrue(-1));
            Assert.AreEqual(false, ForTest.isTrue(2));
        }

        [Test]
        public void TestisTrueBool()
        {
            Assert.AreEqual(true, ForTest.isTrue(true));
            Assert.AreEqual(false, ForTest.isTrue(false));
            Assert.AreEqual(true, ForTest.isTrue(1 > 0));
            Assert.AreEqual(false, ForTest.isTrue(2 == 3));
        }

        [Test]
        public void TestisTrueException()
        {
            Assert.That(() => ForTest.isTrue("Exception"), Throws.ArgumentException);
        }

    }
}
