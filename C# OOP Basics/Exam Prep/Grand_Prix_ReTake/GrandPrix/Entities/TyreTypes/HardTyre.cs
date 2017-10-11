public class HardTyre : Tyre
{
    private const string TyreName = "Hard";

    public HardTyre(double hardness) 
        : base(hardness)
    {
        this.Name = TyreName;
    }
}