using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());           
            double roundingNumberA = Math.Round(numberA, 6);
            double roundingNumberB = Math.Round(numberB, 6);
            if (Math.Abs(roundingNumberA) == Math.Abs(roundingNumberB)) 
            {
                Console.WriteLine("True");
            }
            else if (roundingNumberA < roundingNumberB)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
