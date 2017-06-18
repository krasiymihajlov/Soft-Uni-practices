namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"^([0][0-9]:[0-5][0-9]:[0-5][0-9]\s(A|P)M)|([1][0-2]:[0-5][0-9]:[0-5][0-9]\s(A|P)M)$";
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
