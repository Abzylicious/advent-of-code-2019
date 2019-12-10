using AdventOfCode.Computer;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Boost
    {
        private List<long> _memory = new List<long>();
        private int _input;
        private List<long> _output = new List<long>();
        private int _relativeBase;
        private int _instructionPointer;
        private int[] modeMask = new int[] { 0, 100, 1000, 10000 };


        public List<long> Parse(List<long> intcode, int input)
        {
            _input = input;
            return Parse(intcode);
        }

        public List<long> Parse(List<long> intcode)
        {
            _output.Clear();
            _memory = intcode;
            _relativeBase = 0;
            _instructionPointer = 0;
            Run();
            return _output;
        }

        public void Run()
        {
            while ((Opcode)_memory[_instructionPointer] != Opcode.END)
            {
                var opcode = (Opcode)(_memory[_instructionPointer] % 100);
                ExecuteInstruction(opcode);
            }
        }

        private void ExecuteInstruction(Opcode opcode)
        {
            switch (opcode)
            {
                case Opcode.ADD:
                    _memory[(int)GetAddress(3)] = GetParameter(1) + GetParameter(2);
                    _instructionPointer += 4;
                    break;
                case Opcode.MULTIPLY:
                    _memory[(int)GetAddress(3)] = GetParameter(1) * GetParameter(2);
                    _instructionPointer += 4;
                    break;
                case Opcode.WRITE:
                    _memory[(int)GetAddress(1)] = _input;
                    _instructionPointer += 2;
                    break;
                case Opcode.OUTPUT:
                    _output.Add(GetParameter(1));
                    _instructionPointer += 2;
                    break;
                case Opcode.JUMP_IF_TRUE:
                    _instructionPointer = GetParameter(1) != 0 ? (int)GetParameter(2) : _instructionPointer + 3;
                    break;
                case Opcode.JUMP_IF_FALSE:
                    _instructionPointer = GetParameter(1) == 0 ? (int)GetParameter(2) : _instructionPointer + 3;
                    break;
                case Opcode.LESS_THAN:
                    _memory[(int)GetAddress(3)] = GetParameter(1) < GetParameter(2) ? 1 : 0;
                    _instructionPointer += 4;
                    break;
                case Opcode.EQUALS:
                    _memory[(int)GetAddress(3)] = GetParameter(1) == GetParameter(2) ? 1 : 0;
                    _instructionPointer += 4;
                    break;
                case Opcode.MODIFY_OFFSET:
                    _relativeBase += (int)GetParameter(1);
                    _instructionPointer += 2;
                    break;
                default:
                    throw new Exception($"Opcode {opcode} failed to execute.");
            }
        }

        private long GetParameter(int relativeMemoryIndex) => _memory[(int)GetAddress(relativeMemoryIndex)];

        private long GetAddress(int relativeMemoryIndex)
        {
            var mode = (ParameterMode)(_memory[_instructionPointer] / modeMask[relativeMemoryIndex] % 10);
            switch (mode)
            {
                case ParameterMode.POSITIONAL:
                    ExtendMemoryIfNeeded((int)_memory[_instructionPointer + relativeMemoryIndex]);
                    return _memory[_instructionPointer + relativeMemoryIndex];
                case ParameterMode.IMMEDIATE:
                    ExtendMemoryIfNeeded(_instructionPointer + relativeMemoryIndex);
                    return _instructionPointer + relativeMemoryIndex;
                case ParameterMode.RELATIVE:
                    ExtendMemoryIfNeeded(_relativeBase + (int)_memory[_instructionPointer + relativeMemoryIndex]);
                    return _relativeBase + _memory[_instructionPointer + relativeMemoryIndex];
                default:
                    throw new Exception("Unknown parameter mode detected.");
            }
        }

        private void ExtendMemoryIfNeeded(int accessedIndex)
        {
            if (accessedIndex > _memory.Count - 1)
            {
                ExtendMemory(accessedIndex - _memory.Count + 1);
            }
        }

        private void ExtendMemory(int elements)
        {
            for (int i = 0; i < elements; i++)
            {
                _memory.Add(0);
            }
        }
    }
}
