using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest.Core.Writer
{
    /// <summary>
    /// Represents a <typeparamref name="IWriter"/> that returns an html with highlight style to the matching text.
    /// </summary>
    public class FancyHtmlWriter : IWriter
    {
        string _theString;
        string _thePattern;
        StringBuilder _html;
        private const string TheStringHtml = "<p id=\"inputLabelString\" class=\"lead\">";

        public string FormattedHtml { get { return _html.ToString();  } }

        public FancyHtmlWriter (string theString, string thePattern)
        {
            _thePattern = thePattern;
            _theString = theString;
            _html = new StringBuilder(TheStringHtml).AppendFormat("{0}</p>", _theString);
        }

        public void Write(IEnumerable<int> matchingList)
        {
            if (matchingList == null) return;

            HighlightMatchedString(matchingList);
        }

        /// <summary>
        /// Given the <typeparamref name="matchinglist"/> highlight the matching text.
        /// </summary>
        /// <param name="matchingList"></param>
        private void HighlightMatchedString(IEnumerable<int> matchingList)
        {
            if ((matchingList.Count() == 0) || (matchingList.FirstOrDefault() == 0) || string.IsNullOrEmpty(_theString))
            {
                _html = new StringBuilder(TheStringHtml).AppendFormat("{0}</p>", _theString);
                return;
            }

            int j = 0;
            _html = new StringBuilder(TheStringHtml);

            for (int i = 0; i < _theString.Length; i++)
            {
                if (matchingList.Contains(i + 1))
                {
                    _html.Append("<span class=\"highlight\">");


                    for (j = 0; j < _thePattern.Length; j++)
                    {
                        _html.Append(_theString[i + j]);
                    }

                    i = (i + j) - 1;
                    _html.Append("</span>");
                }
                else
                {
                    _html.Append(_theString[i]);
                }

            }

            _html.Append("</p>");
        }

    }
}
