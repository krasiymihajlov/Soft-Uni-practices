public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        protected set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return this.car; }
        private set { this.car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }

        protected set { this.fuelConsumptionPerKm = value; }
    }
    
    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
    }

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}

