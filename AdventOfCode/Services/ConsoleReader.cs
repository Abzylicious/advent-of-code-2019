using System;

namespace AdventOfCode.Services
{
    public static class ConsoleReader
    {
        public static int ReadInteger()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("The entered value is not a number: ");
            }
            return result;
        }

        public static int ReadIntegerFor(string descriptor)
        {
            Console.Write($"Enter your {descriptor} value: ");
            return ReadInteger();
        }
    }
}
