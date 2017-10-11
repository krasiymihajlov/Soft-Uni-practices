public class Barbarian : AbstractHero
{
    private const long StartStrength = 90;
    private const long StartAgility = 25;
    private const long StartIntelligence = 10;
    private const long StartHitPoints = 350;
    private const long StartDamage = 150;

    public Barbarian(string name)
        : base(name, StartStrength, StartAgility, StartIntelligence, StartHitPoints, StartDamage)
    {
    }
}

