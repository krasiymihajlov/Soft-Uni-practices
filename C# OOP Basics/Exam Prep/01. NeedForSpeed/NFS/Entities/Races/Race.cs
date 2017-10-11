using System.Collections.Generic;

public abstract class Race
{
    public int Length { get; set; }
    public string Stringroute { get; set; }
    public int PrizePool { get; set; }
    public Dictionary<int, Car> Participants { get; set; }

    public Race(int length, string stringroute, int prizePool, Dictionary<int, Car> participants)
    {
        this.Length = length;
        this.Stringroute = stringroute;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }
}

