using ECommerce.Data.Context;
using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Coupon;

public class CouponRepository : GenericRepository<Domain.Coupon>, ICouponRepository

{
    public CouponRepository(EComDbContext dbContext) : base(dbContext)
    {

    }
   


    public IEnumerable<Domain.Coupon> GetCouponsByOrderId(int orderId)
    {
        return GetAll().Where(c => c.OrderId == orderId);
    }
    public IEnumerable<Domain.Coupon> GetUnusedCoupons()
    {
        return GetAll().Where(c => !c.IsUsed);
    }

    public IEnumerable<Domain.Coupon> GetUsedCoupons()
    {
        return GetAll().Where(c => c.IsUsed);
    }

    public IEnumerable<Domain.Coupon> GetDiscount100Coupons()
    {
        return GetAll().Where(c => c.DiscountAmount100);
    }

    public IEnumerable<Domain.Coupon> GetDiscount50Coupons()
    {
        return GetAll().Where(c => c.DiscountAmount50);
    }

    public IEnumerable<Domain.Coupon> GetDiscount20Coupons()
    {
        return GetAll().Where(c => c.DiscountAmount20);
    }

    public IEnumerable<Domain.Coupon> GetDiscount10Coupons()
    {
        return GetAll().Where(c => c.DiscountAmount10);
    }
    public IEnumerable<Domain.Coupon> GetCoupons() 
    {
        return GetAll();
    }

    public IEnumerable<Domain.Coupon> GetExpiredCoupons()
    {
        return GetAll().Where(c => c.ExpirationDate < DateTime.Now);
    }

    public IEnumerable<Domain.Coupon> GetNotExpiredCoupons()
    {
        return GetAll().Where(c => c.ExpirationDate >= DateTime.Now);
    }
    

}
