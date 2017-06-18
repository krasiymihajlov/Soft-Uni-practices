namespace _02.ParseURLs
{
    using System;

    public class ParseURLs
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { @"://" }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != 2 || input[1].IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var protocol = input[0];
            var index = input[1].IndexOf(@"/");
            var server = input[1].Substring(0, index);
            var resource = input[1].Substring(index + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resource}");
        }
    }
}
