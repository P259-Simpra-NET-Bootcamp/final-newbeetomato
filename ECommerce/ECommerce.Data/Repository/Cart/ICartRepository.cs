using ECommerce.Data.Repository.Base;
using ECommerce.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Cart;

public interface ICartRepository: IGenericRepository<Domain.Cart>
{
    void CreateCartWithCartItem(int userId, int CartItemId);
    void DeleteCartWithItems(int CartId);
    decimal CartTotalAmount(int cartId);
    Domain.Cart GetCartWithItemsById(int cartId);
  

}
