using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryService.Data;
using DeliveryService.Models;
using DeliveryService.Services.Interfaces;
using DeliveryService.DTOs;
using SQLitePCL;

namespace DeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder (Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound("Заказ не найден");
            }

            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderCreateDTO orderDTO)
        {
            var createdOrder = await _orderService.CreateOrderAsync(orderDTO);

            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder!.Id }, createdOrder);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var deleted = await _orderService.DeleteOrderAsync(id);
            if (!deleted)
            {
                return NotFound("Заказ не найден");
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(Guid id, OrderUpdateDTO updateDTO)
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(id, updateDTO);
            if (updatedOrder == null)
            {
                return NotFound("Заказ не найден");
            }
            return Ok(updatedOrder);
        }
    }
}
