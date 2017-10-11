public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public int Power
    {
        get { return this.power; }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        return $"{this.name}, Power: {this.Power}";
    }
}

