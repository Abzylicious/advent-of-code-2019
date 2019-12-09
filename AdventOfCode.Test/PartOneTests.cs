﻿using AdventOfCode.Day09;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly Boost _boost = new Boost();

        /// <summary>
        /// 109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 takes no input and produces a copy of itself as output.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var intcode = new List<long>() { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            var actual = _boost.Parse(intcode);
            actual.Should().BeEquivalentTo(new List<long>() { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 });
        }

        /// <summary>
        /// 1102,34915192,34915192,7,4,7,99,0 should output a 16-digit number.
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var intcode = new List<long>() { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var actual = _boost.Parse(intcode);
            actual.Should().HaveCount(1);
            actual[0].ToString().Should().HaveLength(16);
        }

        /// <summary>
        /// 104,1125899906842624,99 should output the large number in the middle.
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var intcode = new List<long>() { 104, 1125899906842624, 99 };
            var actual = _boost.Parse(intcode);
            actual.Should().HaveCount(1);
            actual[0].Should().Be(1125899906842624);
        }
    }
}
