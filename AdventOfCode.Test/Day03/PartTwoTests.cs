using AdventOfCode.Day03;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day03
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly Grid _grid = new Grid();

        /// <summary>
        /// In the above example, the intersection closest to the central port is reached after 8+5+5+2 = 20 steps by the first wire
        /// and 7+6+4+3 = 20 steps by the second wire for a total of 20+20 = 40 steps. However, the top-right intersection is better:
        /// the first wire takes only 8+5+2 = 15 and the second wire takes only 7+6+2 = 15, a total of 15+15 = 30 steps.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            _grid.WireA = new Wire("R8,U5,L5,D3");
            _grid.WireB = new Wire("U7,R6,D4,L4");

            var actual = _grid.GetSmallestSteps();
            actual.Should().Be(30);
        }

        [Test]
        public void ExampleTwo()
        {
            _grid.WireA = new Wire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            _grid.WireB = new Wire("U62,R66,U55,R34,D71,R55,D58,R83");

            var actual = _grid.GetSmallestSteps();
            actual.Should().Be(610);
        }

        [Test]
        public void ExampleThree()
        {
            _grid.WireA = new Wire("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            _grid.WireB = new Wire("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

            var actual = _grid.GetSmallestSteps();
            actual.Should().Be(410);
        }
    }
}
