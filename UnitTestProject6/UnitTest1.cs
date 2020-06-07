using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP6;

namespace UnitTestProject6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get1()
        {
            Program.a1 = 1;
            Program.a2 = 3;
            Program.a3 = 5;
            Program.n = 1;
            Program.e = 1;
            long k = Program.GetElement(1);
            Assert.AreEqual((int)k, 1);
        }
        [TestMethod]
        public void Get2()
        {
            Program.a1 = 1;
            Program.a2 = 3;
            Program.a3 = 5;
            Program.n = 1;
            Program.e = 1;
            long k = Program.GetElement(2);
            Assert.AreEqual((int)k, 3);
        }
        [TestMethod]
        public void Get3()
        {
            Program.a1 = 1;
            Program.a2 = 3;
            Program.a3 = 5;
            Program.n = 1;
            Program.e = 1;
            long k = Program.GetElement(3);
            Assert.AreEqual((int)k, 5);
        }
        [TestMethod]
        public void GetN()
        {
            Program.a1 = 1;
            Program.a2 = 3;
            Program.a3 = 5;
            Program.n = 1;
            Program.e = 1;
            long k = Program.GetElement(5);
            Assert.AreEqual((int)k, 41);
        }
        [TestMethod]
        public void MakeArrayOfAllElems()
        {
            Program.a1 = 1;
            Program.a2 = 2;
            Program.a3 = 3;
            Program.n = 2;
            Program.e = 5;
            long[] all = new long[6];
            all[0] = 1;
            all[1] = 2;
            all[2] = 3;
            all[3] = 7;
            all[4] = 19;
            all[5] = 61;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers, out elements, out numbers);
            bool ok = true;
            for (int i = 0; i < 6; i++)
            {
                if (all[i] == all_real[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void MakeArrayOfAllElems2()
        {
            Program.a1 = 1;
            Program.a2 = 3;
            Program.a3 = 5;
            Program.n = 1;
            Program.e = 1;
            long[] all = new long[2];
            all[0] = 1;
            all[1] = 3;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers, out elements, out numbers);
            bool ok = true;
            for (int i = 0; i < all_real.Length; i++)
            {
                if (all[i] == all_real[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void MakeArrayOfNesElems()
        {
            Program.a1 = 1;
            Program.a2 = 2;
            Program.a3 = 3;
            Program.n = 2;
            Program.e = 5;
            long[] nesElems = new long[2];
            nesElems[0] = 19;
            nesElems[1] = 61;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers, out elements, out numbers);
            bool ok = true;
            for (int i = 0; i < 2; i++)
            {
                if (nesElems[i] == elements[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void MakeArrayOfNumbers()
        {
            Program.a1 = 1;
            Program.a2 = 2;
            Program.a3 = 3;
            Program.n = 2;
            Program.e = 5;
            int[] numbers = new int[2];
            numbers[0] = 5;
            numbers[1] = 6;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers_real = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers_real, out elements, out numbers_real);
            bool ok = true;
            for (int i = 0; i < 2; i++)
            {
                if (numbers[i] == numbers_real[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void Makea1()
        {
            Program.a1 = 1;
            int exp = 1;
            Assert.AreEqual(Program.a1, exp);
        }
        [TestMethod]
        public void Makea2()
        {
            Program.a2 = 3;
            int exp = 3;
            Assert.AreEqual(Program.a2, exp);
        }
        [TestMethod]
        public void Makea3()
        {
            Program.a3 = 3;
            int exp = 3;
            Assert.AreEqual(Program.a3, exp);
        }
        [TestMethod]
        public void Maken()
        {
            Program.n = 2;
            int exp = 2;
            Assert.AreEqual(Program.n, exp);
        }
        [TestMethod]
        public void Makee()
        {
            Program.e = 20;
            int exp = 20;
            Assert.AreEqual(Program.e, exp);
        }
        [TestMethod]
        public void MakeArrayOfAllElems_Negative()
        {
            Program.a1 = -5;
            Program.a2 = 4;
            Program.a3 = -2;
            Program.n = 3;
            Program.e = 6;
            long[] all = new long[5];
            all[0] = -5;
            all[1] = 4;
            all[2] = -2;
            all[3] = -42;
            all[4] = -58;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers, out elements, out numbers);
            bool ok = true;
            for (int i = 0; i < 5; i++)
            {
                if (all[i] == all_real[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void MakeArrayOfNesElems_Negative()
        {
            Program.a1 = -5;
            Program.a2 = 4;
            Program.a3 = -2;
            Program.n = 3;
            Program.e = 6;
            long[] nesElems = new long[3];
            nesElems[0] = 4;
            nesElems[1] = -42;
            nesElems[2] = -58;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers, out elements, out numbers);
            bool ok = true;
            for (int i = 0; i < 3; i++)
            {
                if (nesElems[i] == elements[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void MakeArrayOfNumbers_Negative()
        {
            Program.a1 = -5;
            Program.a2 = 4;
            Program.a3 = -2;
            Program.n = 3;
            Program.e = 6;
            int[] numbers = new int[3];
            numbers[0] = 2;
            numbers[1] = 4;
            numbers[2] = 5;
            long[] all_real = new long[2];
            all_real[0] = Program.a1;
            all_real[1] = Program.a2;
            long[] elements = new long[Program.n];
            int[] numbers_real = new int[Program.n];
            all_real = Program.MakeArray(all_real, elements, numbers_real, out elements, out numbers_real);
            bool ok = true;
            for (int i = 0; i < 3; i++)
            {
                if (numbers[i] == numbers_real[i])
                {

                }
                else ok = false;
            }
            Assert.AreEqual(ok, true);
        }
    }
}
