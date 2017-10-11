namespace _05.PizzaCalories
{
    using System;

    public class Topping
    {
        private string type;
        private decimal weight;

        public Topping(string type, decimal weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public decimal Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public decimal CaloriesPerGram()
        {
            decimal result = this.Weight * 2;

            switch (this.Type)
            {
                case "Meat":
                    result *= 1.2m;
                    break;
                case "Veggies":
                    result *= 0.8m;
                    break;
                case "Cheese":
                    result *= 1.1m;
                    break;
                case "Sauce":
                    result *= 0.9m;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
