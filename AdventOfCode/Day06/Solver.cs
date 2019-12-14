using AdventOfCode.Interfaces;
using AdventOfCode.Services;

namespace AdventOfCode.Day06
{
    public class Solver : ISolver
    {
        private readonly OrbitMap _orbitMap = new OrbitMap();

        public int Day { get; } = 6;
        public string Title { get; } = "--- Day 6: Universal Orbit Map ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadText(filePath, "\n");
            _orbitMap.CreateMap(input);
        }

        public string GetFirstSolution() => _orbitMap.OrbitCount().ToString();
        public string GetSecondSolution() => _orbitMap.GetOrbitalTransfers("you", "san").ToString();
    }
}
