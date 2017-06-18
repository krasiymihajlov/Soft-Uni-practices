namespace _02.Randomize_Words
{
    using System;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                var currentWord = input[i];
                var randomWord = random.Next(0, input.Length);

                var nextWord = input[randomWord];
                input[randomWord] = currentWord;
                input[i] = nextWord;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
