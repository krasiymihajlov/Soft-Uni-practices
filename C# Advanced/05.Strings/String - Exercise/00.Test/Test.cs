namespace _15.MelrahShake
{
    using System;
    using System.IO;

    public class MelrahShake
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            string path = @"C:\Users\BauMc\Desktop\result.txt";

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(input);
            }

            while (true)
            {
                int firstIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);

                if (firstIndex == lastIndex) // || firstMatch < 0)
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                string firstPart = input.Substring(0, firstIndex);
                string secondPart = input.Substring(firstIndex + pattern.Length, lastIndex - (firstPart.Length + pattern.Length));
                string thirdPart = input.Substring(lastIndex + pattern.Length);

                input = firstPart + secondPart + thirdPart;

                Console.WriteLine("Shaked it.");

                pattern = pattern.Remove(pattern.Length / 2, 1);

                if (pattern.Length <= 0)
                {
                    //Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(input);
        }
    }
}