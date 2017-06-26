namespace _02.StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            List<KeyValuePair<string, string>> names = new List<KeyValuePair<string, string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {

                    names.Add(new KeyValuePair<string, string>(tokens[0], tokens[1]));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, names
                .Where(s => s.Key.CompareTo(s.Value) < 0)
                .Select(s => $"{s.Key} {s.Value}")));
        }
    }
}