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
            if (matchingList == null) throw new ArgumentNullException("Write GenerateCommaSeperatedValues a matchingList that is not null");
        
            StringBuilder sb = new StringBuilder();
            string delimiter = string.Empty;

            foreach (var item in matchingList)
            {
                sb.Append(delimiter).Append(item);
                delimiter = ",";
            }

            // all of the above could just be changed to Console.WriteLine(string.Join(",", matchingList));
            if (matchingList.FirstOrDefault() == 0 || matchingList.Count() == 0)
            {
                sb = new StringBuilder().Append("<no matches>");
            }

            return sb;

        }

        public static string ExtractString(this string _theString, int start, int length = 0) 
        {
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
