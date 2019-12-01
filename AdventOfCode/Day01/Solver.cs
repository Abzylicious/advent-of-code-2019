using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day01
{
    public class Solver
    {
        private readonly FuelCalculator _fuelCalculator;
        public ICollection<int> Masses { get; }

        public Solver(string inputPath)
        {
            _fuelCalculator = new FuelCalculator();
            Masses = new List<int>();
            ReadInput(inputPath);
        }

        public int PartOne()
        {
            var result = 0;
            foreach (var mass in Masses)
            {
                result += _fuelCalculator.GetFuel(mass);
            }

            return result;
        }

        private void ReadInput(string inputPath)
        {
            try
            {
                foreach (var input in File.ReadAllLines(inputPath))
                {
                    Masses.Add(Convert.ToInt32(input));
                }
            }
            catch (Exception)
            {
                throw new Exception("The input file is not formatted as expected.");
            }
        }
    }
}
