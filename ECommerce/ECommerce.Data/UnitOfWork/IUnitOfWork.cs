using ECommerce.Base.Model;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using ECommerce.Data.Repository.CartItem;
using ECommerce.Data.Repository.Category;
using ECommerce.Data.Repository.Coupon;
using ECommerce.Data.Repository.Order;
using ECommerce.Data.Repository.OrderItem;
using ECommerce.Data.Repository.Product;
using ECommerce.Data.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.UnitOfWork;

public interface IUnitOfWork:IDisposable
{

    IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;
    IProductRepository ProductRepository();
    IUserRepository UserRepository();
    ICartRepository CartRepository();
    IOrderRepository OrderRepository();
    ICartItemRepository CartItemRepository();
    ICategoryRepository CategoryRepository();
    IOrderItemRepository OrderItemRepository();
    ICouponRepository CouponRepository();
    void Complete();
    void CompleteWithTransaction();
}
