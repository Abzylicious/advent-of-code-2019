using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    public class Solver : ISolver
    {
        private readonly TEST _intcodeParser = new TEST();
        private readonly List<int> _intcode = new List<int>();
        private int _input;

        public int Day { get; } = 5;
        public string Title { get; } = "--- Day 5: Sunny with a Chance of Asteroids ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadIntegers(filePath, ",");
            _intcode.AddRange(input);
        }

        public string GetFirstSolution() => GetSolution();
        public string GetSecondSolution() => GetSolution();

        private string GetSolution()
        {
            _input = ConsoleReader.ReadIntegerFor("input");
            return _intcodeParser.Parse(_intcode, _input).ToString();
        }
    }
}
