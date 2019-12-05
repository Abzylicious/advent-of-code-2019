using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    public class Instruction
    {
        public int Opcode { get; set; }
        public List<int> Parameters { get; set; }

        public Instruction()
        {
            Parameters = new List<int>();
        }

        public int ParameterCount() => Parameters.Count + 1;
    }
}
