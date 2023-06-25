using ECommerce.Base.Response;
using ECommerce.Schema.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.User;

public interface IUserService
{
    public Task<ApiResponse<ApplicationUserResponse>> GetUser(ClaimsPrincipal User);
    public Task<ApiResponse> Insert(ApplicationUserRequest request);
    public Task<ApiResponse> Update(ApplicationUserRequest request);
    public Task<ApiResponse> Delete(string id);
    public Task<ApiResponse<List<ApplicationUserResponse>>> GetAll();
    public Task<ApiResponse<ApplicationUserResponse>> GetById(string id);
    public Task<ApiResponse<string>> GetUserId(ClaimsPrincipal User);
}
