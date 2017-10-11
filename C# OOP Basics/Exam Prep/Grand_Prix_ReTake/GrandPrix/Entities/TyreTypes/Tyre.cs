using System;

public abstract class Tyre
{
    private const int StartPointDegradation = 100;
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = StartPointDegradation;
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

    public double Hardness
    {
        get
        {
            return this.hardness;
        }

        protected set
        {
            this.hardness = value;
        }
    }

    public double Degradation
    {
        get
        {
            return this.degradation;
        }

        protected set
        {
            if (value < 0)
            {
                new ArgumentException("Blown tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradationOnLab()
    {
        this.Degradation -= this.Hardness;
    }
}

