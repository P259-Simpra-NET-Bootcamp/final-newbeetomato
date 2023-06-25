using ECommerce.Base.Response;
using ECommerce.Data.Context;

using ECommerce.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;



namespace ECommerce.Data.Repository.Cart;

public class CartRepository : GenericRepository<Domain.Cart>, ICartRepository
{
    public CartRepository(EComDbContext dbContext) : base(dbContext)
    {


    }

    public Domain.Cart GetCartWithAllItems(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems).Include(c => c.Coupons)
            .FirstOrDefault(c => c.Id == cartId);
        return cart;
    }
    public Domain.Product CreateCart(int userId, int ProductId)
    {
        var Product = dbContext.Set<Domain.Product>().FirstOrDefault(x => x.Id == ProductId);
        var cart = new Domain.Cart
        {
            UserId = userId,
            CartItems = new List<Domain.CartItem>(),
        };
        return Product;
    }
    
    public Domain.Cart CreateCartFillInside(int userId, int ProductId, int quantitiy)
    {


        var ourCart = dbContext.Set<Domain.Cart>().Where(x => x.UserId == userId).FirstOrDefault();
        int CartId = ourCart.Id;
        var cartItem = new Domain.CartItem
        {
            CartId = CartId,
            ProductId = ProductId,
            Quantity = quantitiy

        };
        return ourCart;

    }


    public void DeleteCartWithItems(int CartId)
    {
        var items = dbContext.Set<Domain.CartItem>().Where(x => x.CartId == CartId).ToList();

        if (items != null)
        {
            foreach (var item in items)
            {
                dbContext.Set<Domain.CartItem>().Remove(item);
            }
        }
        DeleteById(CartId);
    }

    public Domain.Cart CartTotalAmount(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.Id == cartId);

        decimal totalAmount = 0;

        if (cart != null)
        {
            foreach (var cartItem in cart.CartItems)
            {
                decimal itemPrice = dbContext.Set<Domain.Product>()
                    .Where(p => p.Id == cartItem.ProductId)
                    .Select(p => p.UnitPrice)
                    .FirstOrDefault();

                totalAmount += itemPrice * cartItem.Quantity;
            }
            cart.CartTotalAmount = totalAmount;
        }
        return cart;

    }



    public Domain.Cart GetCartItemsById(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.Id == cartId);

        if (cart == null)
        {
            return null;
        }

        return cart;
    }

    public Domain.Cart GetCardCouponsById(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.Coupons)
            .FirstOrDefault(c => c.Id == cartId);

        if (cart == null)
        {
            return null;
        }

        return cart;
    }


    public Domain.Cart CalculateTotalDiscount(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>()
            .Include(c => c.Coupons)
            .FirstOrDefault(c => c.Id == cartId);
        decimal couponDiscount = 0;
        decimal totalDiscount = 0;
        decimal? DPoints = 0;

        if (cart != null)
        {

            foreach (var coupon in cart.Coupons)
            {
                couponDiscount = 0;
                if (coupon.DiscountAmount100)
                    couponDiscount = 100;
                else if (coupon.DiscountAmount50)
                    couponDiscount = 50;
                else if (coupon.DiscountAmount20)
                    couponDiscount = 20;
                else if (coupon.DiscountAmount10)
                    couponDiscount = 10;

                totalDiscount += couponDiscount;
            }
            cart.CouponPoints = totalDiscount;

            DPoints = cart.UsedPoints;
            if (DPoints == null) { DPoints = 0; }
            decimal? remainingAmount = cart.CartTotalAmount - totalDiscount;
            if (remainingAmount > 0 && DPoints <= remainingAmount)
            {

                cart.TotalDiscount = DPoints + totalDiscount;
            }
            else if (remainingAmount > 0 && DPoints >= remainingAmount)
            {
                cart.TotalDiscount = cart.CartTotalAmount;
                cart.UsedPoints = remainingAmount;
            }
        }
        return cart;
    }


    public Domain.Cart CartNetAmount(int cartId)
    {
        var cart = dbContext.Set<Domain.Cart>().FirstOrDefault(c => c.Id == cartId);

        if (cart != null)
        {
            decimal? netAmount = cart.CartTotalAmount - cart.TotalDiscount;
            cart.NetAmount = netAmount;
        }
        return cart;

    }
    public Domain.Cart UsePoint(int cartId, decimal point)
    {

        var cart = dbContext.Set<Domain.Cart>().FirstOrDefault(c => c.Id == cartId);
        var userId = cart.UserId;
        decimal? UserPoints = dbContext.Set<Domain.User>().Where(x => x.Id == userId)
            .Select(p => p.PointBalance)
            .FirstOrDefault();


        if (UserPoints > point)
        {
            cart.UsedPoints = point;
        }
        return cart;
    }
    public Domain.Coupon AddCouponToCart(int cartId, string couponCode)
    {

        var cart = dbContext.Set<Domain.Cart>().FirstOrDefault(c => c.Id == cartId);
        if (cart == null) { return null; }
        var coupon = dbContext.Set<Domain.Coupon>().FirstOrDefault(c => c.Code == couponCode && c.IsActive && !c.IsUsed && c.ExpirationDate >= DateTime.Now);

        if (cart != null && coupon != null)
        {
            cart.Coupons.Add(coupon);
        }
        return coupon;
    }

    public Domain.Coupon RemoveCouponFromCart(int cartId, int couponId)
    {
        var cart = dbContext.Set<Domain.Cart>().FirstOrDefault(c => c.Id == cartId);
        if (cart == null) { return null; }

        var coupon = dbContext.Set<Domain.Coupon>().FirstOrDefault(c => c.Id == couponId && c.IsActive && c.IsUsed && c.CartId == cartId);

        if (cart != null && coupon != null)
        {
            cart.Coupons.Remove(coupon);
        }
        return coupon;
    }


}
