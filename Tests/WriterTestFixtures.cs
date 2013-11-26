using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest.Core.Writer;
using CodeTest.Core.Helper;

namespace CodeTest.Tests
{
    [TestClass]
    public class WriterTestFixtures
    {
        [TestMethod]
        public void ConsoleWriter_ShouldOutputToConsole()
        {
            IWriter writer = new ConsoleWriter();
            StringBuilder sb = new StringBuilder();
            StringWriter strWriter = new StringWriter(sb);
            StringBuilder sbExpected = new StringBuilder();
            IList<int> list = new List<int>() { 1, 2, 3 };

            sbExpected = Utility.GenerateCommaSeperatedValues(list)
                                .Append(Environment.NewLine);

            Console.SetOut(strWriter); // redirect output to stringWriter so we can test
            writer.Write(list);

            Assert.AreEqual(sbExpected.ToString(), sb.ToString());
        }


        [TestMethod]
        public void ConsoleWriter_WithNoMatching_ShouldPrintNoMatches()
        {
            IWriter writer = new ConsoleWriter();
            StringBuilder sb = new StringBuilder();
            StringWriter strWriter = new StringWriter(sb);
            StringBuilder sbExpected = new StringBuilder();
            IList<int> list = new List<int>() { 0 };

            sbExpected.AppendFormat("<no matches>{0}", Environment.NewLine);

            Console.SetOut(strWriter); // redirect output to stringWriter so we can test
            writer.Write(list);

            Assert.AreEqual(sbExpected.ToString(), sb.ToString());
        }
    }
}
