using AdventOfCode.Day04;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day04
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly PasswordCombiner _passwordCombiner = new PasswordCombiner();

        /// <summary>
        /// 111111 meets these criteria (double 11, never decreases).
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var actual = _passwordCombiner.IsValid(111111, new NoDecreaseRule(), new AdjacentDigitsMatchOnceRule());
            actual.Should().BeTrue();
        }

        /// <summary>
        /// 223450 does not meet these criteria (decreasing pair of digits 50).
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var actual = _passwordCombiner.IsValid(223450, new NoDecreaseRule(), new AdjacentDigitsMatchOnceRule());
            actual.Should().BeFalse();
        }

        /// <summary>
        /// 123789 does not meet these criteria (no double).
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var actual = _passwordCombiner.IsValid(123789, new NoDecreaseRule(), new AdjacentDigitsMatchOnceRule());
            actual.Should().BeFalse();
        }
    }
}
