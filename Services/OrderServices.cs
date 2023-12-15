using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models;
using Web_API.Models.DTOS;
using Web_API.Services.Iservices;

namespace Web_API.Services
{
    public class OrderServices : Iorders
    {
        private readonly Context context;
        public OrderServices(Context context)
        {
            this.context = context;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                await context.AddAsync(order);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = await context.Orders.ToListAsync();
            return orders;
        }

        public Task<Order>? GetOneOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrdersAsync(int orderId)
        {
            var ord = await context.Orders.Where(i => i.Id == orderId).FirstOrDefaultAsync();
            return ord;
        }

        public async Task<bool> UpdateOrder(int id, AddOrdersDTO order)
        {
            try
            {
                var upgrade = await context.Orders.Where(order => order.Id == id).FirstOrDefaultAsync();
                if (upgrade != null)
                {
                    upgrade.ProductID = order.ProductID;
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

        Task<string> Iorders.CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
