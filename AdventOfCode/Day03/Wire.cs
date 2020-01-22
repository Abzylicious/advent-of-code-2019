using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Wire
    {
        public List<Point> ConnectedPoints { get; }

        public Wire(string wirepath)
        {
            ConnectedPoints = new List<Point>();
            CreateNew(wirepath);
        }

        private void CreateNew(string wirepath)
        {
            ConnectedPoints.Clear();
            var instructions = wirepath.Split(',').Select(d => d.Trim());
            foreach (var instruction in instructions)
            {
                ExtendWire(instruction);
            }
        }

        private void ExtendWire(string instruction)
        {
            var direction = instruction[0];
            var distance = Convert.ToInt32(instruction.Substring(1));

            for (int i = distance; i > 0; i--)
            {
                ConnectedPoints.Add(GetNextPoint(direction));
            }
        }

        private Point GetNextPoint(char direction)
        {
            var lastPosition = ConnectedPoints.Count != 0 ? ConnectedPoints.Last() : new Point(0, 0);
            return direction switch
            {
                'U' => new Point(lastPosition.X, lastPosition.Y + 1),
                'R' => new Point(lastPosition.X + 1, lastPosition.Y),
                'D' => new Point(lastPosition.X, lastPosition.Y - 1),
                'L' => new Point(lastPosition.X - 1, lastPosition.Y),
                _ => throw new Exception("Unknown direction detected.")
            };
        }
    }
}
