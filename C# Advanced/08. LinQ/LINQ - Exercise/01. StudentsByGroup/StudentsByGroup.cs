namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentsByGroup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            List<Names> names = new List<Names>();

            while (input != "END")
            {
                sb.Append(input).Append(" ");
                input = Console.ReadLine();
            }

            string[] lines = sb.ToString().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i += 3)
            {                
                string firstName = lines[i];
                string secondName = lines[i + 1];
                long digit;
                bool isValid = long.TryParse(lines[i + 2], out digit);

                if (isValid && digit == 2)
                {
                    names.Add(new Names { FirstName = firstName, SecondName = secondName });
                }
            }

            foreach (var name in names.OrderBy(w => w.FirstName))
            {
                Console.WriteLine($"{name.FirstName} {name.SecondName}");
            }
        }
    }

    public class Names
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
