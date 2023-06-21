using ECommerce.Data.DbContext;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;

namespace ECommerce.Data.Repository.Order;

public class OrderRepository : GenericRepository<Domain.Order>, IOrderRepository
{
    public OrderRepository(EComDbContext context) : base(context)
    {
    }


    public void CreateOrder(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>().Find(cartId);

        if (cart != null)
        {

            // Yeni bir Order oluştur
            var order = new Domain.Order
            {
                UserId = cart.UserId,
                TotalAmount = CalculateTotalAmount(cart),
                // Diğer Order özelliklerini ayarlayın
            };

            // Order'ı veritabanına ekle
            dbContext.Set<Order>().Add(order);

            // CartItem'ları OrderItem olarak dönüştür ve veritabanına ekle
            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price,
                    // Diğer OrderItem özelliklerini ayarlayın
                };

                dbContext.Set<OrderItem>().Add(orderItem);
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

