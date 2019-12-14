using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class InputFileReader
    {
        private const string ErrorMessage = "The input file is not formatted as expected.";

        public static string GetFilePath()
        {
            var filePath = string.Empty;
            while (!File.Exists(filePath))
            {
                Console.Write("Path to input.txt: ");
                filePath = Console.ReadLine();
            }
            return filePath;
        }

        public static IEnumerable<int> ReadIntegers(string filePath, string delimiter)
        {
            try
            {
                var input = File.ReadAllText(filePath).Split(delimiter).Where(x => !string.IsNullOrEmpty(x)).ToList();
                return input.ConvertAll(Convert.ToInt32);
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }

        public static IEnumerable<long> ReadLongs(string filePath, string delimiter)
        {
            try
            {
                var input = File.ReadAllText(filePath).Split(delimiter).Where(x => !string.IsNullOrEmpty(x)).ToList();
                return input.ConvertAll(Convert.ToInt64);
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }

        public static IEnumerable<string> ReadText(string filePath, string delimiter)
        {
            try
            {
                return File.ReadAllText(filePath).Split(delimiter).Where(x => !string.IsNullOrEmpty(x)).ToList();
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }

        public static string ReadText(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath).TrimEnd();
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }
    }
}
