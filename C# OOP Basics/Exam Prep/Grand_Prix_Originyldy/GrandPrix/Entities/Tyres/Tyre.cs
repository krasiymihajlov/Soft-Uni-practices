using System;

public abstract class Tyre
{
    private const double StartDegradation = 100;

    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = StartDegradation;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        private set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

