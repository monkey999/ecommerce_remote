using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.DTO
{
    public class CreatePurchasedProductDTO
    {
        public int? CartItemId { get; set; }
        public DateTime? DatePurchased { get; set; }
    }
}
