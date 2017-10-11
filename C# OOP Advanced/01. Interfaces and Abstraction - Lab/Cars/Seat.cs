using System;
using System.Text;

public class Seat : ICar
{
    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model { get; set; }

    public string Color { get; set; }

    public string Start { get { return "Engine start"; } }

    public string Stop { get { return "Breaaak!"; } }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Color + " ").Append("Seat ").AppendLine(this.Model);
        sb.AppendLine(this.Start);
        sb.AppendLine(this.Stop);
        return sb.ToString().Trim();       
    }
}

