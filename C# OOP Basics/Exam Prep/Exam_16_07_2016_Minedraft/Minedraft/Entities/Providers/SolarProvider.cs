
using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Successfully registered Solar {base.ToString()}");
        return sb.ToString().Trim();
    }

    public override string GetTypeOfClass()
    {
        string sonicType = this.GetType().Name;
        int index = sonicType.IndexOf("Provider");
        sonicType = sonicType.Substring(0, index);
        return $"{sonicType}";
    }
}

