using AdventOfCode.Computer;
using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public class IntcodeComputer : IntcodeParser
    {
        public int[] Parse(List<int> intcode, int noun, int verb)
        {
            _memory = intcode.ToArray();
            _memory[1] = noun;
            _memory[2] = verb;
            Run();
            return _memory;
        }
    }
}
