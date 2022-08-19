using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class CartItem
    {
        public CartItem()
        {
            Orders = new HashSet<Order>();
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }

        public int Id { get; set; }
        public string CartId { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? BoughtStatus { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
