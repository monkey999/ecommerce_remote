using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.DTO
{
    public class CreateOrderDTO
    {
        public int? CartItemId { get; set; }
        public int? UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool? GiftWrap { get; set; }
        public bool? Dispatched { get; set; }
    }
}
