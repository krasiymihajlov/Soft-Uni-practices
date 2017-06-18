namespace _09.Index_of_Letters
{
    using System;

    public class ArraysExercises
    {
        public static void Main()
        {
            var word = Console.ReadLine().ToLower().ToCharArray();
            var letters = new char[26];                        

            for (int j = 0; j < word.Length; j++)
            {
                int symbol = word[j] - 'a';
                
                Console.WriteLine($"{word[j]} -> {symbol}" );
            }
        }
    }
}

