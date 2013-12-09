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

        /// <summary>
        /// Given the <typeparamref name="matchinglist"/> highlight the matching text.
        /// </summary>
        /// <param name="matchingList"></param>
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
            ConsoleColor defaultBackgroundColor = Console.BackgroundColor;
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;

            for (int i = 0; i < _theString.Length; i++)
            {
                if (matchingList.Contains(i + 1))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.White;

                    for (j = 0; j < _thePattern.Length; j++)
                    {
                        Console.Write(_theString[i + j]);
                    }

                    i = (i + j) - 1;
                }
                else
                {
                    Console.BackgroundColor = defaultBackgroundColor;
                    Console.ForegroundColor = defaultForegroundColor;
                    Console.Write(_theString[i]);
                }
            }
            Console.BackgroundColor = defaultBackgroundColor; //reset color
            Console.ForegroundColor = defaultForegroundColor; //reset color
            Console.WriteLine();
            
          
        }

    
    }
}
