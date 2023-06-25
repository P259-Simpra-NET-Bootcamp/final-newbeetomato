using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Coupon;
using ECommerce.Schema.OrderItem;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.OrderItemSrvc;

public class OrderItemService : BaseService<OrderItem, OrderItemRequest, OrderItemResponse>, IOrderItemService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ApiResponse CancelOrderItem(int orderId, int orderItemId) 
    {
        try
        {
            var orderItem = unitOfWork.OrderItemRepository().CanceledOrderItem(orderId, orderItemId);
            if (orderItem == null) 
            {
                Log.Warning("No orderItem found for orderId: " + orderId);
                return new ApiResponse("No orderItem found");
            }
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetCouponsByOrderId Exception");
            return new ApiResponse(ex.Message);
        }
    }

}
