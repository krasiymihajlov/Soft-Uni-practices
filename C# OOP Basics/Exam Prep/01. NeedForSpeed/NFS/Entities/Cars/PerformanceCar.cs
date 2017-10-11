using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}


