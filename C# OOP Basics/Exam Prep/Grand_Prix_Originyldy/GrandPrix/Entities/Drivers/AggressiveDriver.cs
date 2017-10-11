public class AggressiveDriver : Driver
{
    private const double FuelConsumptionPerKmAggressive = 2.7;
    private const double SpeedMultiply = 1.3;

    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        this.FuelConsumptionPerKm = FuelConsumptionPerKmAggressive;
        //this.Speed = this.Speed * SpeedMultiply;
    }

    public override double Speed
    {
        get { return base.Speed * SpeedMultiply; }
    }
}

