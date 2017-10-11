using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            { "Air", new Nation()},
            { "Fire", new Nation() },
            { "Water", new Nation() },
            { "Earth", new Nation() }
        };

        this.warHistoryRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[1];
        Bender currentBender = this.GetBender(benderArgs);
        this.nations[type].AddBender(currentBender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[1];
        Monument currentMonument = this.GetMonument(monumentArgs);
        this.nations[type].AddMonument(currentMonument);
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");
        sb.Append(this.nations[nationsType].ToString());

        return sb.ToString();
    }

    public void IssueWar(string nationsType)
    {
        double victoriousPower = this.nations.Max(kvp => kvp.Value.GetTotalPower());

        foreach (var nation in this.nations)
        {
            if (nation.Value.GetTotalPower() != victoriousPower)
            {
                nation.Value.DeclareDefeat();
            }
        }

        this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, warHistoryRecord);
    }

    private Bender GetBender(List<string> benderArgs)
    {
        string type = benderArgs[1];
        string name = benderArgs[2];
        int power = int.Parse(benderArgs[3]);
        double parameter = double.Parse(benderArgs[4]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, parameter);
            case "Fire":
                return new FireBender(name, power, parameter);
            case "Earth":
                return new EarthBender(name, power, parameter);
            case "Water":
                return new WaterBender(name, power, parameter);
            default:
                throw new ArgumentException();
        }
    }

    private Monument GetMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[1];
        string name = monumentArgs[2];
        int affinity = int.Parse(monumentArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            default:
                throw new ArgumentException();
        }
    }

}

