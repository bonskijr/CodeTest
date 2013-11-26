using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest.Core.Helper;

namespace CodeTest.Tests
{
    [TestClass]
    public class UtilityTestHarness
    {
        [TestMethod]
        public void ExtractBatString_FromBatmanString_ShouldReturnBatString()
        {
            Assert.AreEqual("Bat", "Batman".ExtractString(0, 3));
        }

        [TestMethod]
        public void ExtractManString_FromBatmanString_ShouldReturnManString()
        {
            Assert.AreEqual("man", "Batman".ExtractString(3, 3));
        }
    }
}
