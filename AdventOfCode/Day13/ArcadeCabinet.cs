using AdventOfCode.Computer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class ArcadeCabinet : IntcodeParser
    {
        private readonly List<Tile> _tiles = new List<Tile>();
        private readonly Queue<int> _outputBuffer = new Queue<int>();
        private int _score;

        public void RunGame(List<long> program)
        {
            SetMemory(program);
            _instructionPointer = 0;
            _tiles.Clear();
            Run();
        }

        public int GameBlockTileCount() => _tiles.Count(t => t.TileType.Equals(TileType.Block));
        public int GameScore() => _score;

        protected override void OnWrite() => _memory[(int) GetAddress(1)] = GetJoystickInput();

        protected override void OnOutput()
        {
            _outputBuffer.Enqueue((int)_memory[(int) GetAddress(1)]);

            if (_outputBuffer.Count == 3)
            {
                (int first, int second, int third) = (_outputBuffer.Dequeue(), _outputBuffer.Dequeue(), _outputBuffer.Dequeue());
                HandleOutputValues(first, second, third);
            }
        }

        private void HandleOutputValues(int first, int second, int third)
        {
            if (IsScore(first, second))
            {
                _score = third;
            }
            else
            {
                SetGameTile(first, second, third);
            }
        }

        private bool IsScore(int first, int second) => first == -1 && second == 0;

        private void SetGameTile(int first, int second, int third)
        {
            var position = new Point(first, second);
            if (_tiles.Any(t => t.Position.Equals(position)))
            {
                var tile = _tiles.Single(t => t.Position.Equals(position));
                tile.TileType = (TileType)third;
            }
            else
            {
                _tiles.Add(new Tile((TileType)third, new Point(first, second)));
            }
        }

        private int GetJoystickInput()
        {
            var horizontalPaddle = _tiles.Single(t => t.TileType.Equals(TileType.HorizontalPaddle));
            var ball = _tiles.Single(t => t.TileType.Equals(TileType.Ball));

            if (horizontalPaddle.Position.X == ball.Position.X)
                return 0;

            if (horizontalPaddle.Position.X < ball.Position.X)
                return 1;

            if (horizontalPaddle.Position.X > ball.Position.X)
                return -1;

            throw new Exception("Error while handling joystick input.");
        }
    }
}
