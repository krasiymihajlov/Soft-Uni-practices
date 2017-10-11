﻿namespace _03.Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();
            Ferrari ferari = new Ferrari(driverName);
            Console.WriteLine(ferari.ToString());

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
