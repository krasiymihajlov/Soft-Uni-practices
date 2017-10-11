
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Working
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private double summedOreOutput;
    private double summedEnergyOutput;

    public Working()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();

        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.summedOreOutput = 0;
    }

    public double TotalStoredEnergy
    {
        get { return this.totalStoredEnergy; }
    }

    public double TotalMinedOre
    {
        get { return this.totalMinedOre; }
    }

    public double SummedOreOutput { get => summedOreOutput; set => summedOreOutput = value; }

    public string GetCheckCommand(List<string> arguments)
    {
        string id = arguments[0];
        StringBuilder sb = new StringBuilder();

        if (this.harvesters.ContainsKey(id))
        {
            sb.AppendLine($"{this.harvesters[id].GetTypeOfClass()} Harvester - {id}");
            sb.AppendLine($"Ore Output: {this.harvesters[id].OreOutput}");
            sb.AppendLine($"Energy Requirement: {this.harvesters[id].EnergyRequirement}");
            return sb.ToString().Trim();
        }
        else if(this.providers.ContainsKey(id))
        {
            sb.AppendLine($"{this.providers[id].GetTypeOfClass()} Provider - {id}");
            sb.AppendLine($"Energy Output: {this.providers[id].EnergyOutput}");
            return sb.ToString().Trim();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string GetHarvesters(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        Harvester harvester = GetHarvester(arguments);
        harvesters[id] = harvester;
        return harvester.ToString();
    }

    public string GetProviders(List<string> arguments)
    {
        string id = arguments[1];

        Provider provider = GetProvider(arguments);
        providers[id] = provider;
        return provider.ToString();
    }

    private Provider GetProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if (type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else
        {
            return new PressureProvider(id, energyOutput);
        }
    }

    private Harvester GetHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
    }

    public double GetOresPerDay()
    {
        double needEnergy = this.NeededEnergy();
        this.totalStoredEnergy += this.TotalStoredEnergyPerDay();
        this.summedOreOutput = 0;

        while (this.totalStoredEnergy >= needEnergy)
        {
            this.totalStoredEnergy -= needEnergy;
            this.summedOreOutput += this.harvesters.Values.Sum(h => h.OreOutput);
        }

        this.totalMinedOre += this.summedOreOutput;
        return this.summedOreOutput;
    }
    public double TotalStoredEnergyPerDay()
    {
        double energyPerDay = 0;
        foreach (var item in this.providers.Values)
        {
            energyPerDay += item.EnergyOutput;
        }

        return energyPerDay;
    }

    private double NeededEnergy()
    {
        double needEnergy = 0;
        foreach (var item in this.harvesters.Values)
        {
            needEnergy += item.EnergyRequirement;
        }

        return needEnergy;
    }
}

