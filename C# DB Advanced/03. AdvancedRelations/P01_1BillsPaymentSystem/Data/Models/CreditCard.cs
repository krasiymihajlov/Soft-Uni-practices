namespace P01_1BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; private set; }
        public decimal LimitLeft { get { return Limit - MoneyOwed; } }
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"Deposit cannot be negative value!");
            }

            this.MoneyOwed -= amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.LimitLeft)
            {
                throw new ArgumentException($"Insufficient funds!");
            }

            this.MoneyOwed += amount;
        }
    }
}
