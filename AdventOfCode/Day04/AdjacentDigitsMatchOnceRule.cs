using AdventOfCode.Interfaces;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class AdjacentDigitsMatchOnceRule : IPasswordRule
    {
        public bool Check(List<int> digits)
        {
            for (int i = 1; i < digits.Count; i++)
            {
                if (AdjacentDigitsMatch(digits[i - 1], digits[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool AdjacentDigitsMatch(int left, int right) => right == left;
    }
}
