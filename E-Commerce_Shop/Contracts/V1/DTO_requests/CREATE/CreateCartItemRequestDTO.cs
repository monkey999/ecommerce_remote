using System;

namespace E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE
{
    public class CreateCartItemRequestDTO
    {
        public string CartId { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? BoughtStatus { get; set; }
    }
}
