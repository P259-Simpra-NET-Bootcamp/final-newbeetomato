using ECommerce.Base.Response;
using ECommerce.Schema.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.Identity;

public interface IAuthenticationService
{
    public Task<ApiResponse<TokenResponse>> SignIn(TokenRequest request);
    public Task<ApiResponse> SignOut();
    public Task<ApiResponse> ChangePassword(ClaimsPrincipal User, ChangePasswordRequest request);

}
