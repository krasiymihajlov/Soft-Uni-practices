﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Strings_And_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstVariable = Console.ReadLine();
            string secondVariable = Console.ReadLine();
            object concatenationVaieble = firstVariable + " " + secondVariable;
            Console.WriteLine(concatenationVaieble);
        }
    }
}
