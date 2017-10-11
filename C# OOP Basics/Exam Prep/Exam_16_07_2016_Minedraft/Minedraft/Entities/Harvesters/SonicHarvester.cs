using System;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = this.EnergyRequirement / sonicFactor;
        this.sonicFactor = sonicFactor;
    }

    public override string GetTypeOfClass()
    {
        string sonicType = this.GetType().Name;
        int index = sonicType.IndexOf("Harvester");
        sonicType = sonicType.Substring(0, index);
        return $"{sonicType}";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Successfully registered Sonic {base.ToString()}");
        return sb.ToString().Trim();
    }
}

