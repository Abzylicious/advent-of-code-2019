using AdventOfCode.Day05;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day05
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly IntcodeParser _intcodeParser = new IntcodeParser();

        /// <summary>
        /// For example, consider the program 1002,4,3,4,33.
        /// The first instruction, 1002,4,3,4, is a multiply instruction - [...]
        /// This instruction multiplies its first two parameters. The first parameter,
        /// 4 in position mode, works like it did before - its value is the value stored
        /// at address 4 (33). The second parameter, 3 in immediate mode, simply has value 3.
        /// The result of this operation, 33 * 3 = 99, is written according to the third parameter,
        /// 4 in position mode, which also works like it did before - 99 is written to address 4.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var input = new List<int>() { 1002, 4, 3, 4, 33 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 1002, 4, 3, 4, 99 });
        }

        /// <summary>
        /// Integers can be negative: 1101,100,-1,4,0 is a valid program (find 100 + -1, store the result in position 4)
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var input = new List<int>() { 1101, 100, -1, 4, 0 };
            var actual = _intcodeParser.Parse(input);
            actual.Should().BeEquivalentTo(new List<int>() { 1101, 100, -1, 4, 99 });
        }
    }
}
