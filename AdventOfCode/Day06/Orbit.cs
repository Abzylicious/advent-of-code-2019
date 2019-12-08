using System.Collections.Generic;

namespace AdventOfCode.Day06
{
    public class Orbit
    {
        public string Name { get; set; }
        public Orbit ParentOrbit { get; set; }
        public List<Orbit> ChildOrbits { get; set; } = new List<Orbit>();
    }
}
