using AdventOfCode.Day08;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day08
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly ImageDecoder _imageDecoder = new ImageDecoder();

        [Test]
        public void ExampleOne()
        {
            var imageData = "0222112222120000";
            var expected = new string[,] { { "0", "1" }, { "1", "0" } };

            var image = _imageDecoder.CreateNewSpaceImage(imageData, 2, 2);
            var actual = _imageDecoder.DecodeImage(image);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
