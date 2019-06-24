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

            var system = new DvornikovTask.DvornikovSystem(mobilityW, countM, countN, complexityTau);
            var solution = system.Solve();


            Console.WriteLine(solution.PairsCount);
            foreach (var sln in solution.Solutions)
            {
                Utils.PrintSolution(sln);
            }
        }
    }
}