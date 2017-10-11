namespace _03.Detail_Printer
{
    public abstract class Employee 
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string PrintDetails()
        {
            return this.Name;
        }
    }
}