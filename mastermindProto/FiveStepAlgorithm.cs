using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace mastermindProto
{
    public class FiveStepAlgorithm
    {
        public static List<int> CreatePermutationSet()
        {
            List<int> permutationSet = new List<int>();
            var choice = "123456";
            var set = choice.Select(x => x.ToString());
            int size = 4;
            for (int i = 0; i < size - 1; i++)
                set = set.SelectMany(x => choice, (x, y) => x + y);
            foreach (var item in set)
            {
                permutationSet.Add(int.Parse(item));
            }

            return permutationSet;
        }

        public static string GetPegsFor(int guess, int combination)
        {
            //blank array [n, n, n, n]
            string[] feedbackPegs = {"n", "n", "n", "n"};

            //split guess and combination into same sized int arrays
            int[] guessArray = Array.ConvertAll(guess.ToString().ToArray(), x => (int)x - 48);
            int[] combinationArray = Array.ConvertAll(combination.ToString().ToArray(), x => (int)x - 48);
            List<int> ignoreArray = new List<int> {};
            
            //take combination and take digits from guess and get the exact matches in combination
            for (var i = 0; i < guessArray.Length; i++)
            {
                //get the exact matches in combination
                if (combinationArray[i] == guessArray[i])
                {
                    //add to arr in the same position [b, n, n, n]
                    feedbackPegs[i] = "b";
                    //replace exact match in combination with "0"
                    ignoreArray.Add(combinationArray[i]);
                    combinationArray[i] = 0;
                    //now 1234 with 1122 guess will look like 0234 
                }
            }

            //take unique numbers in guess, which is 12 
            var uniqueMembersOfGuessArray = guessArray.Distinct().ToArray();
            //and check if they are in 0234
            foreach (var member in uniqueMembersOfGuessArray)
            {
                if (combinationArray.Contains(member) && !ignoreArray.Contains(member))
                {
                    //for every match, take array and change the first "n" to ["w"]
                    var nToReplace = Array.IndexOf(feedbackPegs, "n");
                    feedbackPegs[nToReplace] = "w";
                }
            }
            //take the whole array and convert to string
            //return string
            return String.Join(string.Empty, feedbackPegs);
            
        }

        public static List<int> RemoveOptionsBasedOnResponse(string response, int guess, List<int> set)
        {
            //Remove from S any code that would not give the same response if it 
            //(the guess) were the code.
            var newSet = new List<int> (set);
            //So effectively:
            //We made a guess 1122 (or any other) and got a response. 
            //Let's get the pegs for all of the options in set S,
            for (var i = 0; i < set.Count; i++)
            {

                if (GetPegsFor(guess, set[i]) != response)
                {
                    newSet.Remove(set[i]);
                }
            }
            newSet.Remove(guess);
            return newSet;
        }

        public static int GetNewGuess(List<int> set)
        {
//            Apply minimax technique to find a next guess as follows: 
//            For each possible guess, that is, any unused code of the 1296 not just those in S, 
//            calculate how many possibilities in S would be eliminated for each possible 
//            colored/white peg score. The score of a guess is the minimum number of possibilities 
//            it might eliminate from S. A single pass through S for each unused code of the 1296 
//            will provide a hit count for each colored/white peg score found; the 
//            colored/white peg score with the highest hit count will eliminate the fewest 
//            possibilities; calculate the score of a guess by using 
//            "minimum eliminated" = "count of elements in S" - (minus) "highest hit count". 
//            From the set of guesses with the maximum score, select one as the next guess, 
//            choosing a member of S whenever possible. (Knuth follows the convention of choosing 
//            the guess with the least numeric value e.g. 2345 is lower than 3456. Knuth also 
//            gives an example showing that in some cases no member of S will be among the highest 
//            scoring guesses and thus the guess cannot win on the next turn, yet will be 
//            necessary to assure a win in five.)
            return 1234;
        }
    }
}
