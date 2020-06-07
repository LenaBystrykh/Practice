using System;
using System.Runtime.Versioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UP11;

namespace UnitTestProject11
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Transp()
        {
            bool repeated = false;
            int k = 5;
            int[] transp = new int[k];
            transp = Program.CreateTransposition(5, transp);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (transp[i] == transp[j])
                        repeated = true;
                }
            }
            Assert.AreEqual(false, repeated);
        }
        [TestMethod]
        public void CheckCipherEqual()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("шифр").ToCharArray();
            symbols = Program.GetCipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < 4; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("фирш", s);
        }
        [TestMethod]
        public void CheckCipherMore()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("шифрование").ToCharArray();
            symbols = Program.GetCipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < symbols.Length; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("фиршавно е и", s);
        }
        [TestMethod]
        public void CheckCipherLess()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("кот").ToCharArray();
            symbols = Program.GetCipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < 4; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("то к", s);
        }
        [TestMethod]
        public void CheckRecipherEqual()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("фирш").ToCharArray();
            symbols = Program.GetRecipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < 4; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("шифр", s);
        }
        [TestMethod]
        public void CheckRecipherMore()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("фиршавно е и").ToCharArray();
            symbols = Program.GetRecipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < symbols.Length; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("шифрование  ", s);
        }
        [TestMethod]
        public void CheckRecipherLess()
        {
            int[] transp = new int[4];
            transp[0] = 3;
            transp[1] = 2;
            transp[2] = 4;
            transp[3] = 1;
            char[] symbols = ("то к").ToCharArray();
            symbols = Program.GetRecipheredText(4, transp, symbols);
            string s = null;
            for (int i = 0; i < 4; i++)
            {
                s += symbols[i];
            }
            Assert.AreEqual("кот ", s);
        }
    }
}
