namespace P01_1BillsPaymentSystem.Interfaces
{
    public interface IIPayBills
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
