using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.HP = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int HP
    {
        get
        {
            return this.hp;
        }

        protected set
        {
            this.hp = value;
        }
    }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            if (value > 160)
            {
                value = 160;
            }

            this.fuelAmount = value;
        }
    }

    public Tyre Tyre
    {
        get
        {
            return this.tyre;
        }

        protected set { this.tyre = value; }
    }
}

