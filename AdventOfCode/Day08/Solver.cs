using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

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
            var filePath = GetFilePath();
            var encryptedData = ReadInput(filePath);
            var width = ReadInteger("width");
            var height = ReadInteger("height");
            _spaceImage = _imageDecoder.CreateNewSpaceImage(encryptedData, width, height);
        }

        public string GetFirstSolution() => _imageDecoder.GetChecksum(_spaceImage).ToString();
        public string GetSecondSolution() => "No solution for part 2 yet :c";

        private string GetFilePath()
        {
            var filePath = string.Empty;
            while (!File.Exists(filePath))
            {
                Console.Write("Path to input.txt: ");
                filePath = Console.ReadLine();
            }
            return filePath;
        }

        private string ReadInput(string inputPath) => File.ReadAllText(inputPath).TrimEnd();

        private int ReadInteger(string descriptor)
        {
            Console.Write($"Enter your {descriptor} value: ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("The entered value is not a number: ");
            }
            return result;
        }
    }
}
