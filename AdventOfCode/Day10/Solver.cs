using AdventOfCode.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Solver : ISolver
    {
        private readonly ScanStation _asteroidMap;

        public int Day { get; } = 10;
        public string Title { get; } = "--- Day 10: Monitoring Station ---";

        public Solver()
        {
            _asteroidMap = new ScanStation();
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

        public string GetFirstSolution() => PartOne();
        public string GetSecondSolution() => PartTwo();

        private void ReadInput(string inputPath)
        {
            try
            {
                _asteroidMap.CreateMap(File.ReadAllLines(inputPath));
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }

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
