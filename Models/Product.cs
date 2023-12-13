namespace Web_API.Models
{
    public class Product
    {
        public int ProductID {  get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
       
       public List<Order> Orders = null!;
    }
}
