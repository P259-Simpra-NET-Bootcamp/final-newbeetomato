using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Coupon;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CouponSrvc
{
    public class CouponService : BaseService<Coupon, CouponRequest, CouponResponse>, ICouponService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CouponService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ApiResponse<IEnumerable<CouponResponse>> GetCoupons()
        {
            try
            {
                var coupons = unitOfWork.CouponRepository().GetCoupons();
                if (coupons == null)
                {
                    Log.Warning("No coupons found ");
                    return new ApiResponse<IEnumerable<CouponResponse>>("No coupons found");
                }
                var mapped = mapper.Map<IEnumerable<CouponResponse>>(coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetCoupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }
            public ApiResponse<IEnumerable<CouponResponse>> GetCouponsByOrderId(int orderId)
        {
            try
            {
                var coupons = unitOfWork.CouponRepository().GetCouponsByOrderId(orderId);
                if (coupons == null || !coupons.Any())
                {
                    Log.Warning("No coupons found for orderId: " + orderId);
                    return new ApiResponse<IEnumerable<CouponResponse>>("No coupons found");
                }

                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetCouponsByOrderId Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetUnusedCoupons()
        {
            try
            {
                var unusedCoupons = unitOfWork.CouponRepository().GetUnusedCoupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(unusedCoupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetUnusedCoupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetUsedCoupons()
        {
            try
            {
                var usedCoupons = unitOfWork.CouponRepository().GetUsedCoupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(usedCoupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetUsedCoupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount100Coupons()
        {
            try
            {
                var discount100Coupons = unitOfWork.CouponRepository().GetDiscount100Coupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(discount100Coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetDiscount100Coupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount50Coupons()
        {
            try
            {
                var discount50Coupons = unitOfWork.CouponRepository().GetDiscount50Coupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(discount50Coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetDiscount50Coupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount20Coupons()
        {
            try
            {
                var discount20Coupons = unitOfWork.CouponRepository().GetDiscount20Coupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(discount20Coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetDiscount20Coupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }
        public ApiResponse<IEnumerable<CouponResponse>> GetDiscount10Coupons()
        {
            try
            {
                var discount10Coupons = unitOfWork.CouponRepository().GetDiscount10Coupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(discount10Coupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetDiscount10Coupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CouponResponse>> GetExpiredCoupons()
        {
            try
            {
                var expiringSoonCoupons = unitOfWork.CouponRepository().GetExpiredCoupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(expiringSoonCoupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetExpiringSoonCoupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }
        public ApiResponse<IEnumerable<CouponResponse>> GetNotExpiredCoupons()
        {
            try
            {
                var notExpiredCoupons = unitOfWork.CouponRepository().GetNotExpiredCoupons();
                var mappedCoupons = mapper.Map<IEnumerable<CouponResponse>>(notExpiredCoupons);
                return new ApiResponse<IEnumerable<CouponResponse>>(mappedCoupons);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetNotExpiredCoupons Exception");
                return new ApiResponse<IEnumerable<CouponResponse>>(ex.Message);
            }
        }
    }
}
