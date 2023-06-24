using ECommerce.Base.Response;
using ECommerce.Operation.OrderItemSrvc;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/orderitems")]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemService orderItemService;

        public OrderItemController(OrderItemService orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        [HttpDelete("{orderId}/{orderItemId}")]
        public ActionResult<ApiResponse> CancelOrderItem(int orderId, int orderItemId)
        {
            try
            {
                var response = orderItemService.CancelOrderItem(orderId, orderItemId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while canceling order item");
                return StatusCode(500, "An error occurred while canceling order item");
            }
        }

    }
}
