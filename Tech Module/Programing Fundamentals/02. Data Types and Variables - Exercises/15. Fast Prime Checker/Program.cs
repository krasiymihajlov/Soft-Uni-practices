using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int counter = 2; counter <= number; counter++)
            {
                bool prime = true;
                for (int divider = 2; divider <= Math.Sqrt(counter); divider++)
                {
                    if (counter % divider == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                Console.WriteLine($"{counter} -> {prime}");
            }
        }
    }
}
