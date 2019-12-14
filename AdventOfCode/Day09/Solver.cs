using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Solver : ISolver
    {
        private readonly Boost _intcodeParser = new Boost();
        private readonly List<long> _intcode = new List<long>();

        public int Day { get; } = 9;
        public string Title { get; } = "--- Day 9: Sensor Boost ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadLongs(filePath, ",");
            _intcode.AddRange(input);
        }

        public string GetFirstSolution() => GetSolution();
        public string GetSecondSolution() => GetSolution();

        private string GetSolution()
        {
            var input = ConsoleReader.ReadIntegerFor("input");
            return string.Join(',', _intcodeParser.Parse(_intcode, input));
        }
    }
}
