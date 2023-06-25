using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Coupon;

public interface ICouponRepository: IGenericRepository<Domain.Coupon>
{
    IEnumerable<Domain.Coupon> GetCouponsByOrderId(int orderId);
    IEnumerable<Domain.Coupon> GetUnusedCoupons();
    IEnumerable<Domain.Coupon> GetUsedCoupons();
    IEnumerable<Domain.Coupon> GetDiscount100Coupons();
    IEnumerable<Domain.Coupon> GetDiscount50Coupons();
    IEnumerable<Domain.Coupon> GetDiscount20Coupons();
    IEnumerable<Domain.Coupon> GetDiscount10Coupons();
    IEnumerable<Domain.Coupon> GetExpiredCoupons();
    IEnumerable<Domain.Coupon> GetNotExpiredCoupons();
    IEnumerable<Domain.Coupon> GetCoupons();

}
