using AdventOfCode.Day05;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day05
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly IntcodeParser _intcodeParser = new IntcodeParser();

        /// <summary>
        /// 3,9,8,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input
        /// is equal to 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var input = new List<int>() { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var actual = _intcodeParser.Parse(input, 8);
            actual.Should().Be(1);
        }

        /// <summary>
        /// 3,9,8,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input
        /// is equal to 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var input = new List<int>() { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(0);
        }

        /// <summary>
        /// 3,9,7,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input
        /// is less than 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var input = new List<int>() { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            var actual = _intcodeParser.Parse(input, 7);
            actual.Should().Be(1);
        }

        /// <summary>
        /// 3,9,7,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input
        /// is less than 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleFour()
        {
            var input = new List<int>() { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(0);
        }

        /// <summary>
        /// 3,3,1108,-1,8,3,4,3,99 - Using immediate mode, consider whether the input
        /// is equal to 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleFive()
        {
            var input = new List<int>() { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var actual = _intcodeParser.Parse(input, 8);
            actual.Should().Be(1);
        }

        /// <summary>
        /// 3,3,1108,-1,8,3,4,3,99 - Using immediate mode, consider whether the input
        /// is equal to 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleSix()
        {
            var input = new List<int>() { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(0);
        }

        /// <summary>
        /// 3,3,1107,-1,8,3,4,3,99 - Using immediate mode, consider whether the input
        /// is less than 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleSeven()
        {
            var input = new List<int>() { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var actual = _intcodeParser.Parse(input, 7);
            actual.Should().Be(1);
        }

        /// <summary>
        /// 3,3,1107,-1,8,3,4,3,99 - Using immediate mode, consider whether the input
        /// is less than 8; output 1 (if it is) or 0 (if it is not).
        /// </summary>
        [Test]
        public void ExampleEight()
        {
            var input = new List<int>() { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(0);
        }

        /// <summary>
        /// Here are some jump tests that take an input, then output 0 if the input
        /// was zero or 1 if the input was non-zero:
        /// 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 (using position mode)
        /// </summary>
        [Test]
        public void ExampleNine()
        {
            var input = new List<int>() { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var actual = _intcodeParser.Parse(input, 0);
            actual.Should().Be(0);
        }

        /// <summary>
        /// Here are some jump tests that take an input, then output 0 if the input
        /// was zero or 1 if the input was non-zero:
        /// 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 (using position mode)
        /// </summary>
        [Test]
        public void ExampleTen()
        {
            var input = new List<int>() { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(1);
        }

        /// <summary>
        /// Here are some jump tests that take an input, then output 0 if the input
        /// was zero or 1 if the input was non-zero:
        /// 3,3,1105,-1,9,1101,0,0,12,4,12,99,1 (using immediate mode)
        /// </summary>
        [Test]
        public void ExampleEleven()
        {
            var input = new List<int>() { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            var actual = _intcodeParser.Parse(input, 0);
            actual.Should().Be(0);
        }

        /// <summary>
        /// Here are some jump tests that take an input, then output 0 if the input
        /// was zero or 1 if the input was non-zero:
        /// 3,3,1105,-1,9,1101,0,0,12,4,12,99,1 (using immediate mode)
        /// </summary>
        [Test]
        public void ExampleTwelve()
        {
            var input = new List<int>() { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            var actual = _intcodeParser.Parse(input, 42);
            actual.Should().Be(1);
        }

        /// <summary>
        /// Here's a larger example: 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,
        /// 0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
        /// The above example program uses an input instruction to ask for a single number.
        /// The program will then output 999 if the input value is below 8, output 1000 if the
        /// input value is equal to 8, or output 1001 if the input value is greater than 8.
        /// </summary>
        [Test]
        public void ExampleThirteen()
        {
            var input = new List<int>() { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98,
                0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            var actual = _intcodeParser.Parse(input, 7);
            actual.Should().Be(999);
        }

        /// <summary>
        /// Here's a larger example: 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,
        /// 0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
        /// The above example program uses an input instruction to ask for a single number.
        /// The program will then output 999 if the input value is below 8, output 1000 if the
        /// input value is equal to 8, or output 1001 if the input value is greater than 8.
        /// </summary>
        [Test]
        public void ExampleFourteen()
        {
            var input = new List<int>() { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98,
                0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            var actual = _intcodeParser.Parse(input, 8);
            actual.Should().Be(1000);
        }

        /// <summary>
        /// Here's a larger example: 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,
        /// 0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
        /// The above example program uses an input instruction to ask for a single number.
        /// The program will then output 999 if the input value is below 8, output 1000 if the
        /// input value is equal to 8, or output 1001 if the input value is greater than 8.
        /// </summary>
        [Test]
        public void ExampleFifteen()
        {
            var input = new List<int>() { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98,
                0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            var actual = _intcodeParser.Parse(input, 9);
            actual.Should().Be(1001);
        }
    }
}
