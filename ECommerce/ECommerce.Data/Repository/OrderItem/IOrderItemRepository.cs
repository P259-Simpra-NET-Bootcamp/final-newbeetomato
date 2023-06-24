using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.OrderItem;

public interface IOrderItemRepository:IGenericRepository<Domain.OrderItem>
{
    Domain.OrderItem CanceledOrderItem(int orderId, int orderItemId);

}
