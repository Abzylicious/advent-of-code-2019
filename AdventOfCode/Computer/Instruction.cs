using System.Collections.Generic;

namespace AdventOfCode.Computer
{
    public class Instruction
    {
        public Opcode Opcode { get; set; }
        public List<long> Parameters { get; set; }

        public Instruction()
        {
            Parameters = new List<long>();
        }

        public int ParameterCount() => Parameters.Count + 1;
    }
}
