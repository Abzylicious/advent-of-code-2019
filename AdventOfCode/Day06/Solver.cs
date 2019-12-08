using AdventOfCode.Interfaces;
using System;
using System.IO;

namespace AdventOfCode.Day06
{
    public class Solver : ISolver
    {
        private readonly OrbitMap _orbitMap;

        public int Day { get; } = 6;
        public string Title { get; } = "--- Day 6: Universal Orbit Map ---";

        public Solver()
        {
            _orbitMap = new OrbitMap();
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

        public string GetFirstSolution() => _orbitMap.OrbitCount().ToString();
        public string GetSecondSolution() => _orbitMap.GetOrbitalTransfers("you", "san").ToString();

        private void ReadInput(string inputPath)
        {
            try
            {
                _orbitMap.CreateMap(File.ReadAllLines(inputPath));
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }
    }
}
