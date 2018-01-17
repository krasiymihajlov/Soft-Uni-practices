﻿namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Store
    {
        public int StoreId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
