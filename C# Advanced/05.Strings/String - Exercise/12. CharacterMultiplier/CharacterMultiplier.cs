namespace _12.CharacterMultiplier
{
    using System;
    using System.Linq;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x.Length).ToArray();

            string smallerWord = input[0];
            string largerword = input[1];
            int diff = largerword.Length - smallerWord.Length;
            long sum = 0;

            for (int i = 0; i < smallerWord.Length; i++)
            {
                sum += (int)smallerWord[i] * (int)largerword[i];
            }

            for (int i = diff - 1; i >= 0; i--)
            {
                sum += (int)largerword[largerword.Length - 1 - i];
            }

            Console.WriteLine(sum);
        }
    }
}
