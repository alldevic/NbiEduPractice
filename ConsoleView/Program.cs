using System;
using DvornikovTask;

namespace ConsoleView
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            uint mobilityW, countM, countN, complexityTau;

            try
            {
                Utils.SetValues(out mobilityW, out countM, out countN, out complexityTau);
                DvornikovSystem.CheckArgs(mobilityW, countM, countN, complexityTau);
            }
            catch (Exception)
            {
                Console.WriteLine("Приложение будет завершено");
                return;
            }

            var system = new DvornikovSystem(mobilityW, countM, countN, complexityTau);
            var solution = system.Solve();
            Console.WriteLine();

            PrintSolution(solution);
        }

        private static void PrintSolution(DvornikovSolution solution)
        {
            Console.Write("Система c параметрами ");
            Console.Write($"n={solution.SystemCountN}, m={solution.SystemCountM}, ");
            Console.Write($"w={solution.SystemMobilityW}, t={solution.SystemComplexityTau} ");
            Console.WriteLine($"имеет {solution.SolutionsCount} решений");
            Console.WriteLine();

            foreach (var sln in solution.Solutions)
            {
                Utils.PrintSolution(sln.Key, "n", ", ");
                foreach (var value in sln.Value)
                {
                    Console.Write("   ");
                    Utils.PrintSolution(value, "k", ", ");
                }

                Console.WriteLine();
            }
        }
    }
}