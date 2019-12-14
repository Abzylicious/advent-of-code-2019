using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Collections.Generic;

namespace AdventOfCode.Day01
{
    public class Solver : ISolver
    {
        private readonly FuelCalculator _fuelCalculator = new FuelCalculator();
        private readonly List<int> _masses = new List<int>();

        public int Day { get; } = 1;
        public string Title { get; } = "--- Day 1: The Tyranny of the Rocket Equation ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadIntegers(filePath, "\n");
            _masses.AddRange(input);
        }

        public string GetFirstSolution() => PartOne().ToString();
        public string GetSecondSolution() => PartTwo().ToString();

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
