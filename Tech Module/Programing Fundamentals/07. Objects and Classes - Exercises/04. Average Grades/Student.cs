namespace _04.Average_Grades
{
    using System.Linq;
    using System.Collections.Generic;
    public class Student
    {
        public string Name { get; set; }

        public double[] Grades { get; set; }

        public double AverageGrade => Grades.Average(); 
    }
}
