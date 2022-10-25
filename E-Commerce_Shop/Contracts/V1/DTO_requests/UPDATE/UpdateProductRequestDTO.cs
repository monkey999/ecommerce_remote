namespace E_Commerce_Shop.Contracts.V1.DTO_requests.UPDATE
{
    public class UpdateProductRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int AvailableItems { get; set; }
    }
}
