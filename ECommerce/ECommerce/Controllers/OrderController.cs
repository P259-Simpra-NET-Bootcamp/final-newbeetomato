using ECommerce.Base.Response;
using ECommerce.Operation.OrderSrvc;
using ECommerce.Schema.Order;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public ApiResponse CreateOrder(int cartId)
        {
            return orderService.CreateOrder(cartId);
        }

        [HttpPut("{orderId}/cancel")]
        public ApiResponse CancelOrder(int orderId)
        {
            return orderService.CancelOrder(orderId);
        }

        [HttpGet("date-between")]
        public ApiResponse<OrderResponse> GetByDateBetween(DateTime startDate, DateTime endDate)
        {
            return orderService.GetByDateBetween(startDate, endDate);
        }

        [HttpGet("user/{userId}/date-between")]
        public ApiResponse<OrderResponse> GetByUserIdAndDateBetween(int userId, DateTime startDate, DateTime endDate)
        {
            return orderService.GetByUserIdAndDateBetween(userId, startDate, endDate);
        }
    }
}
