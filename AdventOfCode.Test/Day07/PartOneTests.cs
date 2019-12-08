using AdventOfCode.Day07;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day07
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly AmplifierService _amplifierService = new AmplifierService();

        /// <summary>
        /// Max thruster signal 43210 (from phase setting sequence 4,3,2,1,0)
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var intcode = new List<int>() { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 };
            var sequence = new List<int>() { 4, 3, 2, 1, 0 };
            var actual = _amplifierService.GetFinalThrusterSignal(intcode, sequence);
            actual.Should().Be(43210);
        }

        /// <summary>
        /// Max thruster signal 54321 (from phase setting sequence 0,1,2,3,4)
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var intcode = new List<int>() { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 };
            var sequence = new List<int>() { 0, 1, 2, 3, 4 };
            var actual = _amplifierService.GetFinalThrusterSignal(intcode, sequence);
            actual.Should().Be(54321);
        }

        /// <summary>
        /// Max thruster signal 65210 (from phase setting sequence 1,0,4,3,2)
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var intcode = new List<int>() { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007,
                31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 };

            var sequence = new List<int>() { 1, 0, 4, 3, 2 };
            var actual = _amplifierService.GetFinalThrusterSignal(intcode, sequence);
            actual.Should().Be(65210);
        }
    }
}
