namespace _03.FirstName
{
    using System;
    using System.Linq;

    public class FirstName
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split();
            char[] startSymbols = Console.ReadLine().ToLower().ToCharArray().Where(c => c != ' ').ToArray();

            string[] result = names.Where(n => startSymbols.Contains(char.ToLower(n[0]))).ToArray();

            Console.WriteLine(result.Length != 0 ? result.OrderBy(n => n).First() : "No match");
        }
    }
}
