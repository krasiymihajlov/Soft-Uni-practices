namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            List<StudentSpecialty> speciality = GetSpeciality();
            List<Student>  students = GetStudents();

            var studentsSpeciality = students.Join(speciality,
                st => st.Faculty,
                sp => sp.FacNumber,
                (st, sp) => new
                {
                    Name = st.StudentName,
                    FacNumber = st.Faculty,
                    Speciality = sp.SpecialityName
                });

            Console.WriteLine(string.Join(Environment.NewLine, studentsSpeciality
                .OrderBy(p => p.Name)
                .Select(s => $"{s.Name} {s.FacNumber} {s.Speciality}")));
        }

        private static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            string input;
            while ((input = Console.ReadLine().Trim()) != "END")
            {
                string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    students.Add(new Student { Faculty = tokens[0], StudentName = tokens[1] + " " + tokens[2] });
                }
            }

            return students;
        }

        private static List<StudentSpecialty> GetSpeciality()
        {
            List<StudentSpecialty> speciality = new List<StudentSpecialty>();

            string input;
            while((input = Console.ReadLine().Trim()) != "Students:")
            {
                string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    speciality.Add(new StudentSpecialty { FacNumber = tokens[2], SpecialityName = tokens[0] + " " + tokens[1] });
                }
            }

            return speciality;
        }
    }

    public class StudentSpecialty
    {
        public string SpecialityName { get; set; }

        public string FacNumber { get; set; }
    }

    public class Student
    {
        public string StudentName { get; set; }

        public string Faculty { get; set; }
    }
}
