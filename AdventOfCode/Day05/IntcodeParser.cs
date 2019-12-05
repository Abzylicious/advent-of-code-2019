using System;
using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    public class IntcodeParser
    {
        private int[] _memory;

        public int[] Parse(List<int> intcode)
        {
            _memory = intcode.ToArray();
            return null;
        }
    }
}
