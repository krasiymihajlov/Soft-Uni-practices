namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
    {
        public static void Main()
        {
            Dictionary<int, List<string>> students = GetStudnets();
            Console.WriteLine(string.Join(Environment.NewLine, students
                .OrderBy(p => p.Key)
                .Select(s => $"{s.Key} - {string.Join(", ", s.Value)}")));
        }

        private static Dictionary<int, List<string>> GetStudnets()
        {
            Dictionary<int, List<string>> names = new Dictionary<int, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                   Person person = new Person { Name = tokens[0] + " " +  tokens[1], Group = int.Parse(tokens[2])};

                    if(!names.ContainsKey(person.Group))
                    {
                        names[person.Group] = new List<string>();
                    }

                    names[person.Group].Add(person.Name);
                }
            }

            return names;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Group { get; set; }
    }
}