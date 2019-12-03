using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Grid
    {
        public Wire WireA { get; set; }
        public Wire WireB { get; set; }

        public IEnumerable<Point> GetIntersections() => WireA.ConnectedPoints.Intersect(WireB.ConnectedPoints);

        public int GetClosestIntersection()
        {
            var intersections = GetIntersections();
            var distances = new List<int>();

            foreach (var intersection in intersections)
            {
                distances.Add(CalculateManhattanDistance(intersection));
            }
            return distances.Min();
        }

        private int CalculateManhattanDistance(Point point) => Math.Abs(point.X) + Math.Abs(point.Y);
    }
}
