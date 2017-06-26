namespace _04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
    {
        public static void Main()
        {
            List<Student> students = GetStudnets();
            Console.WriteLine(string.Join(Environment.NewLine, students
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName)
                .Select(s => $"{s.FirstName} {s.LastName}")));
        }

        private static List<Student> GetStudnets()
        {
            List<Student> names = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    names.Add(new Student { FirstName = tokens[0], LastName = tokens[1] });
                }
            }

            return names;
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
