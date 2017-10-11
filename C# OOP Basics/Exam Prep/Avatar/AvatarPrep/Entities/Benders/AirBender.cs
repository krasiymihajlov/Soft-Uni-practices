public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    public override double GetPower()
    {
        return this.aerialIntegrity * this.Power;
    }

    public override string ToString()
    {
        return $"Air Bender: {base.ToString()}, Aerial Integrity: {this.aerialIntegrity:f2}";
    }
}

