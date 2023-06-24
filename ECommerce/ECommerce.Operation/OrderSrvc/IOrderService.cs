using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Cart;
using ECommerce.Schema.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.OrderSrvc
{
    public interface IOrderService : IBaseService<Order, OrderRequest, OrderResponse>
    {
        ApiResponse<OrderResponse> GetByUserIdAndDateBetween(int userId, DateTime startDate, DateTime endDate);
        ApiResponse<OrderResponse> GetByDateBetween(DateTime startDate, DateTime endDate);
        ApiResponse CancelOrder(int orderId);
        ApiResponse UpdateOrderForCancelledItems(int orderId);
        ApiResponse CreateOrder(int cartId);
    }
}
