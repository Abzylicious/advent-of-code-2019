using AdventOfCode.Interfaces;
using AdventOfCode.Services;

namespace AdventOfCode.Day08
{
    public class Solver : ISolver
    {
        private readonly ImageDecoder _imageDecoder = new ImageDecoder();
        private SpaceImage _spaceImage = new SpaceImage();

        public int Day { get; } = 8;
        public string Title { get; } = "--- Day 8: Space Image Format ---";

        public void Precondition()
        {
            var filePath = InputFileReader.GetFilePath();
            var input = InputFileReader.ReadText(filePath);
            var width = ConsoleReader.ReadIntegerFor("width");
            var height = ConsoleReader.ReadIntegerFor("height");
            _spaceImage = _imageDecoder.CreateNewSpaceImage(input, width, height);
        }

        public string GetFirstSolution() => _imageDecoder.GetChecksum(_spaceImage).ToString();
        public string GetSecondSolution() => $"\n{_imageDecoder.DecodeImageToString(_spaceImage)}";
    }
}
