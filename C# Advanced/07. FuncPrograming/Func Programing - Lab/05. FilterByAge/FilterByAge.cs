namespace _05.FilterByAge
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FilterByAge
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string[] line = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                dict.Add(line[0], int.Parse(line[1]));
            }

            string type = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(type, age);
            Action<KeyValuePair<string, int>> print =  CreatePrinter(format);

            Print(dict, tester, print);
        }

        private static void Print(
            Dictionary<string, int> dict, 
            Func<int, bool> tester, 
            Action<KeyValuePair<string, int>> print)
        {
            foreach (var people in dict)
            {
                if (tester(people.Value))
                {
                    print(people);
                }
            }
        }

        private static Func<int, bool> CreateTester(string type, int age)
        {
            if (type == "older")
            {
                return n => n >= age;
            }
            else
            {
                return n => n < age;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                    break;
                case "name":
                    return p => Console.WriteLine($"{p.Key}");
                    break;
                case "age":
                    return p => Console.WriteLine($"{p.Value}");
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
