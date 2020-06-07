using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP7;

namespace UnitTestProject7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckNotMonotone()
        {
            string input = "011*1101";
            string never;
            Program.CheckNotMonotone(input, out never);
            Assert.AreEqual("Данная функция никогда не может быть монотонной", never);
        }
        [TestMethod]
        public void CheckMonotone()
        {
            string input = "010*01*1";
            string never;
            Program.CheckNotMonotone(input, out never);
            Assert.AreEqual("", never);
        }
        [TestMethod]
        public void ChangeZero()
        {
            string input = "1*111011";
            string output = Program.ChangeIfPossible(input);
            Assert.AreEqual("10111011", output);
        }
        [TestMethod]
        public void ChangeOne()
        {
            string input = "0101110*";
            string output = Program.ChangeIfPossible(input);
            Assert.AreEqual("01011101", output);
        }
        [TestMethod]
        public void ChangeBoth()
        {
            string input = "*11101*1";
            string output = Program.ChangeIfPossible(input);
            Assert.AreEqual("01110111", output);
        }
        [TestMethod]
        public void ChangeNotAll()
        {
            string input = "0*0110**";
            string output = Program.ChangeIfPossible(input);
            Assert.AreEqual("000110*1", output);
        }
        [TestMethod]
        public void CheckMatrix1()
        {
            string input = "0*01";
            int[,] matrix = new int[2, 1];
            matrix[0, 0] = 0;
            matrix[1, 0] = 1;
            int[,] real = new int[2, 1];
            real = Program.MatrixOfOptions(input, 1);
            bool ok = true;
            for (int i = 0; i < 2; i++)
            {
                int j = 0;
                if (matrix[i, j] != real[i, j])
                {
                    ok = false;
                }
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void CheckMatrix2()
        {
            string input = "0*0101*1";
            int[,] matrix = new int[4, 2];
            matrix[0, 0] = 0;
            matrix[1, 0] = 0;
            matrix[2, 0] = 1;
            matrix[3, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 1] = 1;
            matrix[2, 1] = 0;
            matrix[3, 1] = 1;
            int[,] real = new int[4, 2];
            real = Program.MatrixOfOptions(input, 2);
            bool ok = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (matrix[i, j] != real[i, j])
                    {
                        ok = false;
                    }
                }
            }
            Assert.AreEqual(true, ok);
        }
        [TestMethod]
        public void CheckMatrix3()
        {
            string input = "0*0*11*1";
            int[,] matrix = new int[8, 3];
            matrix[0, 0] = 0;
            matrix[0, 1] = 0;
            matrix[0, 2] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 0;
            matrix[1, 2] = 1;
            matrix[2, 0] = 0;
            matrix[2, 1] = 1;
            matrix[2, 2] = 0;
            matrix[3, 0] = 0;
            matrix[3, 1] = 1;
            matrix[3, 2] = 1;
            matrix[4, 0] = 1;
            matrix[4, 1] = 0;
            matrix[4, 2] = 0;
            matrix[5, 0] = 1;
            matrix[5, 1] = 0;
            matrix[5, 2] = 1;
            matrix[6, 0] = 1;
            matrix[6, 1] = 1;
            matrix[6, 2] = 0;
            matrix[7, 0] = 1;
            matrix[7, 1] = 1;
            matrix[7, 2] = 1;
            int[,] real = new int[8, 3];
            real = Program.MatrixOfOptions(input, 3);
            bool ok = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] != real[i, j])
                    {
                        ok = false;
                    }
                }
            }
            Assert.AreEqual(true, ok);
        }
    }
}
