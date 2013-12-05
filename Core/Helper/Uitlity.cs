using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest.Core.Helper
{
    public static class Utility
    {
        public static StringBuilder GenerateCommaSeperatedValues(IEnumerable<int> matchingList)
        {
            if (matchingList == null) throw new ArgumentNullException("matchingList must not be null");

            StringBuilder sb = new StringBuilder();
            string delimiter = string.Empty;

            if (matchingList.FirstOrDefault() == 0 || matchingList.Count() == 0)
            {
                return sb.Append("<no matches>");
            }
        
            foreach (var item in matchingList)
            {
                sb.Append(delimiter).Append(item);
                delimiter = ",";
            }

            return sb;

        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <param name="_theString">The instance string</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <param name="length">The number of characters to return in the substring.</param>
        /// <exception cref="ArgumentNullException">If the string instance is empty or null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex is less than zero or exceeds the length of the string</exception>
        /// <returns></returns>
        public static string ExtractString(this string _theString, int startIndex, int length = 0) 
        {
            if (string.IsNullOrEmpty(_theString)) throw new ArgumentNullException("calling string must not null or empty");
            if((startIndex > _theString.Length))
                throw new ArgumentOutOfRangeException(string.Format("start position argument: {0} exceeds than actual string length {1}", startIndex, _theString.Length));
            if ((startIndex < 0 ))
                throw new ArgumentOutOfRangeException(string.Format("start argument: {0} requires a non-negative value", startIndex));

            StringBuilder sb = new StringBuilder();

            if ((startIndex + length) > _theString.Length) length = Math.Abs(_theString.Length - (startIndex + length) );

            foreach (var item in _theString.ToCharArray(startIndex, length))
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

    }
}
