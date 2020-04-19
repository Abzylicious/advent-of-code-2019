using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class ChemicalReaction
    {
        public Chemical Output { get; }
        public IEnumerable<Chemical> Inputs { get; }

        private ChemicalReaction(Chemical output)
        {
            Output = output;
        }

        public ChemicalReaction(Chemical output, params (string name, int amount)[] inputs) : this(output)
        {
            Inputs = inputs.Select(chemical => new Chemical(chemical.name, chemical.amount));
        }

        public ChemicalReaction(Chemical output, IEnumerable<Chemical> inputs) : this(output)
        {
            Inputs = inputs;
        }
    }
}
