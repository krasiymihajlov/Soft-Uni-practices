namespace FastFood.DataProcessor
{
    using System;
    using FastFood.Data;
    using System.Text;
    using Newtonsoft.Json;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using System.Globalization;
    using FastFood.Models.Enums;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            EmployeeDto[] jsonEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();

            foreach (var employeeDto in jsonEmployees)
            {

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = context.Positions.SingleOrDefault(x => x.Name == employeeDto.Position);

                if (position == null)
                {
                    position = new Position()
                    {
                        Name = employeeDto.Position,
                    };

                    context.Add(position);
                    context.SaveChanges();
                }

                var employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position,
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ItemDto[] jsonItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            List<Item> items = new List<Item>();

            foreach (var itemDto in jsonItems)
            {

                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool isValidItemName = items.Any(x => x.Name == itemDto.Name);

                if (isValidItemName)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = context.Categories.SingleOrDefault(x => x.Name == itemDto.Category);

                if (category == null)
                {
                    category = new Category()
                    {
                        Name = itemDto.Category,
                    };

                    context.Add(category);
                    context.SaveChanges();
                }

                var employee = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category,
                };

                items.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }

            context.AddRange(items);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            List<Order> orders = new List<Order>();

            foreach (var orderDto in deserializedOrders)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (!orderDto.Items.All(IsValid))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime date = DateTime.ParseExact(orderDto.DateTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var employee = context.Employees.SingleOrDefault(x => x.Name == orderDto.EmployeeName);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                OrderType type = OrderType.ForHere;

                type = orderDto.Type;

                Order order = new Order()
                {
                    Customer = orderDto.Customer,
                    DateTime = date,
                    Type = type,
                    Employee = employee
                };

                OrderItem[] orderItems = orderDto.Items.Select(x => new OrderItem
                {
                    Quantity = x.Quantity,
                    Item = context.Items.SingleOrDefault(s => s.Name == x.Name),
                    Order = order
                })
                .ToArray();

                var orderItemsAreValid = orderItems.All(oi => oi.Item != null);

                if (!orderItemsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                order.OrderItems = orderItems;

                orders.Add(order);
                sb.AppendLine($"Order for {orderDto.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm")} added");
            }

            context.AddRange(orders);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            System.ComponentModel.DataAnnotations.ValidationContext validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}