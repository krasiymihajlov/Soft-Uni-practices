using System;

public class UltrasoftTyre : Tyre
{
    private const string TyreName = "UltraSoft";
    private double grip;

    public UltrasoftTyre(double hardness)
        : base(hardness)
    {
        this.Name = TyreName;
    }

    public double Grip
    {
        get
        {
            return this.grip;
        }

        protected set
        {
            this.grip = value;
        }
    }

    //public override double Degradation
    //{
    //    get
    //    {
    //        return this.Degradation;
    //    }

    //    protected set
    //    {
    //        if (value < 30)
    //        {
    //            new ArgumentException("Blown tyre");
    //        }

    //        this.Degradation = value;
    //    }
    //}
}
