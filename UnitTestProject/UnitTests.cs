using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PractiñeTask7.Program;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int max = 1;
            int[] comb = { 0, 1 };
            bool check = ThereAreOtherOptions(comb, max);
            Assert.AreEqual(check, false);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int max = 4;
            int[] comb = { 0, 1, 2, 3 };
            bool check = ThereAreOtherOptions(comb, max);
            Assert.AreEqual(check, true);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int max = 5;
            int[] comb = { 0, 1, 5 };
            int[] comb2 = { 0, 2, 3 };
            MakeNextCombination(comb, max);
            Assert.AreEqual(comb.ToString(), comb2.ToString());
        }
    }
}
