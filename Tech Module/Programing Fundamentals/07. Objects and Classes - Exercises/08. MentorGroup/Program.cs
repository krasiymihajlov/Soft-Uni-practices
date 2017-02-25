namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var inputDate = Console.ReadLine();
            var students = new SortedDictionary<string, Students>();

            while (inputDate != "end of dates")
            {

                var separatedDate = inputDate.Split(' ', ',');
                var name = separatedDate[0];

                if (!students.ContainsKey(name))
                {
                    students[name] = new Students
                    {
                        Name = name,
                        Dates = new List<DateTime>(),
                        Comments = new List<string>()
                    };
                }

                if (separatedDate.Length < 2)
                {
                    inputDate = Console.ReadLine();
                    continue;
                }

                for (int i = 1; i < separatedDate.Length; i++)
                {
                    var date = DateTime.ParseExact(
                        separatedDate[i],
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                    var student = new Students();
                    student.Name = name;
                    student.Dates = new List<DateTime>();
                    student.Dates.Add(date);

                    if (!students.ContainsKey(name))
                    {
                        students[name] = student;
                    }
                    else
                    {
                        students[name].Dates.Add(date);
                    }
                }


                inputDate = Console.ReadLine();
            }

            var inputComments = Console.ReadLine();

            while (inputComments != "end of comments")
            {
                var separatedComments = inputComments.Split('-');
                var name = separatedComments[0];
                var comment = separatedComments[1];

                if (!students.ContainsKey(name))
                {
                    inputComments = Console.ReadLine();
                    continue;
                }

                var student = new Students();
                student.Comments = new List<string>();
                student.Comments.Add(comment);

                if (students[name].Comments == null)
                {
                    students[name].Comments = student.Comments;
                }
                else
                {
                    students[name].Comments.Add(comment);
                }

                inputComments = Console.ReadLine();
            }

            foreach (var name in students)
            {
                var nameOfStudent = name.Key;
                Console.WriteLine(nameOfStudent);
                Console.WriteLine("Comments:");
                if (name.Value.Comments == null)
                {
                }
                else
                {
                    foreach (var comment in name.Value.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }

                Console.WriteLine("Dates attended:");

                foreach (var date in name.Value.Dates.OrderBy(y => y))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }

            Console.WriteLine();
        }
    }

    public class Students
    {
        public List<string> Comments { get; set; }

        public List<DateTime> Dates { get; set; }

        public string Name { get; set; }
    }
}
