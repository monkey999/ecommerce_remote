using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class PurchasedProduct
    {
        public int Id { get; set; }
        public int? CartItemId { get; set; }
        public DateTime? DatePurchased { get; set; }

        public virtual CartItem CartItem { get; set; }
    }
}
