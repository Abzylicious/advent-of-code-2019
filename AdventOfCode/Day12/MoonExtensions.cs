using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Day12
{
    public static class MoonExtensions
    {
        public static int TotalEnergy(this IEnumerable<Moon> it) => it.Sum(moon => moon.TotalEnergy());

        public static Vector3 AppliedGravity(this Moon it, Moon other) =>
            new Vector3(AppliedXGravity(it, other), AppliedYGravity(it, other), AppliedZGravity(it, other));

        private static int AppliedXGravity(Moon it, Moon other)
        {
            if (it.Position.X == other.Position.X)
                return 0;

            return it.Position.X < other.Position.X ? 1 : -1;
        }

        private static int AppliedYGravity(Moon it, Moon other)
        {
            if (it.Position.Y == other.Position.Y)
                return 0;

            return it.Position.Y < other.Position.Y ? 1 : -1;
        }

        private static int AppliedZGravity(Moon it, Moon other)
        {
            if (it.Position.Z == other.Position.Z)
                return 0;

            return it.Position.Z < other.Position.Z ? 1 : -1;
        }
    }
}
