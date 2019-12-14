using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class Solver : ISolver
    {
        private readonly IntcodeComputer _intcodeParser = new IntcodeComputer();
        private readonly List<int> _intcode = new List<int>();

        public int Day { get; } = 2;
        public string Title { get; } = "--- Day 2: 1202 Program Alarm ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadIntegers(filePath, ",");
            _intcode.AddRange(input);
        }

        public string GetFirstSolution() => _intcodeParser.Parse(_intcode, 12, 2).ElementAt(0).ToString();
        public string GetSecondSolution() => PartTwo().ToString();

        private int PartTwo()
        {
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    if (_intcodeParser.Parse(_intcode, noun, verb).ElementAt(0) == 19690720)
                    {
                        Console.WriteLine($"noun: {noun}, verb: {verb}");
                        return (100 * noun) + verb;
                    }
                }
            }
            return -1;
        }
    }
}
