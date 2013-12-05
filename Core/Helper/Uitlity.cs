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

            if (matchingList.FirstOrDefault() == 0 || matchingList.Count() == 0)
            {
                return new StringBuilder().Append("<no matches>");
            }
        
            StringBuilder sb = new StringBuilder();
            string delimiter = string.Empty;

            foreach (var item in matchingList)
            {
                sb.Append(delimiter).Append(item);
                delimiter = ",";
            }

            return sb;

        }

        public static string ExtractString(this string _theString, int start, int length = 0) 
        {
            if (string.IsNullOrEmpty(_theString)) throw new ArgumentNullException("");

            StringBuilder sb = new StringBuilder();

            if ((start + length) > _theString.Length) length = Math.Abs(_theString.Length - (start + length));

            foreach (var item in _theString.ToCharArray(start, length))
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

    }
}
