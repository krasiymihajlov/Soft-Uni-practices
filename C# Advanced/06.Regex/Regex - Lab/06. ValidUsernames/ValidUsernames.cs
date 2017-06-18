namespace _06.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"^[\w-]{3,16}$";
            Regex regex = new Regex(pattern);

            while (text != "END")
            {
                Match match = regex.Match(text);

                if (match.Success)
                {
                    Console.WriteLine($"valid");
                }
                else
                {
                    Console.WriteLine($"invalid");
                }

                text = Console.ReadLine();
            }
        }
    }
}
