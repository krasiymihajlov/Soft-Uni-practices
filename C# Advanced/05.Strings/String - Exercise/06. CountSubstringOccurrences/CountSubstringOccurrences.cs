namespace _06.CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

            int startIndex = text.IndexOf(word);
            int count = 0;

            while (startIndex != -1)
            {
                text = text.Substring(startIndex + 1);
                count++;
                startIndex = text.IndexOf(word);
            }

            Console.WriteLine(count);
        }
    }
}
