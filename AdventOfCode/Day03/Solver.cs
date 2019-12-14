using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Solver : ISolver
    {
        private readonly Grid _grid = new Grid();

        public int Day { get; } = 3;
        public string Title { get; } = "--- Day 3: Crossed Wires ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadText(filePath, "\n");
            _grid.WireA = new Wire(input.ElementAt(0));
            _grid.WireB = new Wire(input.ElementAt(1));
        }

        public string GetFirstSolution() => _grid.GetClosestIntersection().ToString();
        public string GetSecondSolution() => _grid.GetSmallestSteps().ToString();
    }
}
