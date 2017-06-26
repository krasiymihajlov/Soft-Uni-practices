namespace _07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
    {
        public static void Main()
        {
            List<Student> students = GetStudnets();
            Console.WriteLine(string.Join(Environment.NewLine, students
                .Where(s => s.Mark == 6)
                .Select(s => $"{s.FirstName} {s.LastName}")));
        }

        private static List<Student> GetStudnets()
        {
            List<Student> names = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length >= 3)
                {
                    names.Add(new Student { FirstName = tokens[0], LastName = tokens[1], Mark = tokens.Skip(2).Select(decimal.Parse).Where(x => x == 6).FirstOrDefault()});
                }
            }

            return names;
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Mark { get; set; }
    }
}
