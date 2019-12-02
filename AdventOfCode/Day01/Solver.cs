using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day01
{
    public class Solver : ISolver
    {
        private readonly FuelCalculator _fuelCalculator;
        private readonly ICollection<int> _masses;

        public int Day { get; } = 1;
        public string Title { get; } = "--- Day 1: The Tyranny of the Rocket Equation ---";

        public Solver()
        {
            _fuelCalculator = new FuelCalculator();
            _masses = new List<int>();
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

        public string GetFirstSolution() => PartOne().ToString();
        public string GetSecondSolution() => PartTwo().ToString();

        private void ReadInput(string inputPath)
        {
            try
            {
                foreach (var input in File.ReadAllLines(inputPath))
                {
                    _masses.Add(Convert.ToInt32(input));
                }
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }

        private int PartOne()
        {
            var result = 0;
            foreach (var mass in _masses)
            {
                result += _fuelCalculator.GetFuel(mass);
            }

            return result;
        }

        private int PartTwo()
        {
            var result = 0;
            foreach (var mass in _masses)
            {
                result += _fuelCalculator.GetTotalFuel(mass);
            }
            return result;
        }
    }
}
