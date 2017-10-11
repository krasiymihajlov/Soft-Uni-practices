public class Assassin : AbstractHero
{
    private const long StartStrength = 25;
    private const long StartAgility = 100;
    private const long StartIntelligence = 15;
    private const long StartHitPoints = 150;
    private const long StartDamage = 300;

    public Assassin(string name) 
        : base(name, StartStrength, StartAgility, StartIntelligence, StartHitPoints, StartDamage)
    {
    }
}

