using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP9;

namespace UnitTestProject9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckPoint()
        {
            Point<int> point = new Point<int>(2);
            Assert.AreEqual(point.Data, 2);
        }
        [TestMethod]
        public void Check2Points()
        {
            Point<int> point = new Point<int>();
            point.Data = 3;
            Point<int> nextPoint = new Point<int>(7);
            point.Next = nextPoint;
            nextPoint.Pred = point;
            Assert.AreEqual(point.Next.Data, 7);
        }
        [TestMethod]
        public void CheckPointToString()
        {
            Point<int> p = new Point<int>(4);
            string s = p.ToString();
            string exp = "4 ";
            Assert.AreEqual(exp, s);
        }
        [TestMethod]
        public void List()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Point<int> p = new Point<int>(3);
            list.Beg = p;
            Assert.AreEqual(list.Beg.Data, 3);
        }
        [TestMethod]
        public void List2()
        {
            Point<int> beg = new Point<int>(5);
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(beg);
            Assert.AreEqual(list.Beg.Data, 5);
        }
        [TestMethod]
        public void List3()
        {
            Point<int> beg = new Point<int>(5);
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(beg);
            DoublyLinkedList<int> newList = new DoublyLinkedList<int>(list);
            Assert.AreEqual(newList.Beg.Data, 5);
        }
        [TestMethod]
        public void MakePoint()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Point<int> p = list.MakePoint(5);
            Assert.AreEqual(5, p.Data);
        }
        [TestMethod]
        public void MakeList()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Beg = list.MakeList(10);
            Point<int> p = list.Beg;
            bool empty = false;
            while (p != null && p.Next != null)
            {
                if (p.Data == 0)
                {
                    empty = true;
                }
                p = p.Pred;
            }
            Assert.AreEqual(false, empty);
        }
        [TestMethod]
        public void DeleteElement()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Beg = list.MakeList(3);
            list.Beg = list.Delete(list.Beg, 2);

            DoublyLinkedList<int> newList = new DoublyLinkedList<int>();
            Point<int> np1 = new Point<int>(1);
            Point<int> np2 = new Point<int>(3);
            list.Beg = np1;
            list.Beg.Next = np2;
            list.Beg.Next.Pred = np1;

            Assert.AreEqual(list.Beg.Next.Data, list.Beg.Next.Data);
        }
        [TestMethod]
        public void DeleteElementFalse()
        {
            bool notFound = false;
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Beg = list.MakeList(3);
            Point<int> p = list.Beg;
            list.Beg = list.Delete(list.Beg, 6);
            if (p == list.Beg)
                notFound = true;
            Assert.AreEqual(notFound, true);
        }
        [TestMethod]
        public void SearchElement()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Beg = list.MakeList(5);
            bool ok = list.Search(list.Beg, 3);
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void SearchElementFalse()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Beg = list.MakeList(5);
            bool ok = list.Search(list.Beg, 7);
            Assert.AreEqual(false, ok);
        }
    }
}
