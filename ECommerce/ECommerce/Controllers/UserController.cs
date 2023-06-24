using ECommerce.Base.Response;
using ECommerce.Base.Role;
using ECommerce.Data.Domain;
using ECommerce.Operation.Authorize;
using ECommerce.Operation.User;
using ECommerce.Schema.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers;
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService service;
    private readonly UserManager<ApplicationUser> userManager;

    public UserController(IUserService service, UserManager<ApplicationUser> userManager)
    {
        this.service = service;
        this.userManager = userManager;
    }

    [HttpPost("AddAdmin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAdmin(ApplicationUserRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,
            NationalIdNumber = request.NationalIdNumber,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin", 
            UpdatedAt = null,
            UpdatedBy = null,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Admin", 
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
            return Ok("Admin user created successfully");
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpPost("AddAdminfirst")]
    public async Task<IActionResult> AddAdminFirstTime(ApplicationUserRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,
            NationalIdNumber = request.NationalIdNumber,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin", 
            UpdatedAt = null,
            UpdatedBy = null,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Admin", 
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
            return Ok("Admin user created successfully");
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpGet]
    public async Task<ApiResponse<List<ApplicationUserResponse>>> GetAll()
    {
        var list = await service.GetAll();
        return list;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<ApplicationUserResponse>> GetById(string id)
    {
        var model = await service.GetById(id);
        return model;
    }

    [HttpGet("GetUser")]
    public async Task<ApiResponse<ApplicationUserResponse>> GetUser()
    {
        var response = await service.GetUser(HttpContext.User);
        return response;
    }

    [HttpGet("GetUserId")]
    public async Task<ApiResponse<string>> GetUserId()
    {
        var response = await service.GetUserId(HttpContext.User);
        return response;
    }

    [HttpPost]
    public async Task<ApiResponse> Post([FromBody] ApplicationUserRequest request)
    {
        var response = await service.Insert(request);
        return response;
    }

    [HttpPut]
    public async Task<ApiResponse> Put([FromBody] ApplicationUserRequest request)
    {
        var response = await service.Update(request);
        return response;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(string id)
    {
        var response = await service.Delete(id);
        return response;
    }
}