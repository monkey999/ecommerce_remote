using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public int? AvailableItems { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
