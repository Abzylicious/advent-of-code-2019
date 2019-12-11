using AdventOfCode.Day10;
using FluentAssertions;
using NUnit.Framework;
using System.Drawing;

namespace AdventOfCode.Test.Day10
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly AsteroidMap _asteroidMap = new AsteroidMap();


        /// <summary>
        /// The best location for a new monitoring station on this map is the
        /// highlighted asteroid at 3,4 because it can detect 8 asteroids, more than
        /// any other location. (The only asteroid it cannot detect is the one at 1,0
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var asteroids = new string[]
            {
                ".#..#",
                ".....",
                "#####",
                "....#",
                "...##"
            };

            _asteroidMap.CreateMap(asteroids);
            var actual = _asteroidMap.GetBestScanStationPosition();
            actual.position.Should().Be(new Point(3, 4));
            actual.detectedAsteroids.Should().Be(8);
        }

        /// <summary>
        /// Best is 5,8 with 33 other asteroids detected
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var asteroids = new string[]
            {
                "......#.#.",
                "#..#.#....",
                "..#######.",
                ".#.#.###..",
                ".#..#.....",
                "..#....#.#",
                "#..#....#.",
                ".##.#..###",
                "##...#..#.",
                ".#....####"
            };

            _asteroidMap.CreateMap(asteroids);
            var actual = _asteroidMap.GetBestScanStationPosition();
            actual.position.Should().Be(new Point(5, 8));
            actual.detectedAsteroids.Should().Be(33);
        }

        /// <summary>
        /// Best is 1,2 with 35 other asteroids detected
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var asteroids = new string[]
            {
                "#.#...#.#.",
                ".###....#.",
                ".#....#...",
                "##.#.#.#.#",
                "....#.#.#.",
                ".##..###.#",
                "..#...##..",
                "..##....##",
                "......#...",
                ".####.###."
            };

            _asteroidMap.CreateMap(asteroids);
            var actual = _asteroidMap.GetBestScanStationPosition();
            actual.position.Should().Be(new Point(1, 2));
            actual.detectedAsteroids.Should().Be(35);
        }

        /// <summary>
        /// Best is 6,3 with 41 other asteroids detected
        /// </summary>
        [Test]
        public void ExampleFour()
        {
            var asteroids = new string[]
            {
                ".#..#..###",
                "####.###.#",
                "....###.#.",
                "..###.##.#",
                "##.##.#.#.",
                "....###..#",
                "..#.#..#.#",
                "#..#.#.###",
                ".##...##.#",
                ".....#.#.."
            };

            _asteroidMap.CreateMap(asteroids);
            var actual = _asteroidMap.GetBestScanStationPosition();
            actual.position.Should().Be(new Point(6, 3));
            actual.detectedAsteroids.Should().Be(41);
        }

        /// <summary>
        /// Best is 11,13 with 210 other asteroids detected
        /// </summary>
        [Test]
        public void ExampleFive()
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
            var actual = _asteroidMap.GetBestScanStationPosition();
            actual.position.Should().Be(new Point(11, 13));
            actual.detectedAsteroids.Should().Be(210);
        }
    }
}
