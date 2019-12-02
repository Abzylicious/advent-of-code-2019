namespace AdventOfCode.Day02
{
    public class Instruction
    {
        public int Opcode { get; set; }
        public int ParameterA { get; set; }
        public int ParameterB { get; set; }
        public int DestinationIndex { get; set; }
    }
}
