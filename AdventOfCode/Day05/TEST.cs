using System.Collections.Generic;
using AdventOfCode.Computer;

namespace AdventOfCode.Day05
{
    public class TEST : IntcodeParser
    {
        private int _input;
        private int _output;

        public int Parse(List<int> intcode, int input)
        {
            _memory = intcode.ConvertAll(n => (long)n);
            _input = input;
            Run();
            return _output;
        }

        protected override int ExecuteInstruction(Instruction instruction, int instructionPointer)
        {
            var nextInstructionPointer = instructionPointer + instruction.ParameterCount();
            switch (instruction.Opcode)
            {
                case Opcode.WRITE:
                    _memory[(int)instruction.Parameters[0]] = _input;
                    return nextInstructionPointer;
                case Opcode.OUTPUT:
                    _output = (int)instruction.Parameters[0];
                    return nextInstructionPointer;
      
            }
            return base.ExecuteInstruction(instruction, instructionPointer);
        }

        protected override List<long> GetParameters(Opcode opcode, int instructionPointer)
        {
            var opcodeInstruction = _memory[instructionPointer];
            var parameters = new List<long>();

            switch (opcode)
            {
                case Opcode.WRITE:
                    parameters.Add(GetValue(instructionPointer + 1, ParameterMode.IMMEDIATE));
                    break;
                case Opcode.OUTPUT:
                    parameters.Add(GetValue(instructionPointer + 1, GetMode(opcodeInstruction, 1)));
                    break;
                default:
                    return base.GetParameters(opcode, instructionPointer);
            }

            return parameters;
        }
    }
}
