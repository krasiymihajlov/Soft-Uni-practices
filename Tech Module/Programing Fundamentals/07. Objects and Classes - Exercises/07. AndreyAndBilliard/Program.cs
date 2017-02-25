namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var productDict = new Dictionary<string, decimal>();


            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine().Split('-');

                string product = line[0];
                decimal price = decimal.Parse(line[1]);

                if (!productDict.ContainsKey(product))
                {
                    productDict[product] = price;
                }
                else
                {
                    productDict[product] = price;
                }
            }

            var namesLine = Console.ReadLine();
            var clients = new List<Clients>();

            while (namesLine != "end of clients")
            {
                var secondLine = namesLine.Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var name = secondLine[0];
                var product = secondLine[1];
                var quantity = decimal.Parse(secondLine[2]);

                if (!productDict.ContainsKey(product))
                {
                    namesLine = Console.ReadLine();
                    continue;
                }

                if (clients.Any(x => x.Name == name))
                {
                    var client = clients.First(x => x.Name == name);
                    
                    if (!client.ShopList.ContainsKey(product))
                    {                        
                        client.ShopList[product] = quantity;
                    }
                    else
                    {
                        client.ShopList[product] += quantity;
                    }

                    client.Bill += quantity * productDict[product];
                }
                else
                {
                    var client = new Clients();
                    client.Name = name;
                    client.ShopList = new Dictionary<string, decimal>();
                    client.ShopList[product] = quantity;
                    client.Bill = quantity * productDict[product];
                    clients.Add(client);
                }

                namesLine = Console.ReadLine();
            }

            foreach (var client in clients.OrderBy(x => x.Name))
            {
                Console.WriteLine(client.Name);
                foreach (var product in client.ShopList)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }

                Console.WriteLine($"Bill: {client.Bill:F2}");
            }

            var totalBill = clients.Sum(x => x.Bill);

            Console.WriteLine($"Total bill: {totalBill:F2}");
        }
    }


    public class Clients
    {

        public string Name { get; set; }

        public Dictionary<string, decimal> ShopList { get; set; }

        public decimal Bill { get; set; }


    }
}
