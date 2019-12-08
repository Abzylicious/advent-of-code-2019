using AdventOfCode.Day08;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day08
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly ImageDecoder _imageDecoder = new ImageDecoder();

        [Test]
        public void ExampleOne()
        {
            var imageData = "123456789012";
            var image = _imageDecoder.CreateNewSpaceImage(imageData, 3, 2);
            var actual = _imageDecoder.GetChecksum(image);
            actual.Should().Be(1);
        }
    }
}
