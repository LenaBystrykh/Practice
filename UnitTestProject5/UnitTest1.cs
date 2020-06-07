using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP5;

namespace UnitTestProject5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerate()
        {
            double[,] matrix = new double[3, 3];
            matrix = Program.GenerateMatrix(3, matrix);
            bool empty = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] != 0) empty = false;
                }
            }
            Assert.AreEqual(empty, false);
        }
        [TestMethod]
        public void GetUpSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = -7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = -9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(upSumm, 19.64);
        }
        [TestMethod]
        public void GetDownSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = -7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = -9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(downSumm, -33.16);
        }
        [TestMethod]
        public void GetEqSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = -7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = -9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(eqSumm, 25.66);
        }
        [TestMethod]
        public void GetZeroUpSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = 7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = 9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(upSumm, 0);
        }
        [TestMethod]
        public void GetZeroDownSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = 7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = 9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(downSumm, 0);
        }
        [TestMethod]
        public void GetZeroEqSumm()
        {
            double upSumm, downSumm, eqSumm;
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 2.11;
            matrix[0, 1] = -3.72;
            matrix[0, 2] = 14.35;
            matrix[0, 3] = 9.81;
            matrix[1, 0] = 7.15;
            matrix[1, 1] = 13.24;
            matrix[1, 2] = 5.63;
            matrix[1, 3] = 8.87;
            matrix[2, 0] = 9.11;
            matrix[2, 1] = -16.90;
            matrix[2, 2] = 12.42;
            matrix[2, 3] = 5.14;
            matrix[3, 0] = 10.09;
            matrix[3, 1] = 8.75;
            matrix[3, 2] = -5.93;
            matrix[3, 3] = 8.30;
            Program.GetSumm(4, matrix, out upSumm, out downSumm, out eqSumm);
            Assert.AreEqual(eqSumm, 0);
        }
    }
}
