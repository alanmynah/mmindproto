using System;
using Shouldly;
using Xunit;
using mastermindProto;

namespace mastermindProtoUnitTests
{
    public class FiveStepsAlgorithmTests
    {
        [Fact]
        public void CanCreatePermutationSet()
        {
            var set = FiveStepAlgorithm.CreatePermutationSet();
            Assert.Equal(1296, set.Count);
        }
    }
}
