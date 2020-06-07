using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP4;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test2()
        {
            double e = 2;
            double res = Program.ChangeDiapason(1, 1.05, 1.1, e);
            Assert.AreEqual(res, 1.05);
        }
        [TestMethod]
        public void Test1()
        {
            double e = 1;
            double res = Program.ChangeDiapason(1, 1.05, 1.1, e);
            Assert.AreEqual(res, 1.05);
        }
        [TestMethod]
        public void Test0005()
        {
            double e = 0.005;
            double res = Program.ChangeDiapason(1, 1.05, 1.1, e);
            Assert.AreEqual(res, 1.0453125);
        }
        [TestMethod]
        public void Test0001()
        {
            double e = 0.001;
            double res = Program.ChangeDiapason(1, 1.05, 1.1, e);
            Assert.AreEqual(res, 1.044921875);
        }
        [TestMethod]
        public void CheckDeviationTrue1()
        {
            double e = 0.5;
            bool res = Program.CheckDeviation(e, 0.24);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void CheckDeviationTrue2()
        {
            double e = 0.5;
            bool res = Program.CheckDeviation(e, -0.4);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void CheckDeviationTrue3()
        {
            double e = 0.6;
            bool res = Program.CheckDeviation(e, 0.6);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void CheckDeviationFalse1()
        {
            double e = 1.3;
            bool res = Program.CheckDeviation(e, 3.7);
            Assert.AreEqual(res, false);
        }
        [TestMethod]
        public void CheckDeviationFalse2()
        {
            double e = 1.3;
            bool res = Program.CheckDeviation(e, -1.4);
            Assert.AreEqual(res, false);
        }
    }
}
