using AdventOfCode.Interfaces;
using AdventOfCode.Services;

namespace AdventOfCode.Day14
{
    public class Solver : ISolver
    {
        private Refinery _refinery;

        public int Day { get; } = 14;
        public string Title { get; } = "--- Day 14: Space Stoichiometry ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var reactions = InputFileReader.ReadChemicalReactions(filePath);
            _refinery = new Refinery(reactions.ToArray());
        }

        public string GetFirstSolution() => $"The minimum amount of ORE required to produce exactly 1 FUEL is { _refinery.GetOresForSingleFuel() }.";
        public string GetSecondSolution() => $"Given 1 trillion ORE, the maximum amount of FUEL you can produce is { _refinery.GetMaxFuel(1000000000000L) }.";
    }
}
