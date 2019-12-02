namespace AdventOfCode.Interfaces
{
    public interface ISolver
    {
        public int Day { get; }
        public string Title { get; }
        public void Precondition();
        public string GetFirstSolution();
        public string GetSecondSolution();
    }
}
