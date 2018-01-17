namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using FastFood.Data;
    using Newtonsoft.Json;
    using System.Linq;

    public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            //.Where(x => x.Employee.Name == employeeName && x.Type.ToString() == orderType)
            var ordersTest = context.Orders
            .Where(x => x.Employee.Name == employeeName && x.Type.ToString() == orderType)
            .ToArray();

            var orders = context.Employees
                .Where(emp => emp.Name == employeeName )//&& emp.Orders.Select(x => x.Type.ToString()) == orderType)
                .Select(o => new
                {
                    Name = o.Name,
                    Orders = o.Orders.Select(x => new
                    {
                        Customer = x.Customer,
                        Items = x.OrderItems.Select(i => new
                        {
                            Name = i.Item.Name,
                            Price = i.Item.Price,
                            Quantity = i.Quantity
                        }),
                        TotalPrice = x.OrderItems.Sum(d => d.Item.Price * d.Quantity),
                    })
                     .OrderByDescending(a => a.TotalPrice)
                    .ThenByDescending(a => a.Items.Count())
                    .ToArray(),
                    TotalMade = o.Orders.Sum(x => x.OrderItems.Sum(d => d.Item.Price * d.Quantity))
                })
                .SingleOrDefault();

            var json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            return json;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            //var statistics 
            //var json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            //return json;
            return "Cur";
        }
	}
}