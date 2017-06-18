namespace _01.ReverseString
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder sb = ReverseAString(input);
            Console.WriteLine(sb);
        }

        private static StringBuilder ReverseAString(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }

            return sb;
        }
    }
}
