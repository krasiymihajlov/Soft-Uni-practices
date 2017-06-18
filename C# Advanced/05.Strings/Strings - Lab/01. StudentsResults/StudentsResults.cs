namespace _01.StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsResults
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, decimal[]>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var name = line[0];

                if (!students.ContainsKey(name))
                {
                    students[name] = new decimal[3];
                }

                students[name][0] = decimal.Parse(line[1]);
                students[name][1] = decimal.Parse(line[2]);
                students[name][2] = decimal.Parse(line[3]);
            }

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            foreach (var student in students)
            {
                var name = student.Key;
                var result = student.Value;

                Console.WriteLine("{0,-10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", name ,result[0], result[1], result[2], result.Average());
            }
        }
    }
}
