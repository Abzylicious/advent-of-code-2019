using System.Collections.Generic;
using AdventOfCode.Computer;

namespace AdventOfCode.Day05
{
    public class TEST : IntcodeParser
    {
        public List<int> Parse(List<int> intcode)
        {
            _instructionPointer = 0;
            SetMemory(intcode);
            _inputs.Clear();
            Run();
            return _memory.ConvertAll(x => (int)x);
        }

        public int Parse(List<int> intcode, int input)
        {
            _instructionPointer = 0;
            SetMemory(intcode);
            _inputs.Clear();
            _inputs.Enqueue(input);
            return (int)Parse()[0];
        }

        protected override void OnWrite() => _memory[(int)GetAddress(1)] = _inputs.Dequeue();

        protected override void OnOutput()
        {
            _output.Clear();
            _output.Add(GetParameter(1));
        }
    }
}
