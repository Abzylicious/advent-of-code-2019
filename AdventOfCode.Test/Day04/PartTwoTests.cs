using AdventOfCode.Day04;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day04
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly PasswordCombiner _passwordCombiner = new PasswordCombiner();

        /// <summary>
        /// 112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var actual = _passwordCombiner.IsValid(112233, new NoDecreaseRule(), new AdjacentDigitsMatchOnlyOnceRule());
            actual.Should().BeTrue();
        }

        /// <summary>
        /// 123444 no longer meets the criteria (the repeated 44 is part of a larger group of 444).
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var actual = _passwordCombiner.IsValid(123444, new NoDecreaseRule(), new AdjacentDigitsMatchOnlyOnceRule());
            actual.Should().BeFalse();
        }

        /// <summary>
        /// 111122 meets the criteria (even though 1 is repeated more than twice, it still contains a double 22).
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var actual = _passwordCombiner.IsValid(111122, new NoDecreaseRule(), new AdjacentDigitsMatchOnlyOnceRule());
            actual.Should().BeTrue();
        }
    }
}
