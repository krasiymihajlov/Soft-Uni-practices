using System;

public abstract class Driver
{
    private string name;
    private double totalТime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;
    
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get
        {
            return this.name; 
        }

        protected set
        {
            this.name = value;
        }
    }

    public double TotalТime
    {
        get
        {
            return this.totalТime;
        }

        protected set
        {
            this.totalТime = value;
        }
    }

    public double FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }

        protected set
        {
            this.fuelConsumptionPerKm = value;
        }
    }

    public double Speed
    {
        get
        {
            return this.speed;
        }

        protected set
        {
            this.speed = (this.car.HP + this.car.Tyre.Degradation) / this.car.FuelAmount;
        }
    }

    public Car Car
    {
        get { return this.car; }
        protected set { this.car = value; }
    }
}

