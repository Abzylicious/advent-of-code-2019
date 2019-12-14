using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Solver : ISolver
    {
        private readonly ScanStation _asteroidMap = new ScanStation();

        public int Day { get; } = 10;
        public string Title { get; } = "--- Day 10: Monitoring Station ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadText(filePath, "\n");
            _asteroidMap.CreateMap(input.ToArray());
        }

        public string GetFirstSolution() => PartOne();
        public string GetSecondSolution() => PartTwo();

        private string PartOne()
        {
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            return $"Best scan station position at X: {position.X} / Y: {position.Y} with {detectedAsteroids} asteroids detected.";
        }

        private string PartTwo()
        {
            var (position, _) = _asteroidMap.GetBestScanStationPosition();
            var solution = _asteroidMap.GetAsteroidDestructionOrder(position).ElementAt(199);
            return $"200th asteroid to be vaporized is at X: {solution.X} / Y: {solution.Y}. Answer: {(solution.X * 100) + solution.Y}";
        }
    }
}
