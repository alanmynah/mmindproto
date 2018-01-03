using System;
using System.Collections.Generic;
using System.Text;
using mastermindProto;
using Xunit;

namespace mastermindUnitTests
{
    public class SolutionTests
    {
        [Fact]
        public void FindsSolutionsForVariousCombinations()
        {
            var comboSet = FiveStepAlgorithm.CreatePermutationSet();
            var solutionSet = new List<int>() { };

            foreach (var possibleCombination in comboSet)
            {
                Solution solution = new Solution();
                solution.PrintSolution(possibleCombination);
                solutionSet.Add(solution.GuessList[solution.GuessList.Count - 1]);
            }

            Assert.Equal(comboSet, solutionSet);
        }
    }
}
