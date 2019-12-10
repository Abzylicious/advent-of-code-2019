using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day09
{
    public class Solver : ISolver
    {
        private readonly Boost _intcodeParser;
        private readonly List<long> _intcode;

        public int Day { get; } = 9;
        public string Title { get; } = "--- Day 9: Sensor Boost ---";

        public Solver()
        {
            _intcodeParser = new Boost();
            _intcode = new List<long>();
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

        public string GetFirstSolution() => GetSolution();
        public string GetSecondSolution() => GetSolution();

        private void ReadInput(string inputPath)
        {
            try
            {
                foreach (var code in File.ReadAllText(inputPath).Split(','))
                {
                    _intcode.Add(Convert.ToInt64(code));
                }
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }

        private int ReadInteger()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("The entered value is not a number: ");
            }
            return result;
        }

        private string GetSolution()
        {
            Console.Write("Enter your input value: ");
            var input = ReadInteger();
            return string.Join(',', _intcodeParser.Parse(_intcode, input));
        }
    }
}
