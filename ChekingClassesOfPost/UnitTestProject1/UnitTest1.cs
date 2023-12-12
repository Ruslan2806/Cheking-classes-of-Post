using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diskretka;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("10101011");
            bool[] result = {false, true, false, false, false};
            Assert.AreEqual(ChekingClassesOfPost.AreEqualArayBool(input, result), true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("10100100");
            bool[] result = { false, false, false, false, false };
            Assert.AreEqual(ChekingClassesOfPost.AreEqualArayBool(input, result), true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("01111011");
            bool[] result = { true, true, false, false, false };
            Assert.AreEqual(ChekingClassesOfPost.AreEqualArayBool(input, result), true);
        }
    }
}
