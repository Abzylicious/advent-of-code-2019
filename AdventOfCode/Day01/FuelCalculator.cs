namespace AdventOfCode.Day01
{
    public class FuelCalculator
    {
        public int GetFuel(int mass) => (mass / 3) - 2;

        public int GetTotalFuel(int mass)
        {
            var fuel = GetFuel(mass);
            return fuel > 0 ? fuel + GetTotalFuel(fuel) : 0;
        }
    }
}
