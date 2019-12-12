using AdventOfCode.Day10;
using FluentAssertions;
using NUnit.Framework;
using System.Drawing;

namespace AdventOfCode.Test.Day10
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly ScanStation _asteroidMap = new ScanStation();

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
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            position.Should().Be(new Point(3, 4));
            detectedAsteroids.Should().Be(8);
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
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            position.Should().Be(new Point(5, 8));
            detectedAsteroids.Should().Be(33);
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
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            position.Should().Be(new Point(1, 2));
            detectedAsteroids.Should().Be(35);
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
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            position.Should().Be(new Point(6, 3));
            detectedAsteroids.Should().Be(41);
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
            var (position, detectedAsteroids) = _asteroidMap.GetBestScanStationPosition();
            position.Should().Be(new Point(11, 13));
            detectedAsteroids.Should().Be(210);
        }
    }
}
