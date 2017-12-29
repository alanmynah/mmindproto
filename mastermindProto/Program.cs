using System.Reflection;

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

                //foreach step 
                    //print array of colours originally selected by the algorithm
                for (int i = 0; i < solution.GuessList.Count; i++)
                {                
                    Console.WriteLine($"Guess number {i+1} was {solution.GuessList[i]}"); 
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, please try again later");
                Console.ReadLine();
            }
        }
    }
}
