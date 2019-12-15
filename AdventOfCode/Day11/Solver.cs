using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Linq;

namespace AdventOfCode.Day11
{
    public class Solver : ISolver
    {
        private PaintingRobot _paintingRobot;

        public int Day { get; } = 11;
        public string Title { get; } = "--- Day 11: Space Police ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadLongs(filePath, ",");
            _paintingRobot = new PaintingRobot(input.ToList());
            _paintingRobot.Start();
        }

        public string GetFirstSolution()
        {
            _paintingRobot.Start();
            return _paintingRobot.GetTotalPaintedPanels().ToString();
        }

        public string GetSecondSolution()
        {
            _paintingRobot.Reset();
            _paintingRobot.Start(1);
            return $"\n{_paintingRobot.GetPainting()}";
        }
    }
}
