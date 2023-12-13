using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models;
using Web_API.Services.Iservices;

namespace Web_API.Services
{
    public class ProductServices : Iproducts
    {
        private readonly Context context;
        public ProductServices(Context context)
        {
            this.context = context;
            
        }
        public async Task<string> AddProductAsync(Product product)
        {
           await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return "Producted Created";
        }

        public async Task<string> DeleteProductAsync(int productId)
        {
            var result = await context.Products.FindAsync(productId);
            if (result != null)
            {
                context.Products.Remove(result);
                await context.SaveChangesAsync();
                return "Deleted Successfully";
            }
            return "Not deleted";
            

        }

        public async Task<List<Product>> GetllProductsAsync()
        {
           var  products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var product= await context.Products.Where(p=>p.ProductID == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<string> UpdateProductAsync()
        {
            await context.SaveChangesAsync();
            return "Product Saved Successfully";

        }
    }
}
