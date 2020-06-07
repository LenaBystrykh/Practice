using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP12;

namespace UnitTestProject12
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateArray1()
        {
            bool ok = true;
            int[] array1 = new int[5];
            int[] array2 = new int[5];
            int[] array3 = new int[5];
            Program.CreateArrays(5, out array1, out array2, out array3);
            for (int i = 0; i < 5; i++)
            {
                if (array1[i] == 0) ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestCreateArray2()
        {
            bool ok = true;
            int[] array1 = new int[5];
            int[] array2 = new int[5];
            int[] array3 = new int[5];
            Program.CreateArrays(5, out array1, out array2, out array3);
            int[] checkArray = new int[5];
            array1.CopyTo(checkArray, 0);
            Array.Sort(checkArray);
            for (int i = 0; i < 5; i++)
            {
                if (array2[i] != checkArray[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestCreateArray3()
        {
            bool ok = true;
            int[] array1 = new int[5];
            int[] array2 = new int[5];
            int[] array3 = new int[5];
            Program.CreateArrays(5, out array1, out array2, out array3);
            int[] checkArray1 = new int[5];
            array1.CopyTo(checkArray1, 0);
            Array.Sort(checkArray1);
            int[] checkArray2 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                checkArray2[i] = checkArray1[checkArray1.Length - 1 - i];
            }
            for (int i = 0; i < 5; i++)
            {
                if (array3[i] != checkArray2[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestMergeSort()
        {
            bool ok = true;
            int[] array = { 7, 2, 9, 14, 72, 3};
            int[] sortedArray = { 2, 3, 7, 9, 14, 72 };
            int[] m_array = new int[6];
            int compare = 0; 
            int copy_op = 0;
            m_array = Program.MergeSort(array, compare, out compare, copy_op, out copy_op);
            for (int i = 0; i < 6; i++)
            {
                if (sortedArray[i] != m_array[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestMergeSortCompare()
        {
            int[] array = { 7, 2, 9, 14, 72, 3 };
            int[] m_array = new int[6];
            int compare = 0;
            int copy_op = 0;
            m_array = Program.MergeSort(array, compare, out compare, copy_op, out copy_op);
            Assert.AreEqual(10, compare);
        }
        [TestMethod]
        public void TestMergeSortCopyOp()
        {
            int[] array = { 7, 2, 9, 14, 72, 3 };
            int[] m_array = new int[6];
            int compare = 0;
            int copy_op = 0;
            m_array = Program.MergeSort(array, compare, out compare, copy_op, out copy_op);
            Assert.AreEqual(21, copy_op);
        }
        [TestMethod]
        public void TestMerge()
        {
            bool ok = true;
            int[] arr1 = { 5 };
            int[] arr2 = { 3 };
            int compare = 0;
            int copy_op = 0;
            int[] m_array = new int[2];
            m_array = Program.Merge(arr1, arr2, compare, out compare, copy_op, out copy_op);
            int[] exp = { 3, 5 };
            for (int i = 0; i < 2; i++)
            {
                if (exp[i] != m_array[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestMerge2()
        {
            bool ok = true;
            int[] arr1 = { 5, 9 };
            int[] arr2 = { 3, 7 };
            int compare = 0;
            int copy_op = 0;
            int[] m_array = new int[2];
            m_array = Program.Merge(arr1, arr2, compare, out compare, copy_op, out copy_op);
            int[] exp = { 3, 5, 7, 9 };
            for (int i = 0; i < 4; i++)
            {
                if (exp[i] != m_array[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestBucketSort()
        {
            bool ok = true;
            int[] array = { 7, 2, 9, 14, 72, 3 };
            int[] sortedArray = { 2, 3, 7, 9, 14, 72 };
            int[] b_array = new int[6];
            int compare = 0;
            int resend = 0;
            b_array = Program.BucketSort(array, out resend, out compare);
            for (int i = 0; i < 6; i++)
            {
                if (sortedArray[i] != b_array[i])
                    ok = false;
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void TestBucketSortCompare()
        {
            int[] array = { 7, 2, 9, 14, 72, 3 };
            int[] sortedArray = { 2, 3, 7, 9, 14, 72 };
            int[] b_array = new int[6];
            int compare = 0;
            int resend = 0;
            b_array = Program.BucketSort(array, out resend, out compare);
            Assert.AreEqual(14, compare);
        }
        [TestMethod]
        public void TestBucketSortResend()
        {
            int[] array = { 7, 2, 9, 14, 72, 3 };
            int[] sortedArray = { 2, 3, 7, 9, 14, 72 };
            int[] b_array = new int[6];
            int compare = 0;
            int resend = 0;
            b_array = Program.BucketSort(array, out resend, out compare);
            Assert.AreEqual(10, resend);
        }
    }
}
