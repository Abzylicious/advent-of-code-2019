using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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

        public static List<Vector3> ReadCoordinates(string filePath)
        {
            try
            {
                var result = new List<Vector3>();
                var input = File.ReadAllText(filePath).Replace("<", "").Replace(">", "");
                foreach (var line in input.Split("\n").Where(x => !string.IsNullOrEmpty(x)))
                {
                    var coordinates = line.Split(',');
                    result.Add(new Vector3(
                        Convert.ToInt32(coordinates[0].Trim().Substring(2)),
                        Convert.ToInt32(coordinates[1].Trim().Substring(2)),
                        Convert.ToInt32(coordinates[2].Trim().Substring(2))));
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }
    }
}
