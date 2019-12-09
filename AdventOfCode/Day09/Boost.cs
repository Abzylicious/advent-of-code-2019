using AdventOfCode.Computer;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Boost : IntcodeParser
    {
        private int _relativeBase;
        private int _input;
        private readonly List<long> _output = new List<long>();

        public List<long> Parse(List<long> intcode, int input)
        {
            _input = input;
            return Parse(intcode);
        }

        public List<long> Parse(List<long> intcode)
        {
            _output.Clear();
            _relativeBase = 0;
            _memory = intcode;
            Run();
            return _output;
        }

        protected override int ExecuteInstruction(Instruction instruction, int instructionPointer)
        {
            var nextInstructionPointer = instructionPointer + instruction.ParameterCount();
            switch (instruction.Opcode)
            {
                case Opcode.WRITE:
                    SetMemoryAt((int)instruction.Parameters[0], _input);
                    return nextInstructionPointer;
                case Opcode.OUTPUT:
                    _output.Add(instruction.Parameters[0]);
                    return nextInstructionPointer;
                case Opcode.MODIFY_OFFSET:
                    _relativeBase += (int)instruction.Parameters[0];
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
                    var mode = GetMode(opcodeInstruction, 1);
                    parameters.Add(GetValue(instructionPointer + 1,
                        mode == ParameterMode.RELATIVE ? ParameterMode.RELATIVE : ParameterMode.IMMEDIATE));
                    break;
                case Opcode.OUTPUT:
                case Opcode.MODIFY_OFFSET:
                    parameters.Add(GetValue(instructionPointer + 1, GetMode(opcodeInstruction, 1)));
                    break;
                default:
                    return base.GetParameters(opcode, instructionPointer);
            }

            return parameters;
        }

        protected override long GetValue(int index, ParameterMode mode) => mode switch
        {
            ParameterMode.POSITIONAL => (int)_memory[index] > _memory.Count - 1 ? 0 : _memory[(int)_memory[index]],
            ParameterMode.IMMEDIATE => _memory[index],
            ParameterMode.RELATIVE => _memory[(int)_memory[index] + _relativeBase],
            _ => throw new Exception("Unknown parameter mode detected.")
        };
    }
}
