namespace AdventOfCode.Day14
{
    public class Chemical
    {
        public string Name { get; }
        public long Amount { get; }

        public Chemical(string name, long amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
