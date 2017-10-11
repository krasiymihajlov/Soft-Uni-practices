using System;

namespace _05.BorderControl
{
    public class Citizens : INumber
    {
        public Citizens(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
    }
}
