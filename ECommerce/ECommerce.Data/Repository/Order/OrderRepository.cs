using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Domain;
using StackExchange.Redis;

namespace ECommerce.Data.Repository.Order;

public class OrderRepository : GenericRepository<Domain.Order>, IOrderRepository
{
    public OrderRepository(EComDbContext context) : base(context)
    {
    }


    public Domain.Cart CreateOrder(int cartId)
    {

       
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .Include(c => c.Coupons)
            .FirstOrDefault(c => c.Id == cartId);
        

        if (cart != null)
        {
            var order = new Domain.Order
            {
                UserId = cart.UserId,
                CardNo = cart.Id,
                OrderItems = new List<Domain.OrderItem>(),
                TotalAmount = cart.CartTotalAmount,
                UsedPoints = cart.UsedPoints,
                CouponPoints = cart.CouponPoints,
                TotalDiscount = cart.TotalDiscount,
                NetAmount = cart.NetAmount,
                Coupons = new List<Domain.Coupon>()
            };

            dbContext.Set<Domain.Order>().Add(order);

        }
        return cart;
    }



    public void FillOrder(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
           .Include(c => c.CartItems)
           .Include(c => c.Coupons)
           .FirstOrDefault(c => c.Id == cartId);

        var orderLast = dbContext.Set<Domain.Order>().Include(c => c.OrderItems)
            .Include(c => c.Coupons)
            .FirstOrDefault(c => c.CardNo == cartId);
        foreach (var cartItem in cart.CartItems)
        {
            var orderItem = new Domain.OrderItem
            {
                OrderId = orderLast.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                IsCanceled = false,
            };

            orderLast.OrderItems.Add(orderItem);
        }

        foreach (var coupon in cart.Coupons)
        {
            coupon.IsUsed = true;
            orderLast.Coupons.Add(coupon);

        }
    }
    public void GainPoints(int cartId) 
    {
        
        var order = dbContext.Set<Domain.Order>()
            .FirstOrDefault(c => c.CardNo == cartId);
        var cart = dbContext.Set<Domain.Cart>()
           .FirstOrDefault(c => c.Id == cartId);
        var user = dbContext.Set<Domain.User>()
           .FirstOrDefault(c => c.Id == cart.UserId);

        user.PointBalance = user.PointBalance + order.NetAmount / 100;


    }

    public Domain.Order OrderAfterCancelledItems(int orderId)
    {
        var orderEntitiy = dbContext.Set<Domain.Order>()
        .Include(o => o.OrderItems)
        .FirstOrDefault(o => o.Id == orderId);

        if (orderEntitiy == null)
        { return orderEntitiy; }

        decimal TotalAmountBefore = 0;
        decimal TotalAmountLast = 0;
        var productEntity = new Domain.Product();
        decimal unitPrice = 0;
        decimal canceledItemsPrice = 0;
        decimal? usedPoints = 0;
        decimal? couponPoints = 0;
        decimal? pointToReturn = 0;
        var userEntity = dbContext.Set<Domain.User>()
        .FirstOrDefault(o => o.Id == orderEntitiy.UserId);


        couponPoints = orderEntitiy.CouponPoints;
        usedPoints = orderEntitiy.UsedPoints;
        foreach (var orderItem in orderEntitiy.OrderItems)
        {
            if (orderItem.IsCanceled)
            {
                productEntity = dbContext.Set<Domain.Product>().FirstOrDefault(x => x.Id == orderItem.ProductId);
                unitPrice = productEntity.UnitPrice;
                canceledItemsPrice += unitPrice * orderItem.Quantity;
            }
        }

        orderEntitiy.TotalAmount = orderEntitiy.TotalAmount - canceledItemsPrice;
        orderEntitiy.NetAmount = orderEntitiy.TotalAmount - orderEntitiy.TotalDiscount;

        if (orderEntitiy.TotalDiscount > orderEntitiy.TotalAmount)
        {//ürün iadesi ile varsa toplam harcamadan fazla puan kullanılmışsa fazlalık punlar geri iade ediliyor

            pointToReturn = orderEntitiy.TotalDiscount - orderEntitiy.TotalAmount;

            orderEntitiy.TotalDiscount = orderEntitiy.TotalAmount;
            orderEntitiy.NetAmount = 0;
        }

        userEntity.PointBalance = userEntity.PointBalance + pointToReturn;
        return orderEntitiy;
    }
    public Domain.Order CancelOrder(int orderId)
    {
        var orderEntitiy = dbContext.Set<Domain.Order>().Include(o => o.Coupons).FirstOrDefault(o => o.Id == orderId);
        orderEntitiy.IsCanceled = true;
        var pointsToReturn = orderEntitiy.UsedPoints;

        if (orderEntitiy != null)
        {

            var userEntity = dbContext.Set<Domain.User>().FirstOrDefault(o => o.Id == orderEntitiy.UserId);
            userEntity.PointBalance = userEntity.PointBalance + pointsToReturn;

            if (orderEntitiy.Coupons != null)
            {
                foreach (var coupon in orderEntitiy.Coupons)
                {
                    coupon.IsUsed = false;
                }
            }
        }
        return orderEntitiy;

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

