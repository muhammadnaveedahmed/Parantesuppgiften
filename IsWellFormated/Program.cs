using System;
using System.Collections.Generic;
using System.Linq;

namespace IsWellFormated
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Please enter a string to check!");
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) 
                Console.WriteLine($"Wellformated: {IsWellFormated(input)}");

            } while (true);
        }

        private static bool IsWellFormated(string input)
        {
            Dictionary<char, char> dict = GetDict();

            var stack = new Stack<char>();

            foreach (var c in input)
            {
                if (stack.Count == 0 && dict.ContainsValue(c)) return false;
                if (dict.ContainsValue(c) && dict[stack.Pop()] != c) return false;
                if (dict.ContainsKey(c)) stack.Push(c);
            }

            return stack.Count == 0;
        }

        private static Dictionary<char, char> GetDict()
        {
            return new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' },
                { '<', '>' }
            };
        }
    }
}
