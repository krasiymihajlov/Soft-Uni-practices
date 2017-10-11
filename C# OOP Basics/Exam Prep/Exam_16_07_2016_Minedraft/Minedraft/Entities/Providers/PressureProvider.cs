
using System;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput = this.EnergyOutput + (( this.EnergyOutput * 50) / 100);
    }

    public override string GetTypeOfClass()
    {
        string sonicType = this.GetType().Name;
        int index = sonicType.IndexOf("Provider");
        sonicType = sonicType.Substring(0, index);
        return $"{sonicType}";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Successfully registered Pressure {base.ToString()}");
        return sb.ToString().Trim();
    }
    
}

