using System;
using System.Collections.Generic;
using System.Linq;
/*Hundred Prisoners - Nihat Yiğitcan BADEM */
namespace HundredPrisoners
{
    class Program
    {
        

        /// <summary>
        /// Lets prisoners randomly go through drawers.
        /// </summary>
        /// <returns>The success rate.</returns>
        static bool RandomSim()
        {
            List<int> Lotto = Enumerable.Range(0, 100).OrderBy(key => Guid.NewGuid()).ToList();
            for (int prisoner = 0; prisoner < 100; prisoner++)
            {
                
                bool success = false;
                for(int tries = 0; tries <50; tries++)
                {
                    if(Lotto[tries] == prisoner)
                    {
                        success = true;
                        break;
                    }
                }

                if (success == false) return false;
            }
            return true; 

        }
        
        /// <summary>
        /// Runs the simulation using the optimal strategy.
        /// </summary>
        /// <returns>The success rate.</returns>
        static bool OptimalSim()
        {
            List<int> Cards = Enumerable.Range(0, 100).OrderBy(key => Guid.NewGuid()).ToList();
            
            for (int prisoner = 0; prisoner < 100; prisoner++)
            {
                int Destination = prisoner;
                bool Success = false;
                for (int tries = 0; tries <50; tries++)
                {
                    if(Cards[Destination] == prisoner)
                    {
                        Success = true;
                        break;
                    }
                    else
                    {
                        Destination = Cards[Destination];
                    }
                }
                if (Success == false) return false;

            }
            return true;
        }

        /// <summary>
        /// Also puts the true, corresponding card to the index with the same number,
        /// in addition to the standard optimal strategy. Efficiency is unknown.
        /// </summary>
        /// <returns>The success rate.</returns>
        static bool OptimalPlus() 
        {
            List<int> Cards = Enumerable.Range(0, 100).OrderBy(key => Guid.NewGuid()).ToList();

            for (int prisoner = 0; prisoner < 100; prisoner++)
            {
                int Destination = prisoner;
                bool Success = false;
                for (int tries = 0; tries < 50; tries++)
                {
                    if (Cards[Destination] == prisoner)
                    {
                        int temp = Cards[prisoner];
                        Cards[prisoner] = Cards[Destination];
                        Cards[Destination] = temp;
                        Success = true;
                        break;
                    }
                    else
                    {
                        Destination = Cards[Destination];
                    }
                }
                if (Success == false) return false;

            }
            return true;
        }

        static double Run(Func<bool> Sim, uint Tries)
        {
            Console.WriteLine("Running simulation: {0}", Sim.Method.Name);
            int Success = 0;
            for(int tries = 0; tries < Tries; tries++)
            {
                Console.Write("Now running simulation #{0}\r", tries + 1);
                if (Sim()) Success++;
            }
            Console.WriteLine("\nSimulation complete!");
            return 100.0 * Success / Tries;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hundred Prisoners simulation.\nA practice program by nybadem.\n");
            uint TotalSims = 100000;
            Console.WriteLine("Total Simulations to be Executed: {0}\n", TotalSims);
            Console.WriteLine("Success Rate: {0:0.0000000}%\n", Run(OptimalSim, TotalSims));
            Console.WriteLine("Success Rate: {0:0.0000000}%\n", Run(OptimalPlus, TotalSims));
            Console.WriteLine("Success Rate: {0:0.0000000}%\n", Run(RandomSim, TotalSims));
            Console.WriteLine("Press any key to terminate the program.");
            Console.ReadKey(true);
           
        }
    }
}
