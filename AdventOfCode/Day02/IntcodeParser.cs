using System;
using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public class IntcodeParser
    {
        private int[] _memory;

        public int[] Parse(List<int> intcode)
        {
            _memory = intcode.ToArray();
            return Run();
        }

        public int[] Parse(List<int> intcode, int noun, int verb)
        {
            _memory = intcode.ToArray();
            _memory[1] = noun;
            _memory[2] = verb;
            return Run();
        }

        private int[] Run()
        {
            var instructionPointer = 0;
            while (_memory[instructionPointer] != 99)
            {
                var instruction = GetInstruction(instructionPointer);
                _memory[instruction.DestinationIndex] = ExecuteInstruction(instruction);
                instructionPointer += 4;
            }

            return _memory;
        }

        private int GetTargetIndexValue(int targetIndex) => _memory[_memory[targetIndex]];

        private Instruction GetInstruction(int instructionPointer) => new Instruction()
        {
            Opcode = _memory[instructionPointer],
            ParameterA = GetTargetIndexValue(instructionPointer + 1),
            ParameterB = GetTargetIndexValue(instructionPointer + 2),
            DestinationIndex = _memory[instructionPointer + 3]
        };

        private int ExecuteInstruction(Instruction instruction)
        {
            return instruction.Opcode switch
            {
                1 => instruction.ParameterA + instruction.ParameterB,
                2 => instruction.ParameterA * instruction.ParameterB,
                _ => throw new Exception("Unknown opcode detected.")
            };
        }
    }
}
