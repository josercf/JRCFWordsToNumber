using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JRCF.WordsToNumber.Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void WriteOne()
        {
            var parser = new Parser("um");
            var one = parser.ConvertTextToDecimal();
            Assert.AreEqual(one, "1");
        }

        [TestMethod]
        public void WriteTen()
        {
            var parser = new Parser("dez");
            Assert.AreEqual(parser.ConvertTextToDecimal(), "10");
        }

        [TestMethod]
        public void WriteOneHundredTwentyFive()
        {
            var parser = new Parser("cento e vinte e cinco");
            Assert.AreEqual(parser.ConvertTextToDecimal(), "125");
        }

        [TestMethod]
        public void WriteOneHundredTwo()
        {
            var parser = new Parser("cento e um");
            Assert.AreEqual(parser.ConvertTextToDecimal(), "101");
        }

        [TestMethod]
        public void WriteNineHundredninityNine()
        {
            var parser = new Parser("novecentos e noventa e nove");
            Assert.AreEqual(parser.ConvertTextToDecimal(), "999");
        }
    }
}
