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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExtractString_WithNullOrEmptyCallingString_MustThrowArgumentNullException() 
        {
            string _theString = null;
            string _someString = string.Empty;

            _theString.ExtractString(1, 10);
            _someString.ExtractString(1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExtractString_StartArgIsGreaterThanStringLength_MustThrowArgumentOutOfRangeException()
        {
            Assert.AreEqual("Batman".ExtractString(8, 2), "d");
            Assert.AreEqual("Batman".ExtractString(-1, 2), "d");
        }
    }
}
