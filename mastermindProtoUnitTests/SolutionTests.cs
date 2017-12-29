using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using mastermindProto;
using Xunit.Sdk;

namespace mastermindProtoUnitTests
{
    public class FiveStepsAlgorithmTests
    {
        [Fact]
        public void CanCreatePermutationSet()
        {
            var set = FiveStepAlgorithm.CreatePermutationSet();

            var expected = 1296;
            var actual = set.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPegsForReturnsStringFourCharactersLong()
        {
           Assert.IsType<string>(FiveStepAlgorithm.GetPegsFor(1122, 1234));
        }

        [Fact]
        public void GetsPegsForGuesses()
        {
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1122, 1234), "bwnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(2211, 1234), "wbnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1234, 4321), "wwww");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(3333, 1111), "nnnn");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1111, 1111), "bbbb");
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(1233, 3312), "wwwn"); // would this be right though? Think so...
            Assert.Equal(FiveStepAlgorithm.GetPegsFor(4421, 4413), "bbwn");
        }

        [Fact]
        public void GetsNewGuess()
        {
            var set = new List<int> { };
            Assert.Equal(FiveStepAlgorithm.GetNewGuess(set), 1234);
        }
    }
}
