using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Working working;
    private string mode;

    public DraftManager()
    {
        this.working = new Working();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        return working.GetHarvesters(arguments);
    }

    public string RegisterProvider(List<string> arguments)
    {        
        return working.GetProviders(arguments);
    }

    public string Day()
    {
        StringBuilder sb = new StringBuilder();
        double getOres = working.GetOresPerDay();
        double totalStoredEnergy = working.TotalStoredEnergyPerDay();

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {totalStoredEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {getOres}");
        

        return sb.ToString().Trim();
    }
    public string Mode(List<string> arguments)
    {         
        this.mode = arguments[0].Trim();
        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        return working.GetCheckCommand(arguments);
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {working.TotalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {working.TotalMinedOre}");
        return sb.ToString().Trim();
    }
}
