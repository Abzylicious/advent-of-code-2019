using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day07
{
    public class Solver : ISolver
    {
        private readonly AmplifierService _amplifierService;
        private readonly List<int> _intcode;
        private readonly List<int> _phaseCodes;
        private readonly List<int> _phaseCodesFeedbackLoopMode;

        public int Day { get; } = 7;
        public string Title { get; } = "--- Day 7: Amplification Circuit ---";

        public Solver()
        {
            _amplifierService = new AmplifierService();
            _intcode = new List<int>();
            _phaseCodes = new List<int>() { 0, 1, 2, 3, 4 };
            _phaseCodesFeedbackLoopMode = new List<int>() { 5, 6, 7, 8, 9 };
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

        public string GetFirstSolution() => _amplifierService.GetHighestThrusterSignal(_intcode, _phaseCodes).ToString();
        public string GetSecondSolution() => _amplifierService.GetHighestThrusterSignal(_intcode, _phaseCodesFeedbackLoopMode, true).ToString();

        private void ReadInput(string inputPath)
        {
            try
            {
                foreach (var code in File.ReadAllText(inputPath).Split(','))
                {
                    _intcode.Add(Convert.ToInt32(code));
                }
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }
    }
}
