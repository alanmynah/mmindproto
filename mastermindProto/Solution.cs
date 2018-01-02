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
            var KnuthGuess = 1122; //initial best guess according to the algorithm
            Guess = KnuthGuess;
            this.GuessList.Add(Guess);
            if (combination != Guess)
            {
                FindSolution(combination);
            }

            this.NumberOfSteps = GuessList.Count;
        }

        public void FindSolution(int combination)
        {
            var set = FiveStepAlgorithm.CreatePermutationSet();
            var response = FiveStepAlgorithm.GetPegsFor(Guess, combination);
            set = FiveStepAlgorithm.RemoveOptionsBasedOnResponse(response, Guess, set);
            Guess = FiveStepAlgorithm.GetNewGuess(set);
            this.GuessList.Add(Guess);

            while (GuessList.Count < 12 && Guess != combination)
            {
                response = FiveStepAlgorithm.GetPegsFor(Guess, combination);
                if (response == "bbbb")
                {
                    break;
                }
                else
                {
                    set = FiveStepAlgorithm.RemoveOptionsBasedOnResponse(response, Guess, set);
                    Guess = FiveStepAlgorithm.GetNewGuess(set);
                    this.GuessList.Add(Guess);
                }
            }
        }
    }
}