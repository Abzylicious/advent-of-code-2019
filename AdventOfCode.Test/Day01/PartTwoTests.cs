using AdventOfCode.Day01;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01
{
    [TestFixture]
    public class PartTwoTests
    {
        private FuelCalculator _fuelCalculator = new FuelCalculator();

        /// <summary>
        /// A module of mass 14 requires 2 fuel. This fuel requires no further fuel (2 divided by 3 and rounded down is 0,
        /// which would call for a negative fuel), so the total fuel required is still just 2.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var actual = _fuelCalculator.GetTotalFuel(14);
            actual.Should().Be(2);
        }

        /// <summary>
        /// At first, a module of mass 1969 requires 654 fuel. Then, this fuel requires 216 more fuel (654 / 3 - 2).
        /// 216 then requires 70 more fuel, which requires 21 fuel, which requires 5 fuel, which requires no further fuel.
        /// So, the total fuel required for a module of mass 1969 is 654 + 216 + 70 + 21 + 5 = 966.
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var actual = _fuelCalculator.GetTotalFuel(1969);
            actual.Should().Be(966);
        }

        /// <summary>
        /// The fuel required by a module of mass 100756 and its fuel is: 33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2 = 50346.
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var actual = _fuelCalculator.GetTotalFuel(100756);
            actual.Should().Be(50346);
        }
    }
}
