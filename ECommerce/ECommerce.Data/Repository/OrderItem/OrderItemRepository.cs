using ECommerce.Data.DbContext;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.OrderItem;

public class OrderItemRepository : GenericRepository<Domain.OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(EComDbContext dbContext) : base(dbContext)
    {
    }

}
