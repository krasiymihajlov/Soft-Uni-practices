using System;

public class Car
{
    private const double MaximumCapacity = 160;
    private const double MinimumCapascity = 0;
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < MinimumCapascity)
            {
                throw new ArgumentException("Out of fuel");
            }

            if (value > MaximumCapacity)
            {
                this.fuelAmount = MaximumCapacity;
            }
            else
            {
                this.fuelAmount += value;
            }
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre newtyre)
    {
        this.Tyre = newtyre;
    }
}

