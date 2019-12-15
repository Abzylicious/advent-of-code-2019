using AdventOfCode.Computer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day11
{
    public class PaintingRobot : IntcodeParser
    {
        private List<long> _program = new List<long>();
        private Orientation _orientation = Orientation.Up;
        private readonly List<PanelHistoryEntry> _history = new List<PanelHistoryEntry>();
        private readonly ICollection<Point> _paintedPanels = new List<Point>();
        private bool _isFirstOutput = true;

        public PaintingRobot(List<long> program)
        {
            _program = program;
            SetMemory(_program);
        }

        public void Reset()
        {
            SetMemory(_program);
            _instructionPointer = 0;
            _relativeBase = 0;
            _history.Clear();
            _orientation = Orientation.Up;
        }

        public void Start(int startPanelColor = 0)
        {
            _history.Add(new PanelHistoryEntry(new Point(0, 0), startPanelColor));
            Parse();
        }

        public int GetTotalPaintedPanels() => _paintedPanels.Count;

        public string GetPainting()
        {
            var canvas = SetupCanvas();
            var fullBlock = '\u2588';
            var lightShade = '\u2591';
            var result = string.Empty;

            for (int y = 0; y < canvas.height; y++)
            {
                for (int x = 0; x < canvas.width; x++)
                {
                    result += canvas.canvas[x, y];
                }
                result += "\n";
            }
            return result.Replace('1', fullBlock).Replace('0', lightShade);
        }

        public (int[,] canvas, int width, int height) SetupCanvas()
        {
            var minX = _paintedPanels.OrderBy(h => h.X).ToList()[0].X;
            var maxX = _paintedPanels.OrderByDescending(h => h.X).ToList()[0].X;
            var minY = _paintedPanels.OrderBy(h => h.Y).ToList()[0].Y;
            var maxY = _paintedPanels.OrderByDescending(h => h.Y).ToList()[0].Y;
            var deltaX = minX < 0 ? minX * -1 : 0;
            var deltaY = minY < 0 ? minY * -1 : 0;

            var canvas = new int[maxX + deltaX + 1, maxY + deltaY + 1];
            foreach (var panel in _history)
            {
                canvas[panel.Position.X < 0 ? -panel.Position.X : panel.Position.X,
                    panel.Position.Y < 0 ? -panel.Position.Y : panel.Position.Y] = GetPanelColor(panel.Position);
            }
            return (canvas, maxX + deltaX, maxY + deltaY);
        }

        protected override void OnWrite()
        {
            _memory[(int)GetAddress(1)] = GetCurrentPanelColor();
        }

        protected override void OnOutput()
        {
            if (_isFirstOutput)
            {
                PaintPanel((int)GetParameter(1));
            }
            else
            {
                Turn((int)GetParameter(1));
            }
            _isFirstOutput = !_isFirstOutput;
        }

        private PanelHistoryEntry GetLastEntry() => _history.Last();
        private Point GetCurrentPosition() => GetLastEntry().Position;
        private int GetCurrentPanelColor() => GetLastEntry().Color;

        private int GetPanelColor(Point position)
        {
            var history = _history.LastOrDefault(h => h.Position == position);
            return history?.Color ?? 0;
        }

        private void PaintPanel(int color)
        {
            var currentEntry = GetLastEntry();
            if (!_paintedPanels.Any(p => p == currentEntry.Position))
            {
                _paintedPanels.Add(currentEntry.Position);
            }

            _history.Find(h => h == currentEntry).Color = color;
        }

        private void Turn(int direction)
        {
            if (direction == 0)
            {
                var nextPosition = TurnLeft();
                _history.Add(new PanelHistoryEntry(nextPosition, GetPanelColor(nextPosition)));
            }

            if (direction == 1)
            {
                var nextPosition = TurnRight();
                _history.Add(new PanelHistoryEntry(nextPosition, GetPanelColor(nextPosition)));
            }
        }

        private Point TurnRight()
        {
            var currentPosition = GetCurrentPosition();
            var nextPosition = _orientation switch
            {
                Orientation.Up => new Point(currentPosition.X + 1, currentPosition.Y),
                Orientation.Right => new Point(currentPosition.X, currentPosition.Y - 1),
                Orientation.Down => new Point(currentPosition.X - 1, currentPosition.Y),
                Orientation.Left => new Point(currentPosition.X, currentPosition.Y + 1),
                _ => throw new Exception("Error while trying to turn")
            };

            SetOrientationRightTurning();
            return nextPosition;
        }

        private Point TurnLeft()
        {
            var currentPosition = GetCurrentPosition();
            var nextPosition = _orientation switch
            {
                Orientation.Up => new Point(currentPosition.X - 1, currentPosition.Y),
                Orientation.Right => new Point(currentPosition.X, currentPosition.Y + 1),
                Orientation.Down => new Point(currentPosition.X + 1, currentPosition.Y),
                Orientation.Left => new Point(currentPosition.X, currentPosition.Y - 1),
                _ => throw new Exception("Error while trying to turn")
            };

            SetOrientationLeftTurning();
            return nextPosition;
        }

        private void SetOrientationRightTurning()
        {
            _orientation = _orientation switch
            {
                Orientation.Up => Orientation.Right,
                Orientation.Right => Orientation.Down,
                Orientation.Down => Orientation.Left,
                Orientation.Left => Orientation.Up,
                _ => throw new Exception("Error while setting orientation")
            };
        }

        private void SetOrientationLeftTurning()
        {
            _orientation = _orientation switch
            {
                Orientation.Up => Orientation.Left,
                Orientation.Right => Orientation.Up,
                Orientation.Down => Orientation.Right,
                Orientation.Left => Orientation.Down,
                _ => throw new Exception("Error while setting orientation")
            };
        }
    }
}
