using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Contracts.V1.DTO_requests
{
    public class UpdateCartitemRequestDTO
    {
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool BoughtStatus { get; set; }
    }
}
