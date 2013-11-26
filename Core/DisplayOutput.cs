using System.Collections.Generic;
using CodeTest.Core.Writer;

namespace CodeTest.Core
{
    /// <summary>
    /// Abstracts the output of matching position to a specific <typeparamref name="IWriter"/>.
    /// <remarks>
    /// The actual display is handled by a class that implements a <typeparamref name="IWriter"/>
    /// </remarks>
    /// </summary>
    public class DisplayOutput
    {
        IWriter _writer;

        /// <summary>
        /// Initializes a DisplayOutput object and expects a <typeparamref name="IWriter"/>.
        /// </summary>
        /// <param name="writer">Writer that will do actual display.</param>
        public DisplayOutput(IWriter writer) 
        {
            _writer = writer;
        }

        public void Display(IEnumerable<int> matchingList) 
        {
            _writer.Write(matchingList);
        }
    }
}
