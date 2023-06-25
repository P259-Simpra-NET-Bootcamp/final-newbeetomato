using ECommerce.Base.Response;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.UserSrvc;
using ECommerce.Schema.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpPost("AddAdmin")]
    public ApiResponse<UserResponse> AddAdmin(UserRequest request)
    {
        return userService.AddUser(request.UserName, request.Email, request.FirstName, request.LastName, request.Address, request.Password,true);
    }

    
    [HttpPost("User")]
    public ApiResponse<UserResponse> AddUser(UserRequest request)
    {
        return userService.AddUser(request.UserName, request.Email, request.FirstName, request.LastName, request.Address, request.Password,false);

    }

    [HttpGet("{userId}")]
    public ApiResponse<UserResponse> GetUserById(int userId)
    {
        return userService.GetUserById(userId);
    }

    [HttpGet]
    public ApiResponse<List<UserResponse>> GetAllUsers()
    {
        return userService.GetAllUsers();
    }

    [HttpPut("{userName}")]
    public ApiResponse<UserResponse> UpdateUser(string userName, UserRequest request)
    {
        return userService.UpdateUser(userName, request);
    }

    [HttpDelete("{userId}")]
    public ApiResponse<bool> DeleteUser(int userId)
    {
        return userService.DeleteUser(userId);
    }

    [HttpGet("GetUserByName/{userName}")]
    public ApiResponse<UserResponse> GetUserByName(string userName)
    {
        return userService.GetUserByName(userName);
    }

}    