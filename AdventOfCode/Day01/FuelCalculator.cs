namespace AdventOfCode.Day01
{
    public class FuelCalculator
    {
        public int GetFuel(int mass) => (mass / 3) - 2;

        public int GetTotalFuel(int mass)
        {
            var fuel = GetFuel(mass);
            while (fuel > 0)
            {
                return fuel + GetTotalFuel(fuel);
            }
            return 0;
        }
    }
}
