using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer
{
    public class IntcodeParser
    {
        protected List<long> _memory;

        public int[] Parse(List<int> intcode)
        {
            _memory = intcode.ConvertAll(n => (long)n);
            Run();
            return _memory.ConvertAll(n => (int)n).ToArray();
        }

        protected virtual void Run()
        {
            var instructionPointer = 0;
            while ((Opcode)_memory[instructionPointer] != Opcode.END)
            {
                var instruction = GetInstruction(instructionPointer);
                instructionPointer = ExecuteInstruction(instruction, instructionPointer);
            }
        }

        protected virtual int ExecuteInstruction(Instruction instruction, int instructionPointer)
        {
            var nextInstructionPointer = instructionPointer + instruction.ParameterCount();
            switch (instruction.Opcode)
            {
                case Opcode.ADD:
                    SetMemoryAt((int)instruction.Parameters[2], instruction.Parameters[0] + instruction.Parameters[1]);
                    return nextInstructionPointer;
                case Opcode.MULTIPLY:
                    SetMemoryAt((int)instruction.Parameters[2], instruction.Parameters[0] * instruction.Parameters[1]);
                    return nextInstructionPointer;
                case Opcode.JUMP_IF_TRUE:
                    return instruction.Parameters[0] != 0 ? (int)instruction.Parameters[1] : nextInstructionPointer;
                case Opcode.JUMP_IF_FALSE:
                    return instruction.Parameters[0] == 0 ? (int)instruction.Parameters[1] : nextInstructionPointer;
                case Opcode.LESS_THAN:
                    SetMemoryAt((int)instruction.Parameters[2], instruction.Parameters[0] < instruction.Parameters[1] ? 1 : 0);
                    return nextInstructionPointer;
                case Opcode.EQUALS:
                    SetMemoryAt((int)instruction.Parameters[2], instruction.Parameters[0] == instruction.Parameters[1] ? 1 : 0);
                    return nextInstructionPointer;
                default:
                    throw new Exception($"Opcode {instruction.Opcode} failed to execute.");
            }
        }

        protected virtual List<long> GetParameters(Opcode opcode, int instructionPointer)
        {
            var opcodeInstruction = _memory[instructionPointer];
            var parameters = new List<long>();

            switch (opcode)
            {
                case Opcode.JUMP_IF_TRUE:
                case Opcode.JUMP_IF_FALSE:
                    parameters.Add(GetValue(instructionPointer + 1, GetMode(opcodeInstruction, 1)));
                    parameters.Add(GetValue(instructionPointer + 2, GetMode(opcodeInstruction, 2)));
                    break;
                case Opcode.ADD:
                case Opcode.MULTIPLY:
                case Opcode.LESS_THAN:
                case Opcode.EQUALS:
                    parameters.Add(GetValue(instructionPointer + 1, GetMode(opcodeInstruction, 1)));
                    parameters.Add(GetValue(instructionPointer + 2, GetMode(opcodeInstruction, 2)));
                    var mode = GetMode(opcodeInstruction, 3);
                    parameters.Add(GetValue(instructionPointer + 3,
                        mode == ParameterMode.RELATIVE ? ParameterMode.RELATIVE : ParameterMode.IMMEDIATE));
                    break;
                default:
                    throw new Exception("Opcode instruction not found.");
            }

            return parameters;
        }

        protected long GetOpcodeValue(int instructionPointer) => _memory[instructionPointer] % 100;

        protected virtual long GetValue(int index, ParameterMode mode) => mode switch
        {
            ParameterMode.POSITIONAL => _memory[(int)_memory[index]],
            ParameterMode.IMMEDIATE => _memory[index],
            _ => throw new Exception("Unknown parameter mode detected.")
        };

        protected ParameterMode GetMode(long opcode, int parameterNumber)
        {
            try
            {
                var fullCode = string.Format("{0:00000}", opcode);
                return (ParameterMode)Enum.Parse(typeof(ParameterMode), fullCode[3 - parameterNumber].ToString());
            }
            catch
            {
                throw new Exception("Number of parameters exceeded.");
            }
        }

        protected virtual void SetMemoryAt(int index, long value)
        {
            if (_memory.Count - 1 < index)
            {
                var newElements = index - _memory.Count + 1;
                for (int i = 0; i < newElements; i++)
                {
                    _memory.Add(0);
                }
            }
            _memory[index] = value;
        }

        protected Instruction GetInstruction(int instructionPointer)
        {
            var opcode = (Opcode)GetOpcodeValue(instructionPointer);
            return new Instruction()
            {
                Opcode = opcode,
                Parameters = GetParameters(opcode, instructionPointer)
            };
        }
    }
}
