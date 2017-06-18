namespace _6.Triples_of_Latin_Letters
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int firstLetter = 0; firstLetter < n; firstLetter++)
            {
                for (int secondLetter = 0; secondLetter < n; secondLetter++)
                {
                    for (int thirdLetter = 0; thirdLetter < n; thirdLetter++)
                    {
                        char first = (char)('a' + firstLetter);
                        char second = (char)('a' + secondLetter);
                        char third = (char)('a' + thirdLetter);
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}
