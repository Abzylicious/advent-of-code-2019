using AdventOfCode.Day06;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day06
{
    [TestFixture]
    public class PartOneTests
    {
        [Test]
        public void ExampleOne()
        {
            var map = new List<string>() { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" };
            var orbitmap = new OrbitMap(map);
            var actual = orbitmap.OrbitCount();
            actual.Should().Be(42);
        }
    }
}
