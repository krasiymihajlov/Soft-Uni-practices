namespace _04.Average_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < number; i++)
            {
                var currentRow = Console.ReadLine().Split();

                var student = new Student
                {
                    Grades = new double[currentRow.Length - 1],
                    Name = currentRow[0]
                };

                for (int j = 1; j < currentRow.Length; j++)
                {
                    student.Grades[j - 1] = double.Parse(currentRow[j]);
                }
                if (student.AverageGrade >= 5.00)
                {
                    students.Add(student);
                }                                                               
            }

            var people = students.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

            foreach (var name in people)
            {
                Console.WriteLine($"{name.Name} -> {name.AverageGrade:f2}");
            }
        }
    }
}
