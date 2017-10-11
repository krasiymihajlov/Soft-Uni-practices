namespace _05.PizzaCalories
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public decimal Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public decimal CaloriesPerGram()
        {
            decimal result = this.Weight * 2;
            switch (this.FlourType)
            {
                case "White":
                    result *= 1.5m;
                    break;
                case "Wholegrain":
                    result *= 1.0m;
                    break;
                default:
                    break;
            }

            switch (this.BakingTechnique)
            {
                case "Crispy":
                    result *= 0.9m;
                    break;
                case "Chewy":
                    result *= 1.1m;
                    break;
                case "Homemade":
                    result *= 1.0m;
                    break;
                default:
                    break;
            }

            return result;
        }

    }
}
