using ECommerce.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Domain;

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
            .Include(c=>c.Coupons)
            .FirstOrDefault(c => c.Id == cartId);
        
        if (cart != null)
        {
            var order = new Domain.Order
            {
                UserId = cart.UserId,
                cardNo=cart.Id,
                OrderItems = new List<Domain.OrderItem>(),
                TotalAmount = cart.CartTotalAmount,
                UsedPoints = cart.UsedPoints,
                CouponPoints =cart.CouponPoints,
                TotalDiscount =cart.TotalDiscount,
                NetAmount =cart.NetAmount,
                Coupons = new List<Domain.Coupon>()
            };

            dbContext.Set<Domain.Order>().Add(order);
            dbContext.SaveChanges();

            var orderLast = dbContext.Set<Domain.Order>().Include(c => c.OrderItems)
            .Include(c => c.Coupons)
            .FirstOrDefault(c => c.cardNo == cartId);
            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new Domain.OrderItem
                {
                    OrderId = orderLast.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                };

                orderLast.OrderItems.Add(orderItem);
            }

            foreach (var coupon in cart.Coupons)
            {
                orderLast.Coupons.Add(coupon);

            }   
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

