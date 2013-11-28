using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest.Core.Writer
{
    /// <summary>
    /// Represents a <typeparamref name="IWriter"/> that outputs to a Console highlighting the matched subtext.
    /// </summary>
    public class FancyConsoleWriter : IWriter
    {
        string _theString;
        string _thePattern;

        public FancyConsoleWriter(string theString, string thePattern) 
        {
            _thePattern = thePattern;
            _theString = theString;
        }

        public void Write(IEnumerable<int> matchingList)
        {
            HighlightMatchedString(matchingList);
        }

        private void HighlightMatchedString(IEnumerable<int> matchingList) 
        {
            if ((matchingList.Count() == 0) || (matchingList.FirstOrDefault() == 0))
            {
                Console.WriteLine(_theString);
                return;
            }

            if (string.IsNullOrEmpty(_theString))
            {
                Console.WriteLine(_theString);
                return;
            }

            int j = 0;
            int len = 0;
            ConsoleColor defaultColor = Console.BackgroundColor;

            for (int i = 0; i < _theString.Length; i++)
            {
                if (matchingList.Contains(i + 1))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    len = _thePattern.Length;

                    for (j = 0; j < len; j++)
                    {
                        Console.Write(_theString[i + j]);
                    }

                    i = (i + j) - 1;
                }
                else
                {
                    Console.BackgroundColor = defaultColor;
                    Console.Write(_theString[i]);
                }
            }
            Console.WriteLine();
          
        }

    
    }
}
