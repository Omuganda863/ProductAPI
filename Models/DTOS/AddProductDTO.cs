namespace Web_API.Models.DTOS
{
    public class AddProductDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}
