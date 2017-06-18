namespace _10.UnicodeCharacters
{
    using System;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(GetEscapeSequence(input[i]));
            }

            Console.WriteLine();
        }

        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("x4");
        }
    }
}
