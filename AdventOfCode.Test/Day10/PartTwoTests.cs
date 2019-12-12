using AdventOfCode.Day10;
using FluentAssertions;
using NUnit.Framework;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Test.Day10
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly ScanStation _asteroidMap = new ScanStation();

        [Test]
        public void ExampleOne()
        {
            var asteroids = new string[]
            {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"
            };

            _asteroidMap.CreateMap(asteroids);
            var actual = _asteroidMap.GetAsteroidDestructionOrder(new Point(11, 13));
            actual.ElementAt(0).Should().Be(new Point(11, 12));
            actual.ElementAt(1).Should().Be(new Point(12, 1));
            actual.ElementAt(2).Should().Be(new Point(12, 2));
            actual.ElementAt(9).Should().Be(new Point(12, 8));
            actual.ElementAt(19).Should().Be(new Point(16, 0));
            actual.ElementAt(49).Should().Be(new Point(16, 9));
            actual.ElementAt(99).Should().Be(new Point(10, 16));
            actual.ElementAt(198).Should().Be(new Point(9, 6));
            actual.ElementAt(199).Should().Be(new Point(8, 2));
            actual.ElementAt(200).Should().Be(new Point(10, 9));
            actual.ElementAt(298).Should().Be(new Point(11, 1));
        }
    }
}
