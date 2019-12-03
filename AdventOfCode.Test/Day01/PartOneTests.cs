using AdventOfCode.Day01;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01
{
    [TestFixture]
    public class PartOneTests
    {
        private FuelCalculator _fuelCalculator = new FuelCalculator();

        /// <summary>
        /// For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var actual = _fuelCalculator.GetFuel(12);
            actual.Should().Be(2);
        }

        /// <summary>
        /// For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var actual = _fuelCalculator.GetFuel(14);
            actual.Should().Be(2);
        }

        /// <summary>
        /// For a mass of 1969, the fuel required is 654.
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var actual = _fuelCalculator.GetFuel(1969);
            actual.Should().Be(654);
        }

        /// <summary>
        /// For a mass of 100756, the fuel required is 33583.
        /// </summary>
        [Test]
        public void ExampleFour()
        {
            var actual = _fuelCalculator.GetFuel(100756);
            actual.Should().Be(33583);
        }
    }
}
