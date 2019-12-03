using AdventOfCode.Day03;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day03
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly Grid _grid = new Grid();

        /// <summary>
        /// For example, if the first wire's path is R8,U5,L5,D3, then starting from the central port (o), it goes right 8, up 5, left 5, and finally down 3.
        /// Then, if the second wire's path is U7,R6,D4,L4, it goes up 7, right 6, down 4, and left 4.
        /// These wires cross at two locations (marked X), but the lower-left one is closer to the central port: its distance is 3 + 3 = 6.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            _grid.WireA = new Wire("R8,U5,L5,D3");
            _grid.WireB = new Wire("U7,R6,D4,L4");

            var actual = _grid.GetClosestIntersection();
            actual.Should().Be(6);
        }

        [Test]
        public void ExampleTwo()
        {
            _grid.WireA = new Wire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            _grid.WireB = new Wire("U62,R66,U55,R34,D71,R55,D58,R83");

            var actual = _grid.GetClosestIntersection();
            actual.Should().Be(159);
        }

        [Test]
        public void ExampleThree()
        {
            _grid.WireA = new Wire("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            _grid.WireB = new Wire("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

            var actual = _grid.GetClosestIntersection();
            actual.Should().Be(135);
        }
    }
}
