namespace _03.Unicode_Characters
{
    using System;

    public class StringExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            foreach (var symbol in input)
            {
                Console.Write("\\u" + $"{((int)symbol).ToString("x4")}");
            }

            Console.WriteLine();
        }
    }
}
