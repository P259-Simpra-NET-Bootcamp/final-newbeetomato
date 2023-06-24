using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CouponSrvc
{
    public interface ICouponService:IBaseService<Coupon, CouponRequest, CouponResponse>
    {
        ApiResponse<IEnumerable<CouponResponse>> GetCouponsByOrderId(int orderId);
        ApiResponse<IEnumerable<CouponResponse>> GetUnusedCoupons();
        ApiResponse<IEnumerable<CouponResponse>> GetUsedCoupons();
        ApiResponse<IEnumerable<CouponResponse>> GetDiscount100Coupons();
        ApiResponse<IEnumerable<CouponResponse>> GetDiscount50Coupons();
        ApiResponse<IEnumerable<CouponResponse>> GetDiscount20Coupons();
        ApiResponse<IEnumerable<CouponResponse>> GetDiscount10Coupons();
        ApiResponse<IEnumerable<CouponResponse>> GetCoupons();
        ApiResponse<IEnumerable<CouponResponse>> GetExpiredCoupons();
        ApiResponse<IEnumerable<CouponResponse>> GetNotExpiredCoupons();
    }
}
