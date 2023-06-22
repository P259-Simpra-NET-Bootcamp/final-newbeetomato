using ECommerce.Data.DbContext;

using ECommerce.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;



namespace ECommerce.Data.Repository.Cart;

public class CartRepository : GenericRepository<Domain.Cart>, ICartRepository
{
    public CartRepository(EComDbContext dbContext) : base(dbContext)
    {


    }
    public void CreateCartWithCartItem(int userId, int CartItemId)
    {
        var cartItem = dbContext.Set<Domain.CartItem>().FirstOrDefault(x => x.Id == CartItemId);
        
            var cart = new Domain.Cart
            {
                UserId = userId,
                CartItems = new List<Domain.CartItem>(),
                CartTotalAmount = 0
            };
            dbContext.Set<Domain.Cart>().Add(cart);
            dbContext.SaveChanges();
            var addcartItem = new Domain.CartItem
            {
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity

            };

    }
    public void DeleteCartWithItems(int CartId)
    {
        var ıtemEntities = dbContext.Set<Domain.CartItem>().Where(x => x.CartId == CartId).ToList();
        foreach (var entity in ıtemEntities)
        {
            dbContext.Set<Domain.CartItem>().Remove(entity);
        }
        DeleteById(CartId);
        dbContext.SaveChanges();
        
    }


    public decimal CartTotalAmount(int cartId)
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
            cart.CartTotalAmount = totalAmount;
            dbContext.SaveChanges();
        }
        return totalAmount;
    }
    public Domain.Cart GetCartWithItemsById(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.Id == cartId);

        if (cart == null)
        {
            return null;
        }

        return cart;
    }

}
