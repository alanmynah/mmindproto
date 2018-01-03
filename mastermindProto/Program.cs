using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace mastermindProto
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Provide 4 colours for AI to solve
            Console.WriteLine("What is your combination?");
            // Get the colours and prepare for algorithm
            var combination = int.Parse(Console.ReadLine());

            if (1111 <= combination && combination <= 6666)
            {
                // Run algorithm 
                var solution = new Solution();
                solution.PrintSolution(combination);

                // Send how many turns it took to solve
                Console.WriteLine($"It took {solution.NumberOfSteps} steps to solve");

                // foreach step 
                for (int i = 0; i < solution.GuessList.Count; i++)
                {   
                    // print array of colours originally selected by the algorithm  
                    Console.WriteLine($"Guess number {i+1} was {solution.GuessList[i]}"); 
                }
            }
            else
            {
                Console.WriteLine("Sorry, please try again later");
                Console.ReadLine();
            }

            Stopwatch allGamesStopwatch = new Stopwatch();
            allGamesStopwatch.Start();

            var comboSet = FiveStepAlgorithm.CreatePermutationSet();
            
            foreach (var possibleCombination in comboSet)
            {
                Solution solution = new Solution();
                solution.PrintSolution(possibleCombination);
            }
            allGamesStopwatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = allGamesStopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime to play all possible games is " + elapsedTime);
            Console.ReadLine();
        }
    }
}
