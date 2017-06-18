namespace _09.Melrah_Shake
{
    using System;

    public class StringExercise
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = input.IndexOf(pattern);
                var lastIndex = input.LastIndexOf(pattern);

                if (firstIndex != -1 && lastIndex != -1 &&
                    firstIndex != lastIndex && pattern.Length > 0)
                {
                    Console.WriteLine("Shaked it.");
                    input = input.Remove(lastIndex, pattern.Length);
                    input = input.Remove(firstIndex, pattern.Length);
                    
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }

                var indexRemove = pattern.Length / 2;
                pattern = pattern.Remove(indexRemove, 1);

            }
        }
    }
}
