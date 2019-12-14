using AdventOfCode.Interfaces;
using AdventOfCode.Services;

namespace AdventOfCode.Day04
{
    public class Solver : ISolver
    {
        private readonly PasswordCombiner _passwordCombiner = new PasswordCombiner();
        private int _start;
        private int _end;

        public int Day { get; } = 4;
        public string Title { get; } = "--- Day 4: Secure Container ---";

        public void Precondition()
        {
            _start = ConsoleReader.ReadIntegerFor("start");
            _end = ConsoleReader.ReadIntegerFor("end");
        }

        public string GetFirstSolution() => _passwordCombiner.GetValidCombinations(_start, _end,
            new NoDecreaseRule(), new AdjacentDigitsMatchOnceRule()).ToString();

        public string GetSecondSolution() => _passwordCombiner.GetValidCombinations(_start, _end,
            new NoDecreaseRule(), new AdjacentDigitsMatchOnlyOnceRule()).ToString();
    }
}
