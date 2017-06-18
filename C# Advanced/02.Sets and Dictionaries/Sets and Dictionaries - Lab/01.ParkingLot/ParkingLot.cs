namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var set = new SortedSet<string>();

            while(input != "END")
            {
                var cars = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var command = cars[0];
                var regN = cars[1];

                if (command == "IN")
                {
                    set.Add(regN);
                }
                else
                {
                    set.Remove(regN);
                }

                input = Console.ReadLine();
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in set)
                {
                    Console.WriteLine($"{car}");
                }
            }
        }
    }
}
