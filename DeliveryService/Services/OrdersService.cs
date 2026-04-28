using Microsoft.EntityFrameworkCore;
using DeliveryService.Services.Interfaces;
using DeliveryService.Data;
using DeliveryService.Models;
using DeliveryService.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DeliveryService.Services
{
    public class OrdersService: IOrderService
    {
        private readonly AppDbContext _context;
        public OrdersService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.PickupDate)
                .ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }
        public async Task<Order?> CreateOrderAsync(OrderCreateDTO orderDTO)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                SenderCity = orderDTO.SenderCity,
                SenderAddress = orderDTO.SenderAddress,
                ReceiverCity = orderDTO.ReceiverCity,
                ReceiverAddress = orderDTO.ReceiverAddress,
                Weight = orderDTO.Weight,
                PickupDate = orderDTO.PickupDate
            };
            
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            order.OrderNumber = $"ORD-{datePart}-{randomPart}";

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Order?> UpdateOrderAsync(Guid id, OrderUpdateDTO updateDTO)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            order.SenderCity = updateDTO.SenderCity;
            order.SenderAddress = updateDTO.SenderAddress;
            order.ReceiverCity = updateDTO.ReceiverCity;
            order.ReceiverAddress = updateDTO.ReceiverAddress;
            order.Weight = updateDTO.Weight;
            order.PickupDate = updateDTO.PickupDate;

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
