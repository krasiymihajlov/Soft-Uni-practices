namespace _07.Sales_Report
{
    using System;
    using System.Collections.Generic;

    public class ObjectAndClases
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var dictSale = new SortedDictionary<string, double>();

            for (int i = 0; i < number; i++)
            {
                var firstRow = Console.ReadLine().Split();

                var curentSale = new Sale
                {
                    Town = firstRow[0],
                    Product = firstRow[1],
                    Price = double.Parse(firstRow[2]),
                    Quantity = double.Parse(firstRow[3])
                };

                if (!dictSale.ContainsKey(curentSale.Town))
                {
                    dictSale[curentSale.Town] = curentSale.TotalPrice;
                }
                else
                {
                    dictSale[curentSale.Town] += curentSale.TotalPrice;
                }
            }

            foreach (var sale in dictSale)
            {
                Console.WriteLine($"{sale.Key} -> {sale.Value:f2}");
            }

        }
    }
}
