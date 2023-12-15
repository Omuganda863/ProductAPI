using Web_API.Models;

namespace Web_API.Services.Iservices
{
    public interface Iproducts
    {
        Task <Product> GetProductAsync (int productId);
        Task<string> AddProductAsync (Product product);
        Task<string> UpdateProductAsync ();
        Task<string> DeleteProductAsync (int productId);
        Task<List<Product>> GetllProductsAsync ();
        //Task<List<Product>> GetProductsByNameAsync(string productName);
        //Task<List<Product>> GetProductsByNameAndPriceAsync(string productName, decimal price);
        //Task<List<Order>> GetUserOrdersAsync(int userId);




    }
}
