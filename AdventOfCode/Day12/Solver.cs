using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Linq;

namespace AdventOfCode.Day12
{
    public class Solver : ISolver
    {
        private readonly FourMoonMotionSimulator _fourMoonMotionSimulator = new FourMoonMotionSimulator();
        private Moon Io, Europa, Ganymede, Callisto;

        public int Day { get; } = 12;
        public string Title { get; } = "--- Day 12: The N-Body Problem ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadCoordinates(filePath);

            Io = new Moon(input[0]);
            Europa = new Moon(input[1]);
            Ganymede = new Moon(input[2]);
            Callisto = new Moon(input[3]);
        }

        public string GetFirstSolution() => _fourMoonMotionSimulator.Run(Io, Europa, Ganymede, Callisto).ElementAt(999).TotalEnergy().ToString();
        public string GetSecondSolution() => _fourMoonMotionSimulator.GetStepsToRepeat(Io, Europa, Ganymede, Callisto).ToString();
    }
}
