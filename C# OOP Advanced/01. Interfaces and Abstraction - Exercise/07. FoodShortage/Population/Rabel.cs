namespace _07.FoodShortage.Population
{
    using System;
    using _07.FoodShortage.Interfaces;

    public class Rabel :  IBuyer
    {
        private int food;
        public Rabel(string name, int age, string group )
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public int Food
        {
            get { return this.food; }
            set { this.food = value; }
        }

        public int BuyFood()
        {
           return 5;
        }
    }
}
