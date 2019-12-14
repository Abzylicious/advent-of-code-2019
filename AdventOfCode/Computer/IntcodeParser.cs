using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Computer
{
    public abstract class IntcodeParser
    {
        protected List<long> _memory = new List<long>();
        protected Queue<long> _inputs = new Queue<long>();
        protected readonly List<long> _output = new List<long>();
        protected int _relativeBase;
        protected int _instructionPointer;
        private readonly int[] _modeMask = new int[] { 0, 100, 1000, 10000 };

        protected void SetMemory(List<long> program) => _memory = program;
        protected void SetMemory(List<int> program) => _memory = program.ConvertAll(Convert.ToInt64);

        protected List<long> Parse()
        {
            _output.Clear();
            _relativeBase = 0;
            _instructionPointer = 0;
            Run();
            return _output;
        }

        protected virtual void Run()
        {
            while (GetOpcode() != Opcode.End)
            {
                ExecuteInstruction(GetOpcode());
            }
        }

        protected void ExecuteInstruction(Opcode opcode)
        {
            switch (opcode)
            {
                case Opcode.Add:
                    _memory[(int)GetAddress(3)] = GetParameter(1) + GetParameter(2);
                    _instructionPointer += 4;
                    break;
                case Opcode.Multiply:
                    _memory[(int)GetAddress(3)] = GetParameter(1) * GetParameter(2);
                    _instructionPointer += 4;
                    break;
                case Opcode.Write:
                    OnWrite();
                    _instructionPointer += 2;
                    break;
                case Opcode.Output:
                    OnOutput();
                    _instructionPointer += 2;
                    break;
                case Opcode.JumpIfTrue:
                    _instructionPointer = GetParameter(1) != 0 ? (int)GetParameter(2) : _instructionPointer + 3;
                    break;
                case Opcode.JumpIfFalse:
                    _instructionPointer = GetParameter(1) == 0 ? (int)GetParameter(2) : _instructionPointer + 3;
                    break;
                case Opcode.LessThan:
                    _memory[(int)GetAddress(3)] = GetParameter(1) < GetParameter(2) ? 1 : 0;
                    _instructionPointer += 4;
                    break;
                case Opcode.Equals:
                    _memory[(int)GetAddress(3)] = GetParameter(1) == GetParameter(2) ? 1 : 0;
                    _instructionPointer += 4;
                    break;
                case Opcode.ModifyOffset:
                    _relativeBase += (int)GetParameter(1);
                    _instructionPointer += 2;
                    break;
                default:
                    throw new Exception($"Opcode {opcode} failed to execute.");
            }
        }

        protected abstract void OnWrite();
        protected abstract void OnOutput();

        protected long GetParameter(int relativeMemoryIndex) => _memory[(int)GetAddress(relativeMemoryIndex)];

        protected long GetAddress(int relativeMemoryIndex)
        {
            var parameterMode = GetParameterMode(relativeMemoryIndex);
            ExtendMemoryIfNeeded(parameterMode, relativeMemoryIndex);

            return parameterMode switch
            {
                ParameterMode.Positional => _memory[_instructionPointer + relativeMemoryIndex],
                ParameterMode.Immediate => _instructionPointer + relativeMemoryIndex,
                ParameterMode.Relative => _relativeBase + _memory[_instructionPointer + relativeMemoryIndex],
                _ => throw new Exception("Unknown parameter mode detected.")
            };
        }

        protected Opcode GetOpcode() => (Opcode)(_memory[_instructionPointer] % 100);
        protected ParameterMode GetParameterMode(int relativeMemoryIndex) => (ParameterMode)(_memory[_instructionPointer] / _modeMask[relativeMemoryIndex] % 10);

        protected void ExtendMemoryIfNeeded(ParameterMode parameterMode, int relativeMemoryIndex)
        {
            switch (parameterMode)
            {
                case ParameterMode.Positional:
                    ExtendMemoryIfNeeded((int)_memory[_instructionPointer + relativeMemoryIndex]);
                    break;
                case ParameterMode.Immediate:
                    ExtendMemoryIfNeeded(_instructionPointer + relativeMemoryIndex);
                    break;
                case ParameterMode.Relative:
                    ExtendMemoryIfNeeded(_relativeBase + (int)_memory[_instructionPointer + relativeMemoryIndex]);
                    break;
                default:
                    throw new Exception("Unknown parameter mode detected.");
            }
        }

        protected void ExtendMemoryIfNeeded(int accessedIndex)
        {
            if (accessedIndex >= _memory.Count)
            {
                ExtendMemory(accessedIndex - _memory.Count + 1);
            }
        }

        private void ExtendMemory(int additionalElements)
        {
            foreach (var _ in Enumerable.Range(0, additionalElements))
            {
                _memory.Add(0);
            }
        }
    }
}
