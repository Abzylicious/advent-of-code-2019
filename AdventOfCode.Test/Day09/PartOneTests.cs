using AdventOfCode.Day09;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day09
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

        /// <summary>
        /// Additional test case from TPH
        /// </summary>
        [Test]
        public void Additional()
        {
            var intcode = new List<long> { 109, 1, 204, 0, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(1);
        }

        /// <summary>
        /// Additional test case from TPH
        /// </summary>
        [Test]
        public void AdditionalTwo()
        {
            var intcode = new List<long> { 109, 1, 203, 0, 4, 1, 99 };
            var actual = _boost.Parse(intcode, 42);
            actual[0].Should().Be(42);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditOne()
        {
            var intcode = new List<long> { 109, -1, 4, 1, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(-1);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditTwo()
        {
            var intcode = new List<long> { 109, -1, 104, 1, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(1);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditThree()
        {
            var intcode = new List<long> { 109, -1, 204, 1, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(109);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditFour()
        {
            var intcode = new List<long> { 109, 1, 9, 2, 204, -6, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(204);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditFive()
        {
            var intcode = new List<long> { 109, 1, 109, 9, 204, -6, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(204);
        }

        /// <summary>
        /// Additional test case from https://www.reddit.com/r/adventofcode/comments/e8aw9j/2019_day_9_part_1_how_to_fix_203_error/
        /// </summary>
        [Test]
        public void RedditSix()
        {
            var intcode = new List<long> { 109, 1, 209, -1, 204, -106, 99 };
            var actual = _boost.Parse(intcode);
            actual[0].Should().Be(204);
        }
    }
}
