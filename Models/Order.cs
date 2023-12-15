namespace Web_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product? Products { get; set; }

    }
}
