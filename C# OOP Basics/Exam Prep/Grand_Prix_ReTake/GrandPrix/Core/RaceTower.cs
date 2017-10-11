
using System.Collections.Generic;

public class RaceTower
{
    private Dictionary<string, Driver> driver;
    public RaceTower()
    {
        this.driver = new Dictionary<string, Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        //TODO: Add some logic here …
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string driverName = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        if (commandArgs.Count == 6)
        {
            Tyre tyre = new HardTyre(tyreHardness);
            Car car = new Car(hp, fuelAmount, tyre);
            //AggressiveDriver aggressiveDriver = new AggressiveDriver();
        }
        else
        {
                
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        return "";
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string GetLeaderboard()
    {
        //TODO: Add some logic here …
        return "";
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

}

