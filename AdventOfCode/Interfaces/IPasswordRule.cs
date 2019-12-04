using System.Collections.Generic;

namespace AdventOfCode.Interfaces
{
    public interface IPasswordRule
    {
        bool Check(List<int> digits);
    }
}
