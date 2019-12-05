using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day05
{
    public class Solver : ISolver
    {
        private readonly IntcodeParser _intcodeParser;
        private readonly List<int> _intcode;
        private int _input;

        public int Day { get; } = 5;
        public string Title { get; } = "--- Day 5: Sunny with a Chance of Asteroids ---";

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

        public string GetFirstSolution() => GetSolution();
        public string GetSecondSolution() => GetSolution();

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
            _input = ReadInteger();
            return _intcodeParser.Parse(_intcode, _input).ToString();
        }
    }
}
