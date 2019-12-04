using AdventOfCode.Interfaces;
using System;
using System.IO;

namespace AdventOfCode.Day03
{
    public class Solver : ISolver
    {
        private readonly Grid _grid;
        private readonly string[] _wirepaths;

        public int Day { get; } = 3;
        public string Title { get; } = "--- Day 3: Crossed Wires ---";

        public Solver()
        {
            _grid = new Grid();
            _wirepaths = new string[2];
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
                var input = File.ReadAllLines(inputPath);
                _wirepaths[0] = input[0];
                _wirepaths[1] = input[1];
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }

        private int PartOne()
        {
            _grid.WireA = new Wire(_wirepaths[0]);
            _grid.WireB = new Wire(_wirepaths[1]);
            return _grid.GetClosestIntersection();
        }

        private int PartTwo()
        {
            _grid.WireA = new Wire(_wirepaths[0]);
            _grid.WireB = new Wire(_wirepaths[1]);
            return _grid.GetSmallestSteps();
        }
    }
}
