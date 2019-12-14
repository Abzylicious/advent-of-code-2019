using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class Solver : ISolver
    {
        private readonly AmplifierService _amplifierService = new AmplifierService();
        private readonly List<int> _intcode = new List<int>();
        private readonly List<int> _phaseCodes = new List<int>() { 0, 1, 2, 3, 4 };
        private readonly List<int> _phaseCodesFeedbackLoopMode = new List<int>() { 5, 6, 7, 8, 9 };

        public int Day { get; } = 7;
        public string Title { get; } = "--- Day 7: Amplification Circuit ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadIntegers(filePath, ",");
            _intcode.AddRange(input);
        }

        public string GetFirstSolution() => _amplifierService.GetHighestThrusterSignal(_intcode, _phaseCodes).ToString();
        public string GetSecondSolution() => _amplifierService.GetHighestThrusterSignal(_intcode, _phaseCodesFeedbackLoopMode, true).ToString();
    }
}
