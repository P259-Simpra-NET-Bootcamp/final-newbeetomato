using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Coupon;
using ECommerce.Schema.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.OrderItemSrvc;

public interface IOrderItemService: IBaseService<OrderItemService, OrderItemRequest, OrderItemResponse>
{
    ApiResponse CancelOrderItem(int orderId, int orderItemId);
}
