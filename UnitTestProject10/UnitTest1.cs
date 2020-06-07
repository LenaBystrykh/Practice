using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP10;

namespace UnitTestProject10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckPoint()
        {
            Point<double> point = new Point<double>(2.3);
            Assert.AreEqual(point.Data, 2.3);
        }
        [TestMethod]
        public void Check2Points()
        {
            Point<double> point = new Point<double>();
            point.Data = 3.7;
            Point<double> nextPoint = new Point<double>(7.1);
            point.Next = nextPoint;
            Assert.AreEqual(point.Next.Data, 7.1);
        }
        [TestMethod]
        public void CheckRndPoint()
        {
            bool empty = false;
            Random rnd = new Random();
            Point<double> point = new Point<double>(rnd);
            if ((double)point.Data == 0)
                empty = true;
            Assert.AreEqual(false, empty);
        }
        [TestMethod]
        public void CheckPointToString()
        {
            Point<double> p = new Point<double>(4.5);
            string s = p.ToString();
            string exp = "4,5 ";
            Assert.AreEqual(exp, s);
        }
        [TestMethod]
        public void List()
        {
            LinkedList<double> list = new LinkedList<double>();
            Point<double> p = new Point<double>(3.7);
            list.Beg = p;
            Assert.AreEqual(list.Beg.Data, 3.7);
        }
        [TestMethod]
        public void List2()
        {
            Point<double> beg = new Point<double>(5.8);
            LinkedList<double> list = new LinkedList<double>(beg);
            Assert.AreEqual(list.Beg.Data, 5.8);
        }
        [TestMethod]
        public void List3()
        {
            Point<double> beg = new Point<double>(5.4);
            LinkedList<double> list = new LinkedList<double>(beg);
            LinkedList<double> newList = new LinkedList<double>(list);
            Assert.AreEqual(newList.Beg.Data, 5.4);
        }
        [TestMethod]
        public void ListSize()
        {
            bool ok = false;
            LinkedList<double> list = new LinkedList<double>(6);
            if ((double)list.Beg.Data != 0)
                ok = true;
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void ListRnd()
        {
            bool ok = false;
            Random rnd = new Random();
            LinkedList<double> list = new LinkedList<double>(rnd);
            if ((double)list.Beg.Data != 0)
                ok = true;
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void MakePoint()
        {
            LinkedList<double> list = new LinkedList<double>();
            Point<double> p = list.MakePoint(5.1);
            Assert.AreEqual(5.1, p.Data);
        }
        [TestMethod]
        public void MakePointRnd()
        {
            bool ok = false;
            Random rnd = new Random();
            LinkedList<double> list = new LinkedList<double>();
            Point<double> p = list.MakePoint(rnd);
            if ((double)p.Data != 0)
                ok = true;
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void MakeList()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Beg = list.MakeList(10);
            Point<double> p = list.Beg;
            bool empty = false;
            while (p != null && p.Next != null)
            {
                if ((double)p.Data == 0)
                {
                    empty = true;
                }
                p = p.Next;
            }
            Assert.AreEqual(false, empty);
        }
    }
}
