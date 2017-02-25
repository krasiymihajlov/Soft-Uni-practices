using System;
using System.Collections.Generic;
using System.Linq;
namespace _7.Andrey_and_billiard
{
    class Program
    {
        static void Main()
        {
            var shop = new Dictionary<string, decimal>();
            var s = int.Parse(Console.ReadLine());
            List<Customer> allCustomers = new List<Customer>();

            for (int i = 0; i < s; i++)
            {
                var line = Console.ReadLine().Split('-').ToList();

                if (!shop.ContainsKey(line[0]))
                {
                    shop.Add(line[0], decimal.Parse(line[1]));
                }
                else
                {
                    shop[line[0]] = decimal.Parse(line[1]);
                }
            }
            var customersOrders = string.Empty;
            while ((customersOrders = Console.ReadLine()) != "end of clients")
            {
                var info = customersOrders.Split(new[] { ',', '-' }).ToList();
                var client = new Customer();
                string product = info[1];
                int quantity = int.Parse(info[2]);
                string customerName = info[0];
                client.ShopList = new Dictionary<string, int>();
                client.Name = customerName;

                if (!shop.ContainsKey(product))
                {
                    continue;
                }

                client.ShopList.Add(product, quantity);

                if (allCustomers.Any(m => m.Name == customerName))
                {
                    Customer existingCustomer = allCustomers.First(m => m.Name == customerName);
                    if (existingCustomer.ShopList.ContainsKey(product))
                    {
                        existingCustomer.ShopList[product] += quantity;
                    }
                    else
                    {
                        existingCustomer.ShopList[product] = quantity;
                    }
                }
                else
                {
                    allCustomers.Add(client);
                }
            }
            //Bill Calculating
            foreach (var customers in allCustomers)
            {
                foreach (var item in customers.ShopList)
                {
                    foreach (var product in shop)
                    {
                        if (item.Key == product.Key)
                        {
                            customers.Bill += item.Value * product.Value;
                        }

                    }
                }
            }
            var ordered = allCustomers
                .OrderBy(p => p.Name)
                .ThenBy(x => x.Bill)
                .ToList();

            foreach (var client in ordered)
            {
                Console.WriteLine(client.Name);
                foreach (KeyValuePair<string, int> item in client.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {client.Bill:F2}");
            }
            Console.WriteLine($"Total bill: {allCustomers.Sum(h => h.Bill):F2}");

        }
    }
    class Customer
    {
        /*  Create class Customer. Every customer should have name, Dictionary<string, int> for every bought
       
        product with quantity (something like a ShopList) and Bill property.*/
        public string Name { get; set; }
        public Dictionary<string, int> ShopList { get; set; }

        public decimal Bill { get; set; }
    }


}