using AdventOfCode.Computer;
using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class Amplifier : IntcodeParser
    {
        private List<int> _inputs = new List<int>();
        private int _output;
        private int _phase;
        private int _instructionPointer;
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }

        public Amplifier(int phase)
        {
            _phase = phase;
        }

        public int GetThrusterSignal(List<int> intcode, int signal)
        {
            _memory = intcode.ToArray();
            _inputs = new List<int>() { _phase, signal };
            _instructionPointer = 0;
            Run();
            return _output;
        }

        public int GetThrusterSignalKeepState(List<int> initialIntcode, int signal)
        {
            IsPaused = false;
            if (!IsRunning)
            {
                _memory = initialIntcode.ToArray();
                _inputs = new List<int>() { _phase, signal };
                _instructionPointer = 0;
                IsRunning = true;
                Run();
                return _output;
            }
            if (!IsPaused)
            {
                _inputs.Add(signal);
                Run();
            }
            return _output;
        }

        protected override void Run()
        {
            while ((Opcode)_memory[_instructionPointer] != Opcode.END && !IsPaused)
            {
                var instruction = GetInstruction(_instructionPointer);
                _instructionPointer = ExecuteInstruction(instruction, _instructionPointer);
            }
            IsRunning = (Opcode)_memory[_instructionPointer] != Opcode.END;
        }

        protected override int ExecuteInstruction(Instruction instruction, int instructionPointer)
        {
            var nextInstructionPointer = instructionPointer + instruction.ParameterCount();
            switch (instruction.Opcode)
            {
                case Opcode.WRITE:
                    _memory[instruction.Parameters[0]] = _inputs[0];
                    _inputs.RemoveAt(0);
                    return nextInstructionPointer;
                case Opcode.OUTPUT:
                    _output = instruction.Parameters[0];
                    IsPaused = true;
                    return nextInstructionPointer;
            }
            return base.ExecuteInstruction(instruction, instructionPointer);
        }

        protected override List<int> GetParameters(Opcode opcode, int instructionPointer)
        {
            var opcodeInstruction = _memory[instructionPointer];
            var parameters = new List<int>();

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
