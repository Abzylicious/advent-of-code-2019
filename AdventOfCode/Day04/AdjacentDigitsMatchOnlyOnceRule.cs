using AdventOfCode.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public class AdjacentDigitsMatchOnlyOnceRule : IPasswordRule
    {
        public bool Check(List<int> digits)
        {
            var multipleDigits = new Dictionary<int, int>();
            for (int i = 1; i < digits.Count; i++)
            {
                if (AdjacentDigitsMatch(digits[i - 1], digits[i]))
                {
                    multipleDigits[digits[i]] = multipleDigits.ContainsKey(digits[i])
                        ? multipleDigits[digits[i]] + 1
                        : 2;
                }
            }
            return multipleDigits.Any(x => x.Value == 2);
        }

        private bool AdjacentDigitsMatch(int left, int right) => right == left;
    }
}
