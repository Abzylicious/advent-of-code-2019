using AdventOfCode.Services;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solveService = new SolveService();
            Console.WriteLine("Advent of Code 2019");

            do
            {
                var day = ReadDay();
                solveService.GetSolution(day);
                Console.WriteLine("\nDo you want to check upon other days? Press any key to continue, press 'ESCAPE' to exit.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static int ReadDay()
        {
            Console.Write("\nEnter a day to view its solution: ");
            var daySelection = ReadInteger();
            if (!IsCalendarDay(daySelection))
            {
                Console.WriteLine("Code of Advent takes place between the 1. and 25. of December. Please select a fitting value.");
                ReadDay();
            }

            return daySelection;
        }

        private static int ReadInteger()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("The entered value is not a number: ");
            }
            return result;
        }

        private static bool IsCalendarDay(int day) => day >= 0 && day <= 25;
    }
}
