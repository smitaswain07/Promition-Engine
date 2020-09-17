using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
            int total = p.CalculateTotal(1, 1, 1, 0);
            Assert.AreEqual(100, total);
        }
        [TestMethod]
        public void FirstPromotionApplied_threeA130()
        {
            Program p = new Program();
            int total = p.CalculateTotal(5, 5, 1, 0);
            Assert.AreEqual(400, total);
        }
        [TestMethod]
        public void SecondPromotionApplied_CandD30()
        {
            Program p = new Program();
            int total = p.CalculateTotal(2, 1, 1, 1);
            Assert.AreEqual(160, total);
        }
        [TestMethod]
        public void ThirdPromotionApplied_2B45()
        {
            Program p = new Program();
            int total = p.CalculateTotal(2, 2, 0, 1);
            Assert.AreEqual(160, total);
        }
    }
}
