namespace P01_1BillsPaymentSystem.Data.Models
{
    using P01_1BillsPaymentSystem.Interfaces;
    using System;

    public class BankAccount : IIPayBills
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; private set; }
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"Deposit cannot be negative!");
            }

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0 || amount > this.Balance)
            {
                throw new ArgumentException($"Insufficient funds!");
            }
            else
            {
                this.Balance -= amount;
            }
        }
    }
}
