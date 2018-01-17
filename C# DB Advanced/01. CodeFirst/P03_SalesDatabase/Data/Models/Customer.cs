﻿namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string CreditCardNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
