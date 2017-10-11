namespace _05.PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string product = tokens[0];
                if (product == "Dough")
                {
                    try
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], decimal.Parse(tokens[3]));
                        Console.WriteLine("{0:F2}", dough.CaloriesPerGram());
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (product == "Topping")
                {
                    try
                    {
                        Topping topping = new Topping(tokens[1], decimal.Parse(tokens[2]));
                        Console.WriteLine("{0:F2}", topping.CaloriesPerGram());
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
            }
        }
    }
}
