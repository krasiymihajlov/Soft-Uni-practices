namespace _01.Sweet_Dessert
{
    using System;

    public class SweetDessert
    {
        public static void Main()
        {
            var money = decimal.Parse(Console.ReadLine());
            var guests = long.Parse(Console.ReadLine());
            var bananaPrice = decimal.Parse(Console.ReadLine());
            var eggPrice = decimal.Parse(Console.ReadLine());
            var berriesPrice = decimal.Parse(Console.ReadLine());

            var portion = guests / 6;
            if (guests % 6 != 0)
            {
                portion++;
            }

            var pricePerPortion = 2 * bananaPrice + 4 * eggPrice + 0.2M * berriesPrice;
            var totalPrice = pricePerPortion * portion;

            if (money >= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {Math.Abs(totalPrice - money):F2}lv more.");
            }

        }
    }
}
