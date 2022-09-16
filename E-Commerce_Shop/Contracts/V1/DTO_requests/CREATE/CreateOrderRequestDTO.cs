namespace E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE
{
    public class CreateOrderRequestDTO
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
    }
}
