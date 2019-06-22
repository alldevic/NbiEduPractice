using System;
using DvornikovTask;

namespace ConsoleView
{
    public static class Utils
    {
        public static void SetValues(out uint mobilityW, out uint countM, out uint countN, out uint complexityTau)
        {
            try
            {
                GetUintValueFromConsole("Введите подвижность цепи W:", "W", out mobilityW);
                GetUintValueFromConsole("Введите число общих связей, наложенных на систему M: :", "M", out countM);
                GetUintValueFromConsole("Введите общее исло подвижных звеньев N:", "N", out countN);
                GetUintValueFromConsole("Введите максимальная допустимая сложность звена t:", "t", out complexityTau);
            }
            catch (Exception)
            {
                Console.WriteLine("Введены некорректные данные!");
                throw;
            }
        }

        public static void GetUintValueFromConsole(string description, string label, out uint mobilityW)
        {
            Console.WriteLine(description);
            try
            {
                mobilityW = uint.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Введено некоорректное значение {label}");
                throw;
            }
        }

        public static void PrintSolution(SystemSolution sln)
        {
            throw new NotImplementedException();
        }
    }
}