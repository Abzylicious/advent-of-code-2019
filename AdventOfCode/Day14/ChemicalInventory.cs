using System.Collections.Generic;

namespace AdventOfCode.Day14
{
    public class ChemicalInventory
    {
        private readonly IDictionary<string, long> _inventory = new Dictionary<string, long>();

        public void ResetInventory() => _inventory.Clear();

        public void RemoveChemical(string chemical, long amount)
        {
            if (InInventory(chemical, amount))
                _inventory[chemical] -= amount;

            if (_inventory[chemical] == 0)
                _inventory.Remove(chemical);
        }

        public void AddChemical(string chemical, long amount)
        {
            var remaining = GetRemainingChemicals(chemical);
            SetChemical(chemical, remaining + amount);
        }

        public long GetRemainingChemicals(string chemical)
        {
            if (!_inventory.Keys.Contains(chemical))
                _inventory[chemical] = 0;

            return _inventory[chemical];
        }

        private bool InInventory(string chemicalName, long amount) => GetRemainingChemicals(chemicalName) >= amount;
        private void SetChemical(string chemical, long amount) => _inventory[chemical] = amount;
    }
}
