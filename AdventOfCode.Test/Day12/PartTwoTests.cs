using AdventOfCode.Day12;
using FluentAssertions;
using NUnit.Framework;
using System.Numerics;

namespace AdventOfCode.Test.Day12
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly FourMoonMotionSimulator simulator = new FourMoonMotionSimulator();
        private Moon Io, Europa, Ganymede, Callisto;

        [Test]
        public void ExampleOne()
        {
            Io = new Moon(new Vector3(-1, 0, 2));
            Europa = new Moon(new Vector3(2, -10, -7));
            Ganymede = new Moon(new Vector3(4, -8, 8));
            Callisto = new Moon(new Vector3(3, 5, -1));

            var actual = simulator.GetStepsToRepeat(Io, Europa, Ganymede, Callisto);
            actual.Should().Be(2772);
        }

        [Test]
        public void ExampleTwo()
        {
            Io = new Moon(new Vector3(-8, -10, 0));
            Europa = new Moon(new Vector3(5, 5, 10));
            Ganymede = new Moon(new Vector3(2, -7, 3));
            Callisto = new Moon(new Vector3(9, -8, -3));

            var actual = simulator.GetStepsToRepeat(Io, Europa, Ganymede, Callisto);
            actual.Should().Be(4686774924);
        }
    }
}
