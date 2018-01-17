﻿namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}