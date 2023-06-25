using ECommerce.Base.Response;
using ECommerce.Operation.CouponSrvc;
using ECommerce.Schema.Coupon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/coupons")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")] // Sadece admin rolüne sahip kullanıcılar bu işlemi yapabilir
        public ApiResponse CreateCoupon([FromBody] CouponRequest request)
        {
            var response = couponService.Insert(request);
            return response;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public ApiResponse DeleteCoupon(int id)
        {
            var response = couponService.Delete(id);
            return response;
        }

        [HttpGet]
        public ApiResponse<IEnumerable<CouponResponse>> GetCoupons()
        {
            return couponService.GetCoupons();
        }

        [HttpGet("{id}")]
        public ApiResponse<CouponResponse> GetCouponById(int id)
        {
            return couponService.GetById(id);
        }
        [HttpGet("by-order/{orderId}")]
        public ApiResponse<IEnumerable<CouponResponse>> GetCouponsByOrderId(int orderId)
        {
            return couponService.GetCouponsByOrderId(orderId);
        }
        [HttpGet("unused")]
        public ApiResponse<IEnumerable<CouponResponse>> GetUnusedCoupons()
        {
            return couponService.GetUnusedCoupons();
        }

        [HttpGet("used")]
        public ApiResponse<IEnumerable<CouponResponse>> GetUsedCoupons()
        {
            return couponService.GetUsedCoupons();
        }

        [HttpGet("discount-100")]
        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount100Coupons()
        {
            return couponService.GetDiscount100Coupons();
        }

        [HttpGet("discount-50")]
        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount50Coupons()
        {
            return couponService.GetDiscount50Coupons();
        }

        [HttpGet("discount-20")]
        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount20Coupons()
        {
            return couponService.GetDiscount20Coupons();
        }

        [HttpGet("discount-10")]
        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount10Coupons()
        {
            return couponService.GetDiscount10Coupons();
        }

        [HttpGet("expired")]
        public ApiResponse<IEnumerable<CouponResponse>> GetExpiredCoupons()
        {
            return couponService.GetExpiredCoupons();
        }

        [HttpGet("not-expired")]
        public ApiResponse<IEnumerable<CouponResponse>> GetNotExpiredCoupons()
        {
            return couponService.GetNotExpiredCoupons();
        }
    }
}
