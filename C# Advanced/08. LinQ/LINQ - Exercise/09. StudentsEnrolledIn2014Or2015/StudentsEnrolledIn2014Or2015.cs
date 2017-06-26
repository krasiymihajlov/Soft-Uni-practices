namespace _09.StudentsEnrolledIn2014Or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014Or2015
    {
        public static void Main()
        {
            List<Student> students = GetStudnets();
            Console.WriteLine(string.Join(Environment.NewLine, students
                .Where(s => s.FacNomer.LastIndexOf("14") == 4 || s.FacNomer.LastIndexOf("15") == 4)
                .Select(s => $"{s.Mark}")));
        }

        private static List<Student> GetStudnets()
        {
            List<Student> names = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length >= 2)
                {
                    string[] temp = tokens.Skip(1).ToArray();
                    string mark = string.Empty;

                    foreach (var item in temp)
                    {
                        mark += item + " ";
                    }

                    names.Add(new Student { FacNomer = tokens[0], Mark = mark});
                }
            }

            return names;
        }
    }

    public class Student
    {
        public string FacNomer { get; set; }

        public string Mark { get; set; }
    }
}