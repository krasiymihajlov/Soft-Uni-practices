namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Person> allPeople;
            List<Product> allProducts;

            try
            {
                allPeople = new List<Person>(Console.ReadLine()
               .Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Split('='))
               .Select(x => new Person(x[0], decimal.Parse(x[1]))));

                allProducts = new List<Product>(Console.ReadLine()
                    .Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split('='))
                    .Select(x => new Product(x[0], decimal.Parse(x[1]))));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            List<Person> persons = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string productName = tokens[1];

                var currentProduct = allProducts.Where(p => p.Name == productName).FirstOrDefault();
                var currentBuyer = allPeople.Where(p => p.Name == name).FirstOrDefault();

                if (currentBuyer.Money >= currentProduct.Cost)
                {
                    currentBuyer.SubstractMoney(currentProduct);
                    Console.WriteLine($"{currentBuyer.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentBuyer.Name} can't afford {currentProduct.Name}");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, allPeople
                .Select(person => (person.BagOfProducts.Count == 0)
                    ? $"{person.Name} - Nothing bought"
                    : $"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(product => product.Name))}")));
        }
    }
}
