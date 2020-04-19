using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class Refinery
    {
        private readonly List<ChemicalReaction> _reactions;
        private readonly Queue<(string chemical, long amount)> _productionList = new Queue<(string chemical, long amount)>();
        private readonly ChemicalInventory _inventory = new ChemicalInventory();

        public Refinery(params ChemicalReaction[] reactions)
        {
            _reactions = reactions.ToList();
        }

        public long GetOresForSingleFuel()
        {
            var fuel = GetReaction("fuel");
            return Refine(fuel);
        }

        public long GetMaxFuel(long ores)
        {
            var fuel = GetReaction("fuel");
            var oresForOneFuel = Refine(fuel);
            var lower = (long)Math.Floor((double)ores / oresForOneFuel);
            var higher = (long)Math.Floor((double)lower * 2);

            while (higher > lower)
            {
                var avg = (higher + lower) / 2;
                _inventory.ResetInventory();
                var guess = Refine(fuel, avg);

                if (guess > ores)
                {
                    higher = avg;
                }
                else if (guess < ores)
                {
                    if (avg == lower)
                        break;

                    lower = avg;
                }
                else
                {
                    lower = avg;
                    break;
                }
            }

            return lower;
        }

        private long Refine(ChemicalReaction chemical, long factor = 1)
        {
            var ore = 0L;
            _inventory.ResetInventory();
            _productionList.Enqueue((chemical.Output.Name, chemical.Output.Amount * factor));

            while (_productionList.Count > 0)
            {
                var (chemicalName, amount) = _productionList.Dequeue();
                if (chemicalName == "ORE")
                {
                    ore += amount;
                }
                else
                {
                    Produce(chemicalName, amount);
                }
            }

            return ore;
        }

        private void Produce(string chemical, double amount)
        {
            var reaction = GetReaction(chemical);
            var fromStock = Math.Min(amount, _inventory.GetRemainingChemicals(chemical));
            amount -= fromStock;
            _inventory.RemoveChemical(chemical, (long)fromStock);

            if (amount > 0)
            {
                var multiplier = (long)Math.Ceiling(amount / reaction.Output.Amount);
                _inventory.AddChemical(reaction.Output.Name, (long)Math.Max(0, multiplier * reaction.Output.Amount - amount));

                foreach (var component in reaction.Inputs)
                {
                    _productionList.Enqueue((component.Name, component.Amount * multiplier));
                }
            }
        }

        private ChemicalReaction GetReaction(string name) =>
            _reactions.Single(c => c.Output.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }
}
