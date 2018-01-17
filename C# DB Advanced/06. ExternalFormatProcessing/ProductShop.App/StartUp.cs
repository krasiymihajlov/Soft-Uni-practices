namespace ProductShop.App
{
    using System;
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System.IO;
    using ProductShop.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class StartUp
    {
        private const string jsonCategories = "Files/categories.json";
        private const string xmlCategories = "Files/categories.xml";
        private const string jsonProducts = "Files/products.json";
        private const string xmlProducts = "Files/products.xml";
        private const string jsonUsers = "Files/users.json";
        private const string xmlUsers = "Files/users.xml";

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (ProductShopContext db = new ProductShopContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
            }

            ////Import Json
            //Console.WriteLine(ImportUsersFromJson());
            //Console.WriteLine(ImportCategoriesFromJson());
            //Console.WriteLine(ImportProductsFromJson());
            //Console.WriteLine(ImportCategoryProducts());

            ////ExportJson
            //Console.WriteLine(GetProductInRange());
            //Console.WriteLine(SoldProducts());
            //Console.WriteLine(CategoriesByProductsCount());
            //Console.WriteLine(UsersAndProducts());

            ////Import XML
            //Console.WriteLine(ImportUsersFromXml());
            //Console.WriteLine(ImportCategoriesFromXml());
            //Console.WriteLine(ImportProductsFromXml());
            //Console.WriteLine(ImportCategoryProducts());

            //ExportXML
            Console.WriteLine(GetProductInRangeXml());

        }

        public static string GetProductInRangeXml()
        {
            throw new NotImplementedException();
        }

        public static string ImportProductsFromXml()
        {
            string xmlString = File.ReadAllText(xmlProducts);

            XDocument xml = XDocument.Parse(xmlString);

            XElement[] elements = xml.Root.Elements().ToArray();
            List<Product> products = new List<Product>();

            foreach (var c in elements)
            {
                string name = c.Element("name").Value;

                decimal price = 0M;
                if (c.Element("price")?.Value != null)
                {
                    price = decimal.Parse(c.Element("price").Value);
                }

                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                };

                products.Add(product);
            }
            Random rnd = new Random();

            using (var db = new ProductShopContext())
            {

                int[] userIds = db.Users.Select(u => u.Id).ToArray();
                int count = 0;
                foreach (var p in products)
                {
                    int index = rnd.Next(userIds.Length - 1);
                    int sellerId = userIds[index];
                    int buyerId = sellerId;

                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length - 1);
                        buyerId = userIds[buyerIndex];
                    }

                    p.SellerId = sellerId;

                    if (count % 2 == 0)
                    {
                        p.BuyerId = buyerId;
                    }

                    count++;
                }

                db.AddRange(products);
                db.SaveChanges();
            }

            return $"{products.Count} products import successfuly from file: {xmlProducts}";
        }

        public static string ImportCategoriesFromXml()
        {
            string xmlString = File.ReadAllText(xmlCategories);

            XDocument xml = XDocument.Parse(xmlString);

            XElement[] elements = xml.Root.Elements().ToArray();
            List<Category> categories = new List<Category>();

            foreach (var c in elements)
            {
                string name = c.Element("name").Value;

                Category category = new Category()
                {
                    Name = name,
                };

                categories.Add(category);
            }

            using (var db = new ProductShopContext())
            {
                db.AddRange(categories);
                db.SaveChanges();
            }

            return $"{categories.Count} categories import successfuly from file: {xmlCategories}";
        }

        public static string ImportUsersFromXml()
        {
            string xmlString = File.ReadAllText(xmlUsers);
            XDocument xml = XDocument.Parse(xmlString);

            XElement[] elements = xml.Root.Elements().ToArray();
            List<User> users = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value;
                string lastName = e.Attribute("lastName").Value;

                int? age = null;
                if (e.Attribute("age")?.Value != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                };

                users.Add(user);
            }
            using (var db = new ProductShopContext())
            {
                db.AddRange(users);
                db.SaveChanges();
            }

            return $"{users.Count} users import successfuly from file: {xmlUsers}";
        }

        public static string UsersAndProducts()
        {
            string json = string.Empty;
            using (var context = new ProductShopContext())
            {
                var query = context.Users
                    .Where(s => s.ProductsSold.Count > 0)
                    .OrderByDescending(x => x.ProductsSold.Count())
                    .ThenBy(x => x.LastName)
                    .Select(x => new
                    {
                        usersCount = context.Users.Count(),
                        users = context.Users.Select(c => new
                        {
                            firstName = x.FirstName,
                            lastName = x.LastName,
                            age = x.Age,
                            soldProducts = x.ProductsSold
                           .Select(p => new
                           {
                               count = x.ProductsSold.Count(),
                               products = x.ProductsSold
                               .Select(z => new
                               {
                                   name = z.Name,
                                   price = z.Price,
                               })
                           })
                        })
                    });

                json = JsonConvert.SerializeObject(query, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });
            }

            File.WriteAllText("OutputJson/users-and-products.json", json);
            return "Query 4 => Всичко е точно!";
        }

        public static string CategoriesByProductsCount()
        {
            string json = string.Empty;

            using (var context = new ProductShopContext())
            {
                var query = context.Categories
                    .OrderBy(x => x.Name)
                    .Select(x => new
                    {
                        name = x.Name,
                        productsCount = x.Products.Count,
                        averagePrice = x.Products.Average(a => a.Product.Price),
                        totalRevenue = x.Products.Sum(a => a.Product.Price),
                    })
                    .ToArray();

                json = JsonConvert.SerializeObject(query, Formatting.Indented);
            }

            File.WriteAllText("OutputJson/categories-by-products.json", json);
            return "Query 3 => Всичко е точно!";
        }

        public static string SoldProducts()
        {
            string json = string.Empty;
            using (var context = new ProductShopContext())
            {
                var query = context.Users
                    .Where(x => x.ProductsSold.Any(y => y.BuyerId != null) && x.ProductsSold.Count > 0)
                    .Select(n => new
                    {
                        firstname = n.FirstName,
                        lastname = n.LastName,
                        soldProducts = n.ProductsSold.Select(s => new
                        {
                            name = s.Name,
                            price = s.Price,
                            buyerFirstName = s.Buyer.FirstName ?? "[No Firstname]",
                            buyerLastName = s.Buyer.LastName ?? "[No Lastname]",
                        })
                    })
                    .OrderBy(l => l.lastname)
                    .ThenBy(f => f.firstname)
                    .ToArray();

                json = JsonConvert.SerializeObject(query, Formatting.Indented);
            }

            File.WriteAllText("OutputJson/users-sold-products.json", json);
            return "Query 2 => Всичко е точно!";
        }

        public static string GetProductInRange()
        {
            string json;
            using (var context = new ProductShopContext())
            {
                int minRange = 500;
                int maxRange = 1000;

                var products = context.Products
                    .Where(p => p.Price > minRange && p.Price <= maxRange)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        seller = $"{x.Seller.FirstName} {x.Seller.LastName}",
                    })
                    .OrderBy(x => x.price)
                    .ToArray();

                json = JsonConvert.SerializeObject(products, Formatting.Indented);
            }

            File.WriteAllText("OutputJson/products-in-range.json", json);
            return "Query 1 => Всичко е точно!";
        }

        public static string ImportUsersFromJson()
        {
            User[] users = ImportJson<User>(jsonUsers);

            using (ProductShopContext db = new ProductShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }

            return $"{users.Length} users import successfuly from file: {jsonUsers}";
        }

        public static string ImportProductsFromJson()
        {
            Product[] products = ImportJson<Product>(jsonProducts);
            Random rnd = new Random();

            using (ProductShopContext db = new ProductShopContext())
            {
                int[] userIds = db.Users.Select(u => u.Id).ToArray();
                int count = 0;
                foreach (var p in products)
                {
                    int index = rnd.Next(userIds.Length - 1);
                    int sellerId = userIds[index];
                    int buyerId = sellerId;

                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length - 1);
                        buyerId = userIds[buyerIndex];
                    }

                    p.SellerId = sellerId;

                    if (count % 2 == 0)
                    {
                        p.BuyerId = buyerId;
                    }

                    count++;
                }

                db.Products.AddRange(products);
                db.SaveChanges();
            }

            return $"{products.Length} products import successfuly from file: {jsonProducts}";
        }

        public static string ImportCategoriesFromJson()
        {
            Category[] categories = ImportJson<Category>(jsonCategories);

            using (ProductShopContext db = new ProductShopContext())
            {
                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            return $"{categories.Length} categories import successfuly from file: {jsonCategories}";
        }

        public static string ImportCategoryProducts()
        {
            List<CategoryProduct> categoriesProducts = new List<CategoryProduct>();
            Random rnd = new Random();

            using (ProductShopContext db = new ProductShopContext())
            {
                int[] productIds = db.Products.Select(p => p.Id).ToArray();
                int[] categoryIds = db.Categories.Select(c => c.Id).ToArray();

                foreach (var p in productIds)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int index = rnd.Next(0, categoryIds.Length);
                        int categoryId = categoryIds[index];

                        while (categoriesProducts.Any(x => x.CategoryId == categoryIds[index] && x.ProductId == p))
                        {
                            index = rnd.Next(0, categoryIds.Length);
                            categoryId = categoryIds[index];
                        }

                        CategoryProduct categoryProduct = new CategoryProduct()
                        {
                            ProductId = p,
                            CategoryId = categoryId,
                        };

                        categoriesProducts.Add(categoryProduct);
                    }
                }

                db.CategoryProducts.AddRange(categoriesProducts);
                db.SaveChanges();
            }

            return $"{categoriesProducts.Count} categories import successfuly";
        }

        public static T[] ImportJson<T>(string path)
        {
            string jsonString = File.ReadAllText(path);
            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
    }
}
