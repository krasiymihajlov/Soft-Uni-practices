namespace _11.Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstPair = Console.ReadLine().Split(' ');
            string name = $"{firstPair[0]} {firstPair[1]}";
            string address = firstPair[2];
            string town = firstPair[3];
            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(name, address, town);

            string[] secondPair = Console.ReadLine().Split(' ');
            name = secondPair[0];
            int beerAmount = int.Parse(secondPair[1]);
            bool isDrunk = secondPair[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, beerAmount, isDrunk);

            string[] thirdPair = Console.ReadLine().Split(' ');
            name = thirdPair[0];
            double doubleItem = double.Parse(thirdPair[1]);
            string bankName = thirdPair[2];
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name, doubleItem, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
