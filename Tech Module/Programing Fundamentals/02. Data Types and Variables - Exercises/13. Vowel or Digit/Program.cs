using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine().ToLower());
            bool digit = "0123456789".IndexOf(symbol) >= 0;
            bool letter = "aoueiy".IndexOf(symbol) >= 0;
            if (digit)
            {
                Console.WriteLine("digit");
            }
            else if (letter)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
