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
    void AddCartItemToCart(int cartId, int productId, int quantity);
    void IncreaseCartItemQuantity(int cartItemId, int quantityToAdd);
    void DecreaseCartItemQuantity(int cartItemId, int quantityToSubtract);
    void UpdateCartItemQuantity(int cartItemId, int newQuantity);
}
