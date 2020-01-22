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

        public int GetClosestIntersection()
        {
            var intersections = GetIntersections();
            var distances = intersections.Select(i => CalculateManhattanDistance(i)).ToList();
            return distances.Min();
        }

        public int GetSmallestSteps()
        {
            var intersections = GetIntersections();
            var steps = intersections.Select(i => CalculateSteps(i)).ToList();
            return steps.Min();
        }

        private IEnumerable<Point> GetIntersections() => WireA.ConnectedPoints.Intersect(WireB.ConnectedPoints);
        private int CalculateManhattanDistance(Point point) => Math.Abs(point.X) + Math.Abs(point.Y);

        private int CalculateSteps(Point destination)
        {
            var stepsA = WireA.ConnectedPoints.IndexOf(destination) + 1;
            var stepsB = WireB.ConnectedPoints.IndexOf(destination) + 1;
            return stepsA + stepsB;
        }
    }
}
