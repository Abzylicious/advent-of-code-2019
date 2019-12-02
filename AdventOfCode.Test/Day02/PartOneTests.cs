using AdventOfCode.Day02;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day02
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly IntcodeParser _intcodeParser = new IntcodeParser();

        [Test, Description("1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2).")]
        public void ExampleOne()
        {
            var input = new List<int>() { 1, 0, 0, 0, 99 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 2, 0, 0, 0, 99 });
        }

        [Test, Description("2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).")]
        public void ExampleTwo()
        {
            var input = new List<int>() { 2, 3, 0, 3, 99 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 2, 3, 0, 6, 99 });
        }

        [Test, Description("2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).")]
        public void ExampleThree()
        {
            var input = new List<int>() { 2, 4, 4, 5, 99, 0 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 2, 4, 4, 5, 99, 9801 });
        }

        [Test, Description("1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.")]
        public void ExampleFour()
        {
            var input = new List<int>() { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 30, 1, 1, 4, 2, 5, 6, 0, 99 });
        }
    }
}
