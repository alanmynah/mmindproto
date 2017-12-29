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
            
            //take combination and take digits from guess and get the exact matches in combination
            for (var i = 0; i < guessArray.Length; i++)
            {
                //get the exact matches in combination
                if (combinationArray[i] == guessArray[i])
                {
                    //add to arr in the same position [b, n, n, n]
                    feedbackPegs[i] = "b";
                    //replace exact match in combination with "0"
                    combinationArray[i] = 0;
                    //now 1234 with 1122 guess will look like 0234 
                }
            }

            //take unique numbers in guess, which is 12 
            var uniqueMembersOfGuessArray = guessArray.Distinct().ToArray();
            //and check if they are in 0234
            foreach (var member in uniqueMembersOfGuessArray)
            {
                if (combinationArray.Contains(member))
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
    }
}
