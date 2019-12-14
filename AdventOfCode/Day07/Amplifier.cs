using AdventOfCode.Computer;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class Amplifier : IntcodeParser
    {
        private readonly int _phase;
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }

        public Amplifier(int phase)
        {
            _phase = phase;
        }

        public int GetThrusterSignal(List<int> intcode, int signal)
        {
            Start(intcode, signal);
            return (int)_output.Last();
        }

        public int GetThrusterSignalKeepState(List<int> initialIntcode, int signal)
        {
            IsPaused = false;
            if (!IsRunning)
            {
                IsRunning = true;
                Start(initialIntcode, signal);
            }

            if (!IsPaused)
            {
                Continue(signal);
            }

            return (int)_output.Last();
        }

        private void Start(List<int> intcode, int signal)
        {
            _instructionPointer = 0;
            SetMemory(intcode);
            _inputs.Enqueue(_phase);
            _inputs.Enqueue(signal);
            Run();
        }

        private void Continue(int signal)
        {
            _inputs.Enqueue(signal);
            Run();
        }

        protected override void Run()
        {
            while (GetOpcode() != Opcode.End && !IsPaused)
            {
                ExecuteInstruction(GetOpcode());
            }
            IsRunning = GetOpcode() != Opcode.End;
        }

        protected override void OnWrite() => _memory[(int)GetAddress(1)] = _inputs.Dequeue();

        protected override void OnOutput()
        {
            _output.Add(GetParameter(1));
            IsPaused = true;
        }
    }
}
