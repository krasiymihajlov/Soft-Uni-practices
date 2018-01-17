namespace FastFood.DataProcessor
{
    using System;
    using FastFood.Data;
    using System.Linq;

    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
            var oldPrice = 0M;
            var item = context.Items
                .Where(x => x.Name == itemName)
                .SingleOrDefault();

            if (item == null)
            {
                return $"Item {itemName} not found!";
            }

            oldPrice = item.Price;
            item.Price = newPrice;            

            context.SaveChanges();            

            return $"{itemName} Price updated from ${oldPrice:F2} to ${newPrice}";
	    }
    }
}
