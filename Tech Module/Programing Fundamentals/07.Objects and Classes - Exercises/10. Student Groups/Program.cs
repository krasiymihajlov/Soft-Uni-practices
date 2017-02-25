namespace _10.Student_Groups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class ObjectAndClassesExer
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var towns = ReadTownAndStudents(input);
            var groups = DistributeStudentsIntoGroups(towns);

            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach (var group in groups)
            {
                Console.Write($"{group.Town.Name} => ");
                Console.WriteLine($"{string.Join(", ", group.Students.Select(x => x.Email))}");
            }
        }

        public static List<Town> ReadTownAndStudents(string input)
        {
            var towns = new List<Town>();
            while (input != "End")
            {
                if (input.IndexOf("=>") != -1)
                {
                    var townSeparated = input
                        .Split(new string[] { " => " },
                        StringSplitOptions.RemoveEmptyEntries);

                    var townName = townSeparated[0];
                    var seats = townSeparated[1].Split();
                    var seatCount = int.Parse(seats[0]);

                    var currentTown = new Town
                    {
                        Name = townName,
                        SeatsCount = seatCount,
                        Students = new List<Student>()
                    };

                    towns.Add(currentTown);
                }
                else
                {
                    var studentsSeparated = input
                        .Split(new[] { '|' },
                        StringSplitOptions.RemoveEmptyEntries);

                    var name = studentsSeparated[0].Trim();
                    var email = studentsSeparated[1].Trim();
                    var date = DateTime.ParseExact(
                        studentsSeparated[2].Trim(),
                        "d-MMM-yyyy",
                        CultureInfo.InvariantCulture);

                    var student = new Student
                    {
                        Name = name,
                        Email = email,
                        Date = date
                    };

                    towns[towns.Count - 1].Students.Add(student);
                }

                input = Console.ReadLine();
            }

            return towns;
        }

        public static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();
            var students = new List<Student>();

            foreach (var town in towns.OrderBy(x => x.Name))
            {
                students = town.Students
                    .OrderBy(x => x.Date)
                    .ThenBy(y => y.Name)
                    .ThenBy(z => z.Email)
                    .ToList();

                while (students.Any())
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = students
                        .Take(group.Town.SeatsCount)
                        .ToList();

                    students = students
                        .Skip(group.Town.SeatsCount)
                        .ToList();

                    groups.Add(group);
                }
            }

            return groups;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
