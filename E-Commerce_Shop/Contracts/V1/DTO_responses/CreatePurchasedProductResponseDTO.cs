using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Contracts.V1.DTO_responses
{
    public class CreatePurchasedProductResponseDTO
    {
        public int? CartItemId { get; set; }
        public DateTime? DatePurchased { get; set; }
    }
}
