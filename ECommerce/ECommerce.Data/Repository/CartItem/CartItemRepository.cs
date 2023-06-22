using ECommerce.Data.DbContext;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.CartItem;

public class CartItemRepository : GenericRepository<Domain.CartItem>, ICartItemRepository
{
    public CartItemRepository(EComDbContext dbContext) : base(dbContext)
    {
    }

    
    public Domain.Cart AddCartItemToCart(int cartId, int productId, int quantity)
    {
        var cart = dbContext.Set<Domain.Cart>().Find(cartId);

        if (cart != null)
        {
            var cartItem = new Domain.CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            dbContext.Set<Domain.CartItem>().Add(cartItem);

            dbContext.SaveChanges();
        }
        return cart;
    }

    public Domain.CartItem IncreaseOneCartItemQuantity(int cartItemId)
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity += 1;
            dbContext.SaveChanges();
        }
        return cartItem;
    }

    public Domain.CartItem DecreaseOneCartItemQuantity(int cartItemId)//düzelt sıfırsa silmek lazım 
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity -= 1;

            if (cartItem.Quantity < 1)
            {
                dbContext.Remove(cartItem);
            }
            dbContext.SaveChanges();
        }
        cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);
        return cartItem;

    }
    public Domain.CartItem UpdateCartItemQuantity(int cartItemId, int newQuantity)//düzelt 0 ve negatif sayı için 
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null && newQuantity > 0)
        {
            cartItem.Quantity = newQuantity;
            dbContext.SaveChanges();
            return cartItem;
        }
        return null;
    }

}