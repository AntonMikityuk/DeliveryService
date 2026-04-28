using DeliveryService.DTOs;
using DeliveryService.Models;

namespace DeliveryService.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
        Task<Order?> CreateOrderAsync(OrderCreateDTO orderDTO);
        Task<bool> DeleteOrderAsync (Guid id);
        Task<Order?> UpdateOrderAsync (Guid id, OrderUpdateDTO updateDTO);
    }
}
