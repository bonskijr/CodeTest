using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest.Core;

namespace CodeTest.Tests
{
    [TestClass]
    public class TextMatcherTestFixtures    
    {
        string theString = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";

        [TestMethod]
        public void GetMatchingPositions_SubtextWithSameCasing_ShouldReturnMatchingPositions()
        {
           var subTextMatcher = new TextMatcher(theString,"Polly");
           var matchingPositions = subTextMatcher.GetMatchingPositions();
           CollectionAssert.AreEquivalent(new List<int>() { 1, 26, 51 }, matchingPositions.ToArray());
        }

        [TestMethod]
        public void GetMatchingPositions_SubtextIsNotTheSameCasing_ShouldReturnMatchingPositions()
        {
            var subTextMatcher = new TextMatcher(theString, "polly");
            var matchingPositions = subTextMatcher.GetMatchingPositions();

            CollectionAssert.AreEquivalent(new List<int>() { 1, 26, 51 }, matchingPositions.ToArray());
        }

        [TestMethod]
        public void GetMatchingPositions_WithSucceedingMatches_ShouldReturnMatchingPositions() 
        {
            var subTextMatcher = new TextMatcher("pollypollypollypolly", "POLLY");
            CollectionAssert.AreEquivalent(new List<int>() {1,6, 11,16}, subTextMatcher.GetMatchingPositions().ToArray());  
        }

        [TestMethod]
        public void GetMatchingPositions_WithNoMatches_ShouldNotReturnMatchingPositions()
        {
            //var subTextMatcher = new TextMatcher("the quick brown fox", "XX");
            var subTextMatcher = new TextMatcher(theString, "XX");
            var matching = subTextMatcher.GetMatchingPositions();

            Assert.AreEqual(0, matching.FirstOrDefault());
        }

        [TestMethod]
        public void GetMatchingPositions_MatchesTheLastChar_ShouldNotReturnMatchingPositions()
        {
            var subTextMatcher = new TextMatcher("the quick brown fox", "XX");
            var matching = subTextMatcher.GetMatchingPositions();

            Assert.AreEqual(0, matching.FirstOrDefault());
        }

        [TestMethod]
        public void GetMatchingPositions_WithEmptyString_ShouldNotReturnMatchingPositions() 
        {
            var subTextMatcher = new TextMatcher(string.Empty, "polly");
            var matching = subTextMatcher.GetMatchingPositions();

            Assert.AreEqual(0, matching.FirstOrDefault());
            
        }

        [TestMethod]
        public void GetMatchingPositions_WithEmptySubText_ShouldNotReturnMatchingPositions()
        {
            var subTextMatcher = new TextMatcher(theString, string.Empty);
            var matching = subTextMatcher.GetMatchingPositions();

            Assert.AreEqual(0, matching.FirstOrDefault());

           // CollectionAssert.AreEquivalent(new List<int>(), subTextMatcher.GetMatchingPositions().ToArray());
        }
    }

    
}
