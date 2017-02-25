using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());            
            for (int counter = startNumber; counter <= endNumber; counter++)
            {
                Console.Write((char)counter + " ");
            }
            Console.WriteLine();
        }
    }
}
