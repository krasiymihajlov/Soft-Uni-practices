using System.Text;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }
    public string Model { get; set; }

    public string Color { get; set; }

    public string Start { get { return "Engine start"; } }

    public string Stop { get { return "Breaaak!"; } }

    public int Battery { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Color + " ").Append("Tesla ").Append(this.Model + " ").Append(this.Battery + " ").AppendLine("Batteries");
        sb.AppendLine(this.Start);
        sb.AppendLine(this.Stop);
        return sb.ToString().Trim();
    }
}

