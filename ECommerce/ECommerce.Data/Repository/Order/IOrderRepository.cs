using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Order;

public interface IOrderRepository:IGenericRepository<Domain.Order>
{
    void GainPoints(int cartId);
    Domain.Cart CreateOrder(int cartId);
    void FillOrder(int cartId);
    Domain.Order OrderAfterCancelledItems(int orderId);
    Domain.Order CancelOrder(int orderId);
    List<Domain.Order> GetByDateBetween(DateTime startDate, DateTime endDate);
    List<Domain.Order> GetByUserIdAndDateBetween(int userId, DateTime startDate, DateTime endDate);
}
