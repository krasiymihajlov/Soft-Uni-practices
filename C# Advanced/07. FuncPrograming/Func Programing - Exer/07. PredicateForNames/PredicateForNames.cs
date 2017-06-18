namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;

    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isTrue = n => n.Length <= length;
            List<string> result = GetNames(isTrue, length, names);
            PrintResult(result);
        }

        private static void PrintResult(List<string> result)
        {
            Console.WriteLine(string.Join("\n", result));
        }

        public static List<string> GetNames(Func<string, bool> isTrue, int length, string[] names)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (isTrue(names[i]))
                {
                    list.Add(names[i]);
                }
            }

            return list;
        }
    }
}
