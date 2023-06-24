using ECommerce.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.OrderItemSrvc;

public interface IOrderItemService
{
    ApiResponse CancelOrderItem(int orderId, int orderItemId);
}
