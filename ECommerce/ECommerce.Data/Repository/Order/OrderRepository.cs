using ECommerce.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Repository.Base;

namespace ECommerce.Data.Repository.Order;

public class OrderRepository : GenericRepository<Domain.Order>, IOrderRepository
{
    public OrderRepository(EComDbContext context) : base(context)
    {
    }


    public void CreateOrder(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.Id == cartId);

        if (cart != null)
        {
            var order = new Domain.Order
            {
                UserId = cart.UserId,
                OrderItems = new List<Domain.OrderItem>(),
                TotalAmount = cart.CartTotalAmount
            };

            dbContext.Set<Domain.Order>().Add(order);
            dbContext.SaveChanges();

            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new Domain.OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                };

                order.OrderItems.Add(orderItem);
            }

            dbContext.Set<Domain.Order>().Add(order);
            dbContext.SaveChanges();
        }
    }
    public List<Domain.Order> GetByDateBetween(DateTime startDate, DateTime endDate)
    {
        return dbContext.Set<Domain.Order>().Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate).ToList();
    }
    public List<Domain.Order> GetByUserIdAndDateBetween(int userId, DateTime startDate, DateTime endDate)
    {
        return dbContext.Set<Domain.Order>()
            .Where(x => x.UserId == userId && x.CreatedAt >= startDate && x.CreatedAt <= endDate)
            .ToList();
    }

}

