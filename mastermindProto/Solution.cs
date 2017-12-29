using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermindProto
{
    public class Solution
    {
        public Solution()
        {
            NumberOfSteps = 0;
            GuessList = new List<int>();
        }

        public int NumberOfSteps { get; set; }

        public List<int> GuessList { get; set; }

        public int Guess { get; set; }

        public void PrintSolution(int combination)
        {
            var KnuthGuess = 1122;
            this.GuessList.Add(KnuthGuess);
//            if (combination != KnuthGuess)
//            {
//                FindSolution(combination);
//            }

            this.NumberOfSteps = GuessList.Count;
        }

//        public void FindSolution(int combination)
//        {
//            var set = FiveStepAlgorithm.CreatePermutationSet();
//            var response = FiveStepAlgorithm.GetPegsFor(1122, combination);
//            set = FiveStepAlgorithm.RemoveOptionsBasedOn(response, set);
//            var guess = FiveStepAlgorithm.GetNewGuess();
//
//            while (GuessList.Count < 12 && guess != combination)
//            {
//                response = FiveStepAlgorithm.GetPegsFor(guess, combination);
//
//                if (response == "wwww")
//                {
//                    this.GuessList.Add(Guess);
//                }
//                else
//                {
//                    set = FiveStepAlgorithm.RemoveOptionsBasedOn(response, set);
//                    this.GuessList.Add(Guess);
//                }
//            }
//        }
    }
}