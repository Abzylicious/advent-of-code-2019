using AdventOfCode.Computer;
using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public class IntcodeComputer : IntcodeParser
    {
        public IEnumerable<int> Parse(List<int> intcode)
        {
            _instructionPointer = 0;
            SetMemory(intcode);
            Run();
            return _memory.ConvertAll(x => (int)x).ToArray();
        }

        public IEnumerable<int> Parse(List<int> intcode, int noun, int verb)
        {
            _instructionPointer = 0;
            SetMemory(intcode);
            _memory[1] = noun;
            _memory[2] = verb;
            Run();
            return _memory.ConvertAll(x => (int)x).ToArray();
        }

        protected override void OnWrite() { }
        protected override void OnOutput() { }
    }
}
