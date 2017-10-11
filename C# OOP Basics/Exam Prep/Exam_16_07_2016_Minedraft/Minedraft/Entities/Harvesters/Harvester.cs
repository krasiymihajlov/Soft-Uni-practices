using System;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public abstract string GetTypeOfClass();

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value > 160)
            {
                value = 160;
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"{nameof(EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public virtual string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Harvester - {this.id}");
        return sb.ToString();
    }
}

