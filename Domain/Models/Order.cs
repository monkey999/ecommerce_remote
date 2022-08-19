using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CartItemId { get; set; }
        public int? UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool? GiftWrap { get; set; }
        public bool? Dispatched { get; set; }

        public virtual CartItem CartItem { get; set; }
        public virtual User User { get; set; }
    }
}
