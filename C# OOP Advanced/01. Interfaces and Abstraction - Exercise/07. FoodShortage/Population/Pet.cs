namespace _07.FoodShortage.Population
{
    using _07.FoodShortage.Interfaces;

    public class Pet : IIdentity
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
