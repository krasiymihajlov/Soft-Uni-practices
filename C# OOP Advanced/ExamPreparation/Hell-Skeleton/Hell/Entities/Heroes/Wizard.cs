public class Wizard : AbstractHero
{
    private const long StartStrength = 25;
    private const long StartAgility = 25;
    private const long StartIntelligence = 100;
    private const long StartHitPoints = 100;
    private const long StartDamage = 250;

    public Wizard(string name)
        : base(name, StartStrength, StartAgility, StartIntelligence, StartHitPoints, StartDamage)
    {
    }
}

