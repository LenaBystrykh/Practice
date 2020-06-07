using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP3;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LeftDown()
        {
            double x = -0.5;
            double y = -0.2;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void LeftUp()
        {
            double x = -0.3;
            double y = 0.1;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void RightUp()
        {
            double x = 0.6;
            double y = 0.2;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void RightDown()
        {
            double x = 0.4;
            double y = -0.3;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void Bound1()
        {
            double x = 0;
            double y = 1;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void Bound2()
        {
            double x = -1;
            double y = 0;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void Bound3()
        {
            double x = 0;
            double y = -1;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void Bound4()
        {
            double x = 1;
            double y = 0;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void Centre()
        {
            double x = 0;
            double y = 0;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void OutsideRightUp()
        {
            double x = 7.1;
            double y = 10.2;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, false);
        }
        [TestMethod]
        public void OutsideRightDown()
        {
            double x = 8.7;
            double y = -5.1;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, false);
        }
        [TestMethod]
        public void OutsidLeftDown()
        {
            double x = -14.9;
            double y = -8.6;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, false);
        }
        [TestMethod]
        public void OutsideLeftUp()
        {
            double x = -17.3;
            double y = 11.4;
            bool res = Program.CheckDia(x, y);
            Assert.AreEqual(res, false);
        }
    }
}
