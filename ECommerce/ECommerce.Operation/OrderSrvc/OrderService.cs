using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Order;
using Serilog;


namespace ECommerce.Operation.OrderSrvc
{
    public class OrderService : BaseService<Order, OrderRequest, OrderResponse>, IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ApiResponse CreateOrder(int cartId)
        {
            try
            {
                var entity = unitOfWork.OrderRepository().CreateOrder(cartId);
                if (entity is null)
                {
                    Log.Warning("Record not found for CartId " + cartId);
                    return new ApiResponse("Record not found");
                }
                unitOfWork.Complete();
                unitOfWork.OrderRepository().FillOrder(cartId);
                unitOfWork.Complete();
                unitOfWork.OrderRepository().GainPoints(cartId);
                unitOfWork.Complete();


                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CreateCartWithItem Exception");
                return new ApiResponse(ex.Message);
            }
        }

        public ApiResponse UpdateOrderForCancelledItems(int orderId)
        {
            try
            {
                var entity = unitOfWork.OrderRepository().OrderAfterCancelledItems(orderId);
                if (entity is null)
                {
                    Log.Warning("Record not found for orderId " + orderId);
                    return new ApiResponse("Record not found");
                }
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "UpdateOrderForCancelledItems Exception");
                return new ApiResponse(ex.Message);
            }
        }
        public ApiResponse CancelOrder(int orderId)
        {
            try
            {
                var entity = unitOfWork.OrderRepository().CancelOrder(orderId);
                if (entity is null)
                {
                    Log.Warning("Record not found for orderId " + orderId);
                    return new ApiResponse("Record not found");
                }
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Canceling Order Exception");
                return new ApiResponse(ex.Message);
            }
        }
        public ApiResponse<OrderResponse> GetByDateBetween(DateTime startDate, DateTime endDate)
        {
            try
            {
                var entity = unitOfWork.OrderRepository().GetByDateBetween(startDate, endDate);
                if (entity is null)
                {
                    Log.Warning("Record not found between this days ");
                    return new ApiResponse<OrderResponse>("Record not found");
                }
                var mapped = mapper.Map<OrderResponse>(entity);
                return new ApiResponse<OrderResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetByDateBetween Exception");
                return new ApiResponse<OrderResponse>(ex.Message);
            }
        }

        public ApiResponse<OrderResponse> GetByUserIdAndDateBetween(int userId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var entity = unitOfWork.OrderRepository().GetByUserIdAndDateBetween(userId, startDate, endDate);
                if (entity is null)
                {
                    Log.Warning("Record not found for this user between this days ");
                    return new ApiResponse<OrderResponse>("Record not found");
                }
                var mapped = mapper.Map<OrderResponse>(entity);
                return new ApiResponse<OrderResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetByUserIdAndDateBetween Exception");
                return new ApiResponse<OrderResponse>(ex.Message);
            }
        }

    }
}
