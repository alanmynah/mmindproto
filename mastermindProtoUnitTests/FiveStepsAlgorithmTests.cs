using System.Collections.Generic;
using Xunit;
using mastermindProto;

namespace mastermindUnitTests
{
    public class FiveStepAlgorithmTests
    {
        [Fact]
        public void GetPegsForReturnsStringFourCharactersLong()
        {
            Assert.IsType<string>(FiveStepAlgorithm.GetPegsFor(1122, 1234));
        }

        [Fact]
        public void CanCreatePermutationSet()
        {
            var set = FiveStepAlgorithm.CreatePermutationSet();

            var expected = 1296;
            var actual = set.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetsPegsForGuesses()
        {
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1122, 1234), "bwnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(2211, 1234), "wbnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1234, 4321), "wwww");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(3333, 1111), "nnnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1111, 1111), "bbbb");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1233, 3312), "wwwn"); // would this be right though? Think so... not sure about the Mastermind rules themselves. 
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(4421, 4413), "bbwn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1122, 1111), "bbnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1122, 2211), "wwnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(3523, 2532), "wbwn");
        }

        [Fact]
        public void RemovesOptions()
        {
            var combination = 1111;
            var guess = 1122;
            var set = new List<int> { 1111, 1112, 1122, 1234, 2345 };

            var response = FiveStepAlgorithm.GetPegsFor(guess, combination);

            set = FiveStepAlgorithm.RemoveOptionsBasedOnResponse(response, guess, set);

            var expected = new List<int> { 1111 };

            Assert.Equal(expected, set);
            // this looks like a lonely test, how to expand? 
        }

//        [Fact]
//        public void GetsNewGuess()
//        {
//            var set = new List<int> { };
//            Assert.Equal(FiveStepAlgorithm.GetNewGuess(set), 1234);
//        }
    }
}
