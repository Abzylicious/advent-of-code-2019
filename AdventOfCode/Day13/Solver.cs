using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class Solver : ISolver
    {
        private readonly ArcadeCabinet _arcadeCabinet = new ArcadeCabinet();
        private List<long> _game = new List<long>();

        public int Day { get; } = 13;
        public string Title { get; } = "--- Day 13: Care Package ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            _game = InputFileReader.ReadLongs(filePath, ",").ToList();
        }

        public string GetFirstSolution()
        {
            RunGame();
            return _arcadeCabinet.GameBlockTileCount().ToString();
        }

        public string GetSecondSolution()
        {
            _game[0] = 2;
            RunGame();
            return _arcadeCabinet.GameScore().ToString();
        }

        private void RunGame() => _arcadeCabinet.RunGame(_game);
    }
}
