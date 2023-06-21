using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Cart;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CartSrvc;

public class CartService : BaseService<Cart, CartRequest, CartResponse>, ICartService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CartService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public ApiResponse<CartResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.Repository<Cart>().GetById(id);
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetById Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }

    }
    
}
