using ECommerce.Data.Repository.Base;
using ECommerce.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Cart;

public interface ICartRepository : IGenericRepository<Domain.Cart>
{
    Domain.Cart GetCartWithAllItems(int cartId);
    Domain.Product CreateCart(int userId, int ProductId);
    Domain.Cart CreateCartFillInside(int userId, int ProductId, int quantitiy);
    void DeleteCartWithItems(int CartId);
    Domain.Cart CartTotalAmount(int cartId);
    Domain.Cart GetCartItemsById(int cartId);
    Domain.Cart GetCardCouponsById(int cartId);
    Domain.Cart CalculateTotalDiscount(int cartId);
    Domain.Cart CartNetAmount(int cartId);
    Domain.Cart UsePoint(int cartId, decimal point);
    Domain.Coupon AddCouponToCart(int cartId, string couponCode);
    Domain.Coupon RemoveCouponFromCart(int cartId, int couponId);



}
