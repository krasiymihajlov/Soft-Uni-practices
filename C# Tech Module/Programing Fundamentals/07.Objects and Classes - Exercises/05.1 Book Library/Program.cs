namespace _05.Book_Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var books = new Dictionary<string, double>();

            for (int i = 0; i < number; i++)
            {
                var row = Console.ReadLine().Split();

                var name = row[1];
                var price = double.Parse(row[5]);

                if (!books.ContainsKey(name))
                {
                    books[name] = price;
                }
                else
                {
                    books[name] += price;
                }
            }

            foreach (var book in books.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{book.Key} -> {book.Value:f2}");
            }
        }
    }
}
