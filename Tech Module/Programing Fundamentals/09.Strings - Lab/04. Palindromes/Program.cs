namespace _04.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringLab
    {        
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new HashSet<string>();
            var count = 0;

            foreach (var word in text)
            {     
                if (GetPalindrome(word))
                {
                    arr.Add(word);
                }                       
               
                count++;
            }

            var result = arr.OrderBy(x => x);
            Console.WriteLine(string.Join(", ", result));

        }

        public static bool GetPalindrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (word[i] != word[length - i - 1])
                    return false;
            }
            return true;
        }
    }
}
