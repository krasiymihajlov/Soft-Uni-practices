namespace _07.FoodShortage.Population
{
    using System;
    using _07.FoodShortage.Interfaces;

    public class Citizens : INumber, IBuyer
    {
        private int food;

        public Citizens(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }

        public int Food
        {
            get { return this.food; }
            set { this.food = value; }
        }

        public int BuyFood()
        {
            return 10;
        }
    }
}
