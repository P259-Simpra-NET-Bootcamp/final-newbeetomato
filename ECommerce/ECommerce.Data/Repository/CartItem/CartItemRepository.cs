using ECommerce.Data.Context;
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
        }
        return cart;
    }

    public Domain.CartItem IncreaseOneCartItemQuantity(int cartItemId)
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity += 1;
        }
        return cartItem;
    }

    public Domain.CartItem DecreaseOneCartItemQuantity(int cartItemId) 
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity -= 1;

            if (cartItem.Quantity < 1)
            {
                dbContext.Remove(cartItem);
            }
        }
        cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);
        return cartItem;

    }
    public Domain.CartItem UpdateCartItemQuantity(int cartItemId, int newQuantity)
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null && newQuantity > 0)
        {
            cartItem.Quantity = newQuantity;
            return cartItem;
        }
        return null;
    }

}