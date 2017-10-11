
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = this.EnergyRequirement * 2;
        this.OreOutput = this.OreOutput + (this.OreOutput * 2);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Successfully registered Hammer {base.ToString()}");
        return sb.ToString().Trim();
    }

    public override string GetTypeOfClass()
    {
        string sonicType = this.GetType().Name;
        int index = sonicType.IndexOf("Harvester");
        sonicType = sonicType.Substring(0, index);
        return $"{sonicType}";
    }
}

