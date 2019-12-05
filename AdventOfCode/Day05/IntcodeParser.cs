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
            while(_memory[instructionPointer] != 99)
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
                case 1:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] + instruction.Parameters[1];
                    return nextInstructionPointer;
                case 2:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] * instruction.Parameters[1];
                    return nextInstructionPointer;
                case 3:
                    _memory[instruction.Parameters[0]] = _input;
                    return nextInstructionPointer;
                case 4:
                    _output = _memory[instruction.Parameters[0]];
                    return nextInstructionPointer;
                case 5:
                    return instruction.Parameters[0] != 0 ? instruction.Parameters[1] : nextInstructionPointer;
                case 6:
                    return instruction.Parameters[0] == 0 ? instruction.Parameters[1] : nextInstructionPointer;
                case 7:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] < instruction.Parameters[1] ? 1 : 0;
                    return nextInstructionPointer;
                case 8:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] == instruction.Parameters[1] ? 1 : 0;
                    return nextInstructionPointer;
                default:
                    throw new Exception($"Opcode {instruction.Opcode} failed to execute.");
            }
        }

        private Instruction GetInstruction(int instructionPointer)
        {
            var opcode = GetOpcode(_memory[instructionPointer]);
            return new Instruction()
            {
                Opcode = opcode,
                Parameters = GetParameters(opcode, instructionPointer)
            };
        }

        private int GetOpcode(int instructionValue) => instructionValue % 100;

        private List<int> GetParameters(int opcode, int instructionPointer)
        {
            var instructionValue = _memory[instructionPointer];
            var parameters = new List<int>();

            switch (opcode)
            {
                case 3:
                case 4:
                    parameters.Add(GetTargetIndexValue(instructionPointer + 1, true));
                    break;
                case 5:
                case 6:
                    parameters.Add(GetTargetIndexValue(instructionPointer + 1, GetMode(instructionValue, 1)));
                    parameters.Add(GetTargetIndexValue(instructionPointer + 2, GetMode(instructionValue, 2)));
                    break;
                case 1:
                case 2:
                case 7:
                case 8:
                    parameters.Add(GetTargetIndexValue(instructionPointer + 1, GetMode(instructionValue, 1)));
                    parameters.Add(GetTargetIndexValue(instructionPointer + 2, GetMode(instructionValue, 2)));
                    parameters.Add(GetTargetIndexValue(instructionPointer + 3, true));
                    break;
                default:
                    throw new Exception("Opcode instruction not found.");
            }

            return parameters;
        }

        private bool GetMode(int instructionValue, int parameterNumber)
        {
            var digits = GetDigits(instructionValue);
            var index = digits.Count - 2 - parameterNumber;
            return index >= 0 && Convert.ToBoolean(digits[index]);
        }

        private int GetTargetIndexValue(int targetIndex, bool immediateMode) => immediateMode
            ? _memory[targetIndex]
            : _memory[_memory[targetIndex]];

        private List<int> GetDigits(int number)
        {
            var digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            digits.Reverse();
            return digits;
        }
    }
}
