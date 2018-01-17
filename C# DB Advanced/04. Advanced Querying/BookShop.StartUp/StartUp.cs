namespace BookShop
{
    using BookShop.Data;
    using System.Text;
    using System;
    using System.Linq;
    using BookShop.Models;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                //string input = Console.ReadLine();
                //int input = int.Parse(Console.ReadLine());

                Console.WriteLine($"{RemoveBooks(context)} books were deleted");
            }
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            Book[] books = context.Books
                .Where(x => x.Copies < 4200)
                .ToArray();

            int removeElements = books.Count();
            context.RemoveRange(books);
            context.SaveChanges();

            return removeElements;
        }

        //14. Increase Prices
        public static int IncreasePrices(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            Book[] books = context.Books
                .Where(x => x.ReleaseDate != null && x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }
            
            return context.SaveChanges();            
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var query = context.Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                Books = c.CategoryBooks.Select(x => x.Book),
            })
            .ToArray();

            foreach (var categories in query.OrderBy(x => x.CategoryName).ThenBy(x => x.Books.Count()))
            {
                sb.Append($"--{categories.CategoryName}").Append(Environment.NewLine);
                foreach (var book in categories.Books.OrderByDescending(c => c.ReleaseDate).Take(3))
                {
                    sb.Append($"{book.Title} ({book.ReleaseDate.Value.Year})").Append(Environment.NewLine);
                }
            }

            return sb.ToString().Trim();
        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var dict = new Dictionary<string, decimal>();

            var query = context.Books
            .Select(c => new
            {
                Profit = c.Copies * c.Price,
                CategoryName = c.BookCategories.Select(x => x.Category.Name),

            })
            .ToArray();

            foreach (var q in query)
            {
                foreach (var catName in q.CategoryName)
                {
                    if (!dict.ContainsKey(catName))
                    {
                        dict[catName] = q.Profit;
                    }
                    else
                    {
                        dict[catName] += q.Profit;
                    }
                }
            }

            foreach (var r in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                sb.Append($"{r.Key} ${r.Value:F2}").Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var query = context.Authors
            .Select(c => new
            {
                Name = $"{c.FirstName} {c.LastName}",
                BooksCopies = c.Books.Sum(b => b.Copies),
            })
            .OrderByDescending(x => x.BooksCopies)
            .ToArray();

            return string.Join(Environment.NewLine, query.Select(x => $"{x.Name} - {x.BooksCopies}"));
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var query = context.Books
            .Where(c => c.Title.Count() > lengthCheck)
            .Select(t => t.BookId)
            .ToArray();

            int count = 0;

            foreach (var q in query)
            {
                count++;
            }

            return count;
        }

        //09. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var query = context.Books
            .Where(c => c.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .Select(t => new
            {
                t.Title,
                t.BookId,
                AuthorName = $"{t.Author.FirstName} {t.Author.LastName}",
            })
            .OrderBy(n => n.BookId)
            .ToArray();

            return string.Join(Environment.NewLine, query.Select(x => $"{x.Title} ({x.AuthorName})"));
        }

        //08. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var query = context.Books
            .Where(c => c.Title.ToLower().Contains(input.ToLower()))
            .Select(t => t.Title)
            .OrderBy(n => n)
            .ToArray();

            return string.Join(Environment.NewLine, query);
        }

        //07. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var query = context.Authors
            .Where(c => c.FirstName.ToLower().EndsWith(input.ToLower()))
            .Select(t => $"{t.FirstName} {t.LastName}")
            .OrderBy(n => n)
            .ToArray();

            return string.Join(Environment.NewLine, query);
        }

        //06. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string input)
        {
            var date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var query = context.Books
            .Where(c => c.ReleaseDate.Value < date)
            .Select(t => new
            {
                Result = $"{t.Title} - {t.EditionType} - ${t.Price:F2}",
                Date = t.ReleaseDate,
            })
            .OrderByDescending(d => d.Date)
            .ToArray();

            return string.Join(Environment.NewLine, query.Select(x => x.Result));
        }

        //05. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = Regex.Split(input, @"\s+", RegexOptions.IgnoreCase);

            List<string> list = new List<string>();

            foreach (var item in categories)
            {
                list.AddRange(context.Books
                .Where(c => c.BookCategories.Select(x => x.Category.Name.ToLower()).Contains(item.ToLower()))
                .Select(b => b.Title)
                .ToArray());
            }

            return string.Join(Environment.NewLine, list.OrderBy(x => x));
        }

        //04. Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var query = context.Books
                .Where(c => c.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    Title = b.Title,
                    BookId = b.BookId,
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var q in query)
            {
                sb.Append($"{q.Title}").Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        //03. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var query = context.Books
                .Where(c => c.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var q in query)
            {
                sb.Append($"{q.Title} - ${q.Price:f2}").Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        //02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var query = context.Books
                .Where(a => a.EditionType.ToString().Equals("Gold", StringComparison.InvariantCultureIgnoreCase))
                .Where(c => c.Copies < 5000)
                .Select(b => new
                {
                    Title = b.Title,
                    BookId = b.BookId,
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var title in query)
            {
                sb.Append(title.Title).Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        //01. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            string[] query = context.Books
                .Where(a => a.AgeRestriction.ToString().Equals(command, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            foreach (var title in query)
            {
                sb.Append(title).Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }
    }
}
