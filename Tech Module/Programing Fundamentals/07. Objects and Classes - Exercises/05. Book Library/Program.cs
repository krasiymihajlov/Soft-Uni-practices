namespace _05.Book_Library
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Collections.Generic;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var library = new Library("New Library");

            for (int i = 0; i < number; i++)
            {
                var row = Console.ReadLine().Split();

                string title = row[0];
                string author = row[1];
                string publisher = row[2];
                DateTime releaseDate = DateTime.ParseExact(row[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = row[4];
                double price = double.Parse(row[5]);

                var book = new Book(title, author, publisher, releaseDate, isbn, price);

                library.Book.Add(book);                
            }

            foreach (var authors in GetBookDictionary(library).OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                var author = authors.Key;
                var price = authors.Value;
                Console.WriteLine($"{author} -> {price:f2}");
            }
        }

        private static Dictionary<string, double> GetBookDictionary(Library library)
        {
            var libraryDict = new Dictionary<string, double>();

            foreach (var book in library.Book)
            {
                var author = book.Author;
                var price = book.Price;
                if (!libraryDict.ContainsKey(author))
                {
                    libraryDict[author] = price;
                }
                else
                {
                    libraryDict[author] += price;
                }
            }
            return libraryDict;
        }
    }

    public class Book
    {
        public Book(string title, string author, string publisher,
            DateTime releaseDate, string isbn, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    public class Library
    {
        public Library(string name)
        {
            this.Name = name;
            this.Book = new List<Book>();
        }

        public string Name { get; set; }

        public List<Book> Book { get; set; }

    }
}
