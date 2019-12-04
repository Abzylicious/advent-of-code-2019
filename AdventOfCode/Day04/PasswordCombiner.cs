using AdventOfCode.Interfaces;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class PasswordCombiner
    {

        public bool IsValid(int number, params IPasswordRule[] ruleset) => IsValid(GetDigits(number), ruleset);

        private bool IsValid(List<int> digits, params IPasswordRule[] rulesets)
        {
            foreach (var rule in rulesets)
            {
                if (!rule.Check(digits))
                {
                    return false;
                }
            }
            return true;
        }

        private List<int> GetDigits(int number)
        {
            var digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            digits.Reverse();
            return digits;
        }
    }
}
