using System;
using System.Collections.Generic;
using System.Text;
using CodeTest.Core.Helper;

namespace CodeTest.Core
{
    /// <summary>
    /// Represents an object to match a pattern (<paramref name="thePattern"/> from an input string (<paramref name="theString"/>.
    /// Returns the matching string positions of type <typeparamref name="IEnumerable<int>"/>. 
    /// </summary>
    public class TextMatcher
    {
        string _theString;
        string _thePattern;
        IList<int> _matchingPositions = new List<int>();

        /// <summary>
        /// Initializes a new instance of the TextMatcher and requires <paramref name="theString"/> and <paramref name="thePattern"/> to initialize.
        /// </summary>
        /// <param name="theString">The string to search for a possible text match</param>
        /// <param name="thePattern">The string pattern to match</param>
        public TextMatcher(string theString, string thePattern)
        {
            _theString = theString;                                         
            _thePattern = thePattern;
        }

        /// <summary>
        /// Returns the string position(s) of the matching pattern 
        /// </summary>
        /// <returns><typeparamref name="IEnumerable"/> of matching positions. An empty collection if there's no match.</returns>
        public IEnumerable<int> GetMatchingPositions()                
        {
            _thePattern = _thePattern.ToLowerInvariant();
            _theString = _theString.ToLowerInvariant();

            if (string.IsNullOrEmpty(_theString))
            {
                yield return 0;
                yield break;
            }


            if (string.IsNullOrEmpty(_thePattern)) 
            {
                yield return 0;
                yield break;
            }

            int j = 0;
            StringBuilder sb = new StringBuilder();
            string subText = "";

            for (int i = 0; i < _theString.Length; i++)
            {
                if (_theString[i] == _thePattern[0])
                {
                    subText = _theString.ExtractString(i, _thePattern.Length);

                    foreach (var item in subText.ToCharArray())
                    {
                        if (item != _thePattern[j]) break;

                        sb.Append(item);
                        j++;
                    }

                    if (sb.ToString().Equals(_thePattern, StringComparison.InvariantCultureIgnoreCase))
                    {
                        yield return (i + 1);
                    }

                    // jump to the last position that did not match instead of iterating through everything
                    // note: make sure one accounts for the 0-based index.
                    i = (i +j ) - 1;

                    // reset variables
                    sb.Clear();
                    j = 0;
                }
            }

        }

    }
}
