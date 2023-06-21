using ECommerce.Data.DbContext;
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
    public void AddCartItemToCart(int cartId, int productId, int quantity)
    {
        var cart = dbContext.Set<Domain.Cart>().Find(cartId);

        if (cart != null)
        {
            // CartItem nesnesini oluştur
            var cartItem = new Domain.CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            // CartItem'ı ekle
            dbContext.Set<Domain.CartItem>().Add(cartItem);

            // Cart'ı güncelle
            dbContext.SaveChanges();

        }

    }

    public void IncreaseCartItemQuantity(int cartItemId, int quantityToAdd)
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity += quantityToAdd;
            dbContext.SaveChanges();
        }
    }

    public void DecreaseCartItemQuantity(int cartItemId, int quantityToSubtract)//düzelt
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null)
        {
            cartItem.Quantity -= quantityToSubtract;

            if (cartItem.Quantity < 0)
            {
                cartItem.Quantity = 0;
            }

            dbContext.SaveChanges();
        }
    }
    public void UpdateCartItemQuantity(int cartItemId, int newQuantity)//düzelt
    {
        var cartItem = dbContext.Set<Domain.CartItem>().Find(cartItemId);

        if (cartItem != null && newQuantity>0)
        {
            cartItem.Quantity = newQuantity;
            dbContext.SaveChanges();
        }
    }
}
