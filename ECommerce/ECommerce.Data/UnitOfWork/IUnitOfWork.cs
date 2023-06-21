using ECommerce.Base.Model;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.CartItem;
using ECommerce.Data.Repository.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.UnitOfWork;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;
    ICartItemRepository AddCartItemToCart(int cartId, int productId, int quantity);
    ICartItemRepository IncreaseCartItemQuantity(int cartItemId, int quantityToAdd);
    ICartItemRepository DecreaseCartItemQuantity(int cartItemId, int quantityToSubtract);
    ICartItemRepository UpdateCartItemQuantity(int cartItemId, int newQuantity);
    void Complete();
    void CompleteWithTransaction();
}
