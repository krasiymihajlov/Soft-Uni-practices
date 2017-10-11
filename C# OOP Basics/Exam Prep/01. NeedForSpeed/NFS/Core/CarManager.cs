using System.Collections.Generic;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> racesClosed;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.racesClosed = new List<int>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction,
        int horsepower, int acceleration, int suspension, int durability)
    {

    }

    public string Check(int id)
    {
        return "";
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {

    }
    public void Participate(int carId, int raceId)
    {

    }
    public string Start(int id)
    {
        return "";
    }

    public void Park(int id)
    {

    }

    public void Unpark(int id)
    {

    }
    public void Tune(int tuneIndex, string addOn)
    {

    }

}


