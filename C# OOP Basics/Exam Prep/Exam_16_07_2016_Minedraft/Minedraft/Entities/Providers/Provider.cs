using System;
using System.Text;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException($"{nameof(EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public abstract string GetTypeOfClass();

    public virtual string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Provider - {this.id}");
        return sb.ToString().Trim();
    }
}

