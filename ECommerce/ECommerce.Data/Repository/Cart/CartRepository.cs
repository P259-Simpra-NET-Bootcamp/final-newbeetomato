using ECommerce.Data.DbContext;
using ECommerce.Data.Repository.Base;

using Microsoft.EntityFrameworkCore;



namespace ECommerce.Data.Repository.Cart;

public class CartRepository : GenericRepository<Domain.Cart>, ICartRepository
{
    public CartRepository(EComDbContext dbContext) : base(dbContext)
    {


    }

    public decimal CalculateTotalAmount(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.Id == cartId);
        decimal totalAmount = 0;

        if (cart != null)
        {
            foreach (var cartItem in cart.CartItems)
            {
                decimal itemPrice = dbContext.Set<Domain.Product>()
                    .Where(p => p.Id == cartItem.ProductId)
                    .Select(p => p.UnitPrice)
                    .FirstOrDefault();

                totalAmount += itemPrice * cartItem.Quantity;
            }
        }

        return totalAmount;
    }

}
