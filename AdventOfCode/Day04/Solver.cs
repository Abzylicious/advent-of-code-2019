using AdventOfCode.Interfaces;
using System;

namespace AdventOfCode.Day04
{
    public class Solver : ISolver
    {
        private readonly PasswordCombiner _passwordCombiner;
        private int _start = 0;
        private int _end = 0;

        public int Day { get; } = 4;
        public string Title { get; } = "--- Day 4: Secure Container ---";

        public Solver()
        {
            _passwordCombiner = new PasswordCombiner();
        }

        public void Precondition()
        {
            _start = ReadInteger("start");
            _end = ReadInteger("end");
        }

        public string GetFirstSolution() => _passwordCombiner.GetValidCombinations(_start, _end, new NoDecreaseRule(), new AdjacentDigitsMatchOnceRule()).ToString();
        public string GetSecondSolution() => "No solution for part 2 yet :c";

        private int ReadInteger(string descriptor)
        {
            Console.Write($"Enter your {descriptor} value: ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("The entered value is not a number: ");
            }
            return result;
        }
    }
}
