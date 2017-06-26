namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;

    public class StudentsByAge
    {
        public static void Main()
        {
            List<Name> names = new List<Name>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    Name name = new Name
                    {
                        age = int.Parse(tokens[2]),
                        FirstName = tokens[0],
                        LastName = tokens[1]
                    };

                    if(name.age >= 18 && name.age <= 24)
                    {
                        names.Add(name);
                    }
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine($"{name.FirstName} {name.LastName} {name.age}");
            }
        }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public int age { get; set; }
        public string LastName { get; set; }
    }
}
