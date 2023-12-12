using Diskretka;

namespace TestProject1
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("10101011");
            bool[] result = { false, true, false, false, false };
            Assert.IsTrue(ChekingClassesOfPost.AreEqualArayBool(input, result) == true);
        }

        [Test]
        public void Test2()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("10100100");
            bool[] result = { false, false, false, false, false };
            Assert.IsTrue(ChekingClassesOfPost.AreEqualArayBool(input, result) == true);
        }

        [Test]
        public void Test3()
        {
            bool[] input = ChekingClassesOfPost.returnClassesOfPost("01111011");
            bool[] result = { true, true, false, false, false };
            Assert.IsTrue(ChekingClassesOfPost.AreEqualArayBool(input, result) == true);
        }
    }
}