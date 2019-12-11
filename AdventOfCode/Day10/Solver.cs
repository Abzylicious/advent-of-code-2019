using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Solver : ISolver
    {
        private readonly AsteroidMap _asteroidMap;

        public int Day { get; } = 10;
        public string Title { get; } = "--- Day 10: Monitoring Station ---";

        public Solver()
        {
            _asteroidMap = new AsteroidMap();
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
        public string GetSecondSolution() => "No solution for part 2 yet :c";

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
            var solution = _asteroidMap.GetBestScanStationPosition();
            return $"Best scan station position at X: {solution.position.X} / Y: {solution.position.Y} with {solution.detectedAsteroids} asteroids detected.";
        }
    }
}
