using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) {}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
       
    }
}
