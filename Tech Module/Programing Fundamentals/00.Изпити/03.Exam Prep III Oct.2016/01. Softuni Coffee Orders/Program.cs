namespace _01.Softuni_Coffee_Orders
{
    using System;
    using System.Globalization;

    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var allPrice = 0M;

            for (int i = 0; i < n; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsuleCount = long.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                var price = ((daysInMonth * capsuleCount) * pricePerCapsule);
                allPrice += price;
                
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }

            Console.WriteLine($"Total: ${allPrice:F2}");
        }
    }
}
