public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.groundSaturation = groundSaturation;
    }

    public override double GetPower()
    {
        return this.groundSaturation * this.Power;
    }

    public override string ToString()
    {
        return $"Earth Bender: {base.ToString()}, Ground Saturation: {this.groundSaturation:f2}";
    }
}

