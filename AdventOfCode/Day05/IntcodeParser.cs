using System;
using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    public class IntcodeParser
    {
        private int[] _memory;
        private int _input;
        private int _output;

        public int[] Parse(List<int> intcode)
        {
            _memory = intcode.ToArray();
            Run();
            return _memory;
        }

        public int Parse(List<int> intcode, int input)
        {
            _memory = intcode.ToArray();
            _input = input;
            Run();
            return _output;
        }

        private void Run()
        {
            var instructionPointer = 0;
            while((Opcode)_memory[instructionPointer] != Opcode.END)
            {
                var instruction = GetInstruction(instructionPointer);
                instructionPointer = ExecuteInstruction(instruction, instructionPointer);
            }
        }

        private int ExecuteInstruction(Instruction instruction, int instructionPointer)
        {
            var nextInstructionPointer = instructionPointer += instruction.ParameterCount();
            switch (instruction.Opcode)
            {
                case Opcode.ADD:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] + instruction.Parameters[1];
                    return nextInstructionPointer;
                case Opcode.MULTIPLY:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] * instruction.Parameters[1];
                    return nextInstructionPointer;
                case Opcode.WRITE:
                    _memory[instruction.Parameters[0]] = _input;
                    return nextInstructionPointer;
                case Opcode.OUTPUT:
                    _output = _memory[instruction.Parameters[0]];
                    return nextInstructionPointer;
                case Opcode.JUMP_IF_TRUE:
                    return instruction.Parameters[0] != 0 ? instruction.Parameters[1] : nextInstructionPointer;
                case Opcode.JUMP_IF_FALSE:
                    return instruction.Parameters[0] == 0 ? instruction.Parameters[1] : nextInstructionPointer;
                case Opcode.LESS_THAN:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] < instruction.Parameters[1] ? 1 : 0;
                    return nextInstructionPointer;
                case Opcode.EQUALS:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] == instruction.Parameters[1] ? 1 : 0;
                    return nextInstructionPointer;
                default:
                    throw new Exception($"Opcode {instruction.Opcode} failed to execute.");
            }
        }

        private Instruction GetInstruction(int instructionPointer)
        {
            var opcode = (Opcode)GetOpcodeValue(instructionPointer);
            return new Instruction()
            {
                Opcode = opcode,
                Parameters = GetParameters(opcode, instructionPointer)
            };
        }

        private int GetOpcodeValue(int instructionPointer) => _memory[instructionPointer] % 100;

        private List<int> GetParameters(Opcode opcode, int instructionPointer)
        {
            var opcodeInstruction = _memory[instructionPointer];
            var parameters = new List<int>();

            switch (opcode)
            {
                case Opcode.WRITE:
                case Opcode.OUTPUT:
                    parameters.Add(GetValue(instructionPointer + 1, ParameterMode.IMMEDIATE));
                    break;
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
                    parameters.Add(GetValue(instructionPointer + 3, ParameterMode.IMMEDIATE));
                    break;
                default:
                    throw new Exception("Opcode instruction not found.");
            }

            return parameters;
        }

        private int GetValue(int index, ParameterMode mode) => mode switch
        {
            ParameterMode.POSITIONAL => _memory[_memory[index]],
            ParameterMode.IMMEDIATE => _memory[index],
            _ => throw new Exception("Unknown parameter mode detected.")
        };

        private ParameterMode GetMode(int opcode, int parameterNumber)
        {
            var fullCode = string.Format("{0:00000}", opcode);
            return (ParameterMode)Enum.Parse(typeof(ParameterMode), fullCode[3 - parameterNumber].ToString());
        }
    }
}
