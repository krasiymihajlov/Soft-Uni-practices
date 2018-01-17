﻿namespace P01_1BillsPaymentSystem.Data.Models
{
    using P01_1BillsPaymentSystem.Data.Enum;

    public class PaymentMethod
    {
        public int Id { get; set; }
        public PaymentMethodType Type { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
