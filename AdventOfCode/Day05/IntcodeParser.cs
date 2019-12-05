using System;
using System.Collections.Generic;
using System.Linq;

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
                ExecuteInstruction(instruction);
                instructionPointer += instruction.ParameterCount();
            }
        }

        private void ExecuteInstruction(Instruction instruction)
        {
            switch(instruction.Opcode)
            {
                case 1:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] + instruction.Parameters[1];
                    break;
                case 2:
                    _memory[instruction.Parameters[2]] = instruction.Parameters[0] * instruction.Parameters[1];
                    break;
                case 3:
                    _memory[instruction.Parameters[0]] = _input;
                    break;
                case 4:
                    _output = _memory[instruction.Parameters[0]];
                    break;
                default:
                    throw new Exception($"Execution of opcode {instruction.Opcode} failed.");
            }
        }

        private Instruction GetInstruction(int instructionPointer)
        {
            var opcode = GetOpcode(_memory[instructionPointer]);
            return new Instruction()
            {
                Opcode = GetOpcode(opcode),
                Parameters = GetParameters(opcode, instructionPointer)
            };
        }

        private int GetOpcode(int instructionValue) => instructionValue % 100;

        private List<int> GetParameters(int opcode, int instructionPointer)
        {
            var modes = GetModes(_memory[instructionPointer]);
            var parameters = new List<int>();

            switch (opcode)
            {
                case 1:
                case 2:
                    parameters.Add(GetTargetIndexValue(instructionPointer + 1, modes.FirstImmediateMode));
                    parameters.Add(GetTargetIndexValue(instructionPointer + 2, modes.SecondImmediateMode));
                    parameters.Add(GetTargetIndexValue(instructionPointer + 3, true));
                    break;
                case 3:
                case 4:
                    parameters.Add(GetTargetIndexValue(instructionPointer + 1, true));
                    break;
                default:
                    throw new Exception("Opcode instruction not found.");
            }

            return parameters;
        }

        private (bool FirstImmediateMode, bool SecondImmediateMode, bool ThirdImmediateMode) GetModes(int instructionValue)
        {
            var digits = GetDigits(instructionValue);
            if (digits.Count <= 2)
            {
                return (false, false, false);
            }

            return digits.Count switch
            {
                3 => (Convert.ToBoolean(digits[0]), false, false),
                4 => (Convert.ToBoolean(digits[1]), Convert.ToBoolean(digits[0]), false),
                5 => (Convert.ToBoolean(digits[2]), Convert.ToBoolean(digits[1]), Convert.ToBoolean(digits[0])),
                _ => throw new Exception("The opcode instruction is too large.")
            };
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
