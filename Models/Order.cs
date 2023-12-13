namespace Web_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? ProductID { get; set; }
        public Product? Products { get; set; }

    }
}
