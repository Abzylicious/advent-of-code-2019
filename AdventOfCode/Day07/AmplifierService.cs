using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class AmplifierService
    {
        public int GetFinalThrusterSignal(List<int> intcode, IEnumerable<int> sequence)
        {
            var thrusterSignal = 0;
            foreach (var number in sequence)
            {
                var amplifier = new Amplifier(number);
                thrusterSignal = amplifier.GetThrusterSignal(intcode, thrusterSignal);
            }
            return thrusterSignal;
        }

        public int GetFinalThrusterSignalFeedbackLoopMode(List<int> intcode, IEnumerable<int> sequence)
        {
            var thrusterSignal = 0;
            var amplifiers = new List<Amplifier>();
            foreach (var number in sequence)
            {
                amplifiers.Add(new Amplifier(number));
            }

            do
            {
                foreach (var amplifier in amplifiers)
                {
                    thrusterSignal = amplifier.GetThrusterSignalKeepState(intcode, thrusterSignal);
                }

            } while (amplifiers.Any(a => a.IsRunning));
            return thrusterSignal;
        }

        public int GetHighestThrusterSignal(List<int> intcode, List<int> phaseCodes, bool feedbackLoopMode = false)
        {
            var outputs = new List<int>();
            var phaseCodeCombinations = Permute(phaseCodes);

            foreach (var codeCombination in phaseCodeCombinations)
            {
                var output = feedbackLoopMode
                    ? GetFinalThrusterSignalFeedbackLoopMode(intcode, codeCombination)
                    : GetFinalThrusterSignal(intcode, codeCombination);
                outputs.Add(output);
            }
            return outputs.Max();
        }

        private IEnumerable<IEnumerable<int>> Permute(IList<int> sequence)
        {
            var result = new List<List<int>>();
            Permute(sequence, sequence.Count, result);
            return result;
        }

        private void Permute(IList<int> sequence, int sequenceCount, ICollection<List<int>> result)
        {
            if (sequenceCount == 1)
            {
                result.Add(new List<int>(sequence));
            }
            else
            {
                for (int i = 0; i < sequenceCount; i++)
                {
                    Permute(sequence, sequenceCount - 1, result);
                    var index = sequenceCount % 2 == 1 ? 0 : i;
                    var temp = sequence[index];
                    sequence[index] = sequence[sequenceCount - 1];
                    sequence[sequenceCount - 1] = temp;
                }
            }
        }
    }
}
