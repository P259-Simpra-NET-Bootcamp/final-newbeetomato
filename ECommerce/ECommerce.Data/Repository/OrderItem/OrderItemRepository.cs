using AutoMapper;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using ECommerce.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
    public Domain.OrderItem CanceledOrderItem(int orderId, int orderItemId)
    {
        var orderEntity = dbContext.Set<Domain.Order>()
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.Id == orderId);

        var orderItem = orderEntity.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);

        if (orderItem != null)
        {
            orderItem.IsCanceled = true;
        }
        return orderItem;
    }

}
