using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class Solver : ISolver
    {
        private readonly IntcodeParser _intcodeParser;
        private readonly List<int> _intcode;

        public int Day { get; } = 2;
        public string Title { get; } = "--- Day 2: 1202 Program Alarm ---";

        public Solver()
        {
            _intcodeParser = new IntcodeParser();
            _intcode = new List<int>();
        }

        public void Precondition()
        {
            var filePath = string.Empty;
            while (!File.Exists(filePath))
            {
                Console.Write("Path to input.txt: ");
                filePath = Console.ReadLine();
            }
            ReadInput(filePath);
        }

        public string GetFirstSolution() => _intcodeParser.Parse(_intcode, 12, 2).ElementAt(0).ToString();
        public string GetSecondSolution() => PartTwo().ToString();

        private void ReadInput(string inputPath)
        {
            try
            {
                foreach (var code in File.ReadAllText(inputPath).Split(','))
                {
                    _intcode.Add(Convert.ToInt32(code));
                }
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }

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
