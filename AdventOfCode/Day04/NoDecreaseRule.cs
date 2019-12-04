using AdventOfCode.Interfaces;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class NoDecreaseRule : IPasswordRule
    {
        public bool Check(List<int> digits)
        {
            for (int i = 1; i < digits.Count; i++)
            {
                if (NextDigitDecreases(digits[i - 1], digits[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool NextDigitDecreases(int left, int right) => right < left;
    }
}
