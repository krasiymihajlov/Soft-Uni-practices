namespace _04.Recharge
{
    using _04.Recharge.Interfaces;

    public class RechargeStation
    {
        public void Recharge(IRechargeable rechargeable)
        {
            rechargeable.Recharge();
        }
    }
}