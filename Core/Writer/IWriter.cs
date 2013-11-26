using System.Collections.Generic;

namespace CodeTest.Core.Writer
{
    /// <summary>
    /// Provides a means to output the matching position to any means of output mechanism (eg Console)
    /// </summary>
    public interface IWriter
    {
        void Write(IEnumerable<int> matchingList);
    }
}
