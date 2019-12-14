namespace AdventOfCode.Computer
{
    public enum Opcode
    {
        Add = 1,
        Multiply = 2,
        Write = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        ModifyOffset = 9,
        End = 99
    }
}
