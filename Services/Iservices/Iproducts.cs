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
    }
}
