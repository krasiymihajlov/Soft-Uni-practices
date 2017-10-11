namespace _06.BirthdayCelebrations
{
    public class Citizens : INumber, IIdentity
    {
        public Citizens(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
    }
}
