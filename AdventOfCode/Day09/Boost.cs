using AdventOfCode.Computer;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Boost : IntcodeParser
    {
        public List<long> Parse(List<long> intcode, int input)
        {
            _inputs.Enqueue(input);
            return Parse(intcode);
        }

        public List<long> Parse(List<long> intcode)
        {
            _output.Clear();
            _instructionPointer = 0;
            _relativeBase = 0;
            SetMemory(intcode);
            Run();
            return _output;
        }

        protected override void OnWrite() => _memory[(int)GetAddress(1)] = _inputs.Dequeue();
        protected override void OnOutput() => _output.Add(GetParameter(1));
    }
}
