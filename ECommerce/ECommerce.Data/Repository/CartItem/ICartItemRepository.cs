using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.CartItem;

public interface ICartItemRepository:IGenericRepository<Domain.CartItem>
{
    Domain.Cart AddCartItemToCart(int cartId, int productId, int quantity);
    Domain.CartItem IncreaseOneCartItemQuantity(int cartItemId);
    Domain.CartItem DecreaseOneCartItemQuantity(int cartItemId);
    Domain.CartItem UpdateCartItemQuantity(int cartItemId, int newQuantity);
}
