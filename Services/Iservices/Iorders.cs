using Web_API.Models;
using Web_API.Models.DTOS;

namespace Web_API.Services.Iservices
{
    public interface Iorders
    {
        Task<Order> GetOrdersAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync ();
        Task<string>CreateOrderAsync (Order order);
        Task<Order>? GetOneOrder(int id);
        Task<bool> UpdateOrder(int id, AddOrdersDTO order);

    }
}
