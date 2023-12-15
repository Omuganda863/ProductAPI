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

        public async Task<List<Product>> GetProductsByNameAndPriceAsync(string productName, decimal price)
        {
            var products = await context.Products
            .Where(p => p.ProductName.Contains(productName) && p.Price == price)
            .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            var products = await context.Products
              .Where(p => p.ProductName.Contains(productName))
              .ToListAsync();

            return products;
        }

        //public async Task<List<Order>> GetUserOrdersAsync(int userId)
        //{
        //    var userOrders = await context.Orders
        //    .Where(o => o.Id == userId)
        //    .Include(o => o.Products)
        //        .ThenInclude(op => op.Orders)
        //    .ToListAsync();

        //    return userOrders;
        //}

        public async Task<string> UpdateProductAsync()
        {
            await context.SaveChangesAsync();
            return "Product Saved Successfully";

        }
       

    }
}
