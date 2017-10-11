
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benderList;
    private List<Monument> monumentList;

    public Nation()
    {
        this.benderList = new List<Bender>();
        this.monumentList = new List<Monument>();
    }

    public double GetTotalPower()
    {
        int monumentsIncreasePercentage = this.monumentList.Sum(m => m.GetAffinity());
        double totalBendersPower = this.benderList.Sum(x => x.GetPower());
        double totalPowerIncrease = totalBendersPower / 100 * monumentsIncreasePercentage;

        return totalPowerIncrease + totalBendersPower;
    }

    public void AddBender(Bender currentBender)
    {
        this.benderList.Add(currentBender);
    }

    public void AddMonument(Monument currentMonument)
    {
        this.monumentList.Add(currentMonument);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Benders: ");
        if (this.benderList.Count > 0)
        {
            sb.AppendLine();
            foreach (var bender in this.benderList)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }
        else
        {
            sb.Append("None");
            sb.AppendLine();
        }

        sb.Append("Monuments: ");
        if (this.monumentList.Count > 0)
        {
            sb.AppendLine();
            foreach (var monument in monumentList)
            {
                sb.AppendLine($"###{monument.ToString()}");
            }
        }
        else
        {
            sb.Append("None");
        }

        return sb.ToString().Trim();
    }

    public void DeclareDefeat()
    {
        this.benderList.Clear();
        this.monumentList.Clear();
    }
}

