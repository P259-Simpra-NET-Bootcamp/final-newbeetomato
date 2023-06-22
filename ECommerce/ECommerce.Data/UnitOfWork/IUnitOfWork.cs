using ECommerce.Base.Model;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
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
    ICartRepository CartRepository();
    ICartItemRepository CartItemRepository();
    ICategoryRepository CategoryRepository();
    void Complete();
    void CompleteWithTransaction();
}
