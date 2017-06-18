namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Palindromes
    {
        public static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(new char[] { ' ', ',', '.', '!', '?', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> palindrome = new HashSet<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (IsPalindrome(text[i]))
                {
                    palindrome.Add(text[i]);
                }
            }

            Console.Write("[");
            Console.Write(string.Join(", ", palindrome.OrderBy(x => x).Select(y => $"{y}")));
            Console.Write("]");
            Console.WriteLine();
        }

        public static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char last = word[word.Length - 1 - i];
                char first = word[i];
                if (first != last)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
