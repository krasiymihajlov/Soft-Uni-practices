public class AggressiveDriver : Driver
{
    private const double FuelConsumptionPerKmAgressive = 2.7;
    private const double SpeedMultiplied = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car)
    {
        this.Speed *= SpeedMultiplied;
        this.FuelConsumptionPerKm = FuelConsumptionPerKmAgressive;
    }
}

