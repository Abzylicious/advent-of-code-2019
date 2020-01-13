using AdventOfCode.Day12;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Test.Day12
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly FourMoonMotionSimulator simulator = new FourMoonMotionSimulator();
        private Moon Io, Europa, Ganymede, Callisto;

        [Test]
        public void After10Steps()
        {
            Io = new Moon(new Vector3(-1, 0, 2));
            Europa = new Moon(new Vector3(2, -10, -7));
            Ganymede = new Moon(new Vector3(4, -8, 8));
            Callisto = new Moon(new Vector3(3, 5, -1));

            var actual = simulator.Run(Io, Europa, Ganymede, Callisto).ElementAt(9);
            actual[0].Position.Should().BeEquivalentTo(new Vector3(2, 1, -3));
            actual[0].Velocity.Should().BeEquivalentTo(new Vector3(-3, -2, 1));

            actual[1].Position.Should().BeEquivalentTo(new Vector3(1, -8, 0));
            actual[1].Velocity.Should().BeEquivalentTo(new Vector3(-1, 1, 3));

            actual[2].Position.Should().BeEquivalentTo(new Vector3(3, -6, 1));
            actual[2].Velocity.Should().BeEquivalentTo(new Vector3(3, 2, -3));

            actual[3].Position.Should().BeEquivalentTo(new Vector3(2, 0, 4));
            actual[3].Velocity.Should().BeEquivalentTo(new Vector3(1, -1, -1));
        }

        [Test]
        public void EnergyAfter10Steps()
        {
            Io = new Moon(new Vector3(-1, 0, 2));
            Europa = new Moon(new Vector3(2, -10, -7));
            Ganymede = new Moon(new Vector3(4, -8, 8));
            Callisto = new Moon(new Vector3(3, 5, -1));

            var actual = simulator.Run(Io, Europa, Ganymede, Callisto).ElementAt(9).TotalEnergy();
            actual.Should().Be(179);
        }

        [Test]
        public void After100Steps()
        {
            Io = new Moon(new Vector3(-8, -10, 0));
            Europa = new Moon(new Vector3(5, 5, 10));
            Ganymede = new Moon(new Vector3(2, -7, 3));
            Callisto = new Moon(new Vector3(9, -8, -3));


            var actual = simulator.Run(Io, Europa, Ganymede, Callisto).ElementAt(99);
            actual[0].Position.Should().BeEquivalentTo(new Vector3(8, -12, -9));
            actual[0].Velocity.Should().BeEquivalentTo(new Vector3(-7, 3, 0));

            actual[1].Position.Should().BeEquivalentTo(new Vector3(13, 16, -3));
            actual[1].Velocity.Should().BeEquivalentTo(new Vector3(3, -11, -5));

            actual[2].Position.Should().BeEquivalentTo(new Vector3(-29, -11, -1));
            actual[2].Velocity.Should().BeEquivalentTo(new Vector3(-3, 7, 4));

            actual[3].Position.Should().BeEquivalentTo(new Vector3(16, -13, 23));
            actual[3].Velocity.Should().BeEquivalentTo(new Vector3(7, 1, 1));
        }

        [Test]
        public void EnergyAfter100Steps()
        {
            Io = new Moon(new Vector3(-8, -10, 0));
            Europa = new Moon(new Vector3(5, 5, 10));
            Ganymede = new Moon(new Vector3(2, -7, 3));
            Callisto = new Moon(new Vector3(9, -8, -3));

            var actual = simulator.Run(Io, Europa, Ganymede, Callisto).ElementAt(99).TotalEnergy();
            actual.Should().Be(1940);
        }
    }
}
