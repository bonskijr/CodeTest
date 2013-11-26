using System;
using System.Collections.Generic;
using System.Text;
using CodeTest.Core.Helper;

namespace CodeTest.Core.Writer
{
    /// <summary>
    /// Represents a <typeparamref name="IWriter"/> that outputs to a Console.
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Output a comma seperated values for matching positions to a console. 
        /// </summary>
        /// <param name="matchingList"></param>
        public void Write(IEnumerable<int> matchingList)
        {
            StringBuilder sb = Utility.GenerateCommaSeperatedValues(matchingList);

            Console.WriteLine(sb.ToString());
        }

    }
}
