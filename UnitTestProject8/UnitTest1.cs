using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP8;

namespace UnitTestProject8
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckBridge1()
        {
            Program.n = 4;
            Program.matrix = new int[4, 4];
            Program.matrix[0, 0] = 0;
            Program.matrix[0, 1] = 1;
            Program.matrix[0, 2] = 0;
            Program.matrix[0, 3] = 1;
            Program.matrix[1, 0] = 1;
            Program.matrix[1, 1] = 0;
            Program.matrix[1, 2] = 0;
            Program.matrix[1, 3] = 1;
            Program.matrix[2, 0] = 0;
            Program.matrix[2, 1] = 0;
            Program.matrix[2, 2] = 0;
            Program.matrix[2, 3] = 1;
            Program.matrix[3, 0] = 1;
            Program.matrix[3, 1] = 1;
            Program.matrix[3, 2] = 1;
            Program.matrix[3, 3] = 0;
            Program.FindBridges();
            bool ok = false;
            if (Program.bridges.Contains("Мост из 3 в 4") || Program.bridges.Contains("Мост из 4 в 3"))
                ok = true;
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void CheckBridges2()
        {
            Program.n = 5;
            Program.matrix = new int[5, 5];
            Program.matrix[0, 0] = 0;
            Program.matrix[0, 1] = 1;
            Program.matrix[0, 2] = 0;
            Program.matrix[0, 3] = 1;
            Program.matrix[0, 4] = 0;
            Program.matrix[1, 0] = 1;
            Program.matrix[1, 1] = 0;
            Program.matrix[1, 2] = 0;
            Program.matrix[1, 3] = 1;
            Program.matrix[1, 4] = 0;
            Program.matrix[2, 0] = 0;
            Program.matrix[2, 1] = 0;
            Program.matrix[2, 2] = 0;
            Program.matrix[2, 3] = 1;
            Program.matrix[2, 4] = 1;
            Program.matrix[3, 0] = 1;
            Program.matrix[3, 1] = 1;
            Program.matrix[3, 2] = 1;
            Program.matrix[3, 3] = 0;
            Program.matrix[3, 4] = 0;
            Program.matrix[4, 0] = 0;
            Program.matrix[4, 1] = 0;
            Program.matrix[4, 2] = 1;
            Program.matrix[4, 3] = 0;
            Program.matrix[4, 4] = 0;

            Program.FindBridges();
            bool ok = false;
            if ( (Program.bridges.Contains("Мост из 3 в 4") || Program.bridges.Contains("Мост из 4 в 3") ) && 
                (Program.bridges.Contains("Мост из 3 в 5") || Program.bridges.Contains("Мост из 5 в 3") ) )
                ok = true;
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void CheckNoBridges()
        {
            Program.n = 3;
            Program.matrix = new int[3, 3];
            Program.matrix[0, 0] = 0;
            Program.matrix[0, 1] = 1;
            Program.matrix[0, 2] = 1;
            Program.matrix[1, 0] = 1;
            Program.matrix[1, 1] = 0;
            Program.matrix[1, 2] = 1;
            Program.matrix[2, 0] = 1;
            Program.matrix[2, 1] = 1;
            Program.matrix[2, 2] = 0;
            Program.FindBridges();
            bool ok = false;
            if (Program.bridges.Contains("Мост из 1 в 2") || Program.bridges.Contains("Мост из 1 в 3") || Program.bridges.Contains("Мост из 2 в 1") ||
                Program.bridges.Contains("Мост из 2 в 3") || Program.bridges.Contains("Мост из 3 в 1") || Program.bridges.Contains("Мост из 3 в 2"))
                ok = true;
            Assert.AreEqual(ok, false);
        }
        [TestMethod]
        public void GenerateMatrix()
        {
            bool notnull = false;
            Program.n = 4;
            Program.matrix = Program.CreateMatrix(Program.n);
            for (int i = 0; i < Program.n; i++)
            {
                for (int j = 0; j < Program.n; j++)
                {
                    if (Program.matrix[i, j] == 1)
                        notnull = true;
                }
            }
            Assert.AreEqual(notnull, true);
        }
        [TestMethod]
        public void CheckSymmerty()
        {
            bool ok = true;
            Program.n = 4;
            Program.matrix = Program.CreateMatrix(Program.n);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i > j)
                    {
                        if (Program.matrix[i, j] != Program.matrix[j, i])
                            ok = false;
                    }
                }
            }
            Assert.AreEqual(ok, true);
        }

    }
}
