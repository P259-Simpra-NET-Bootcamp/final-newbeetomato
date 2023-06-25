using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Schema.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.User;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;


    public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> InsertAdmin(ApplicationUserRequest request)
    {
        var response = await Insert(request); 

        if (response.Success)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            await userManager.AddToRoleAsync(user, "Admin"); 
        }

        return response;
    }
    public async Task<ApiResponse<ApplicationUserResponse>> GetUser(ClaimsPrincipal User)
    {
        var user = await userManager.GetUserAsync(User);
        var mapped = mapper.Map<ApplicationUserResponse>(user);
        return new ApiResponse<ApplicationUserResponse>(mapped);
    }




    public async Task<ApiResponse> Insert(ApplicationUserRequest request)
    {
        if (request is null)
        {
            return new ApiResponse("Request was null");
        }
        if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Email))
        {
            return new ApiResponse("Request was null");
        }

        var entity = mapper.Map<ApplicationUser>(request);
        entity.EmailConfirmed = true;
        entity.TwoFactorEnabled = false;

        var response = await userManager.CreateAsync(entity, request.Password);
        if (!response.Succeeded)
        {
            return new ApiResponse(response.Errors.FirstOrDefault()?.Description);
        }

        return new ApiResponse();
    }
    public async Task<ApiResponse> Update(ApplicationUserRequest request)
    {
        if (request is null)
        {
            return new ApiResponse("Request was null");
        }
        if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Email))
        {
            return new ApiResponse("Request was null");
        }

        var mapped = mapper.Map<ApplicationUser>(request);
        await userManager.UpdateAsync(mapped);

        return new ApiResponse();
    }

    public async Task<ApiResponse> Delete(int id)
    {
        var user = userManager.Users.Where(x => x.Id == id).FirstOrDefault();

        if (user == null)
        {
            return new ApiResponse("Request was null");
        }
        await userManager.DeleteAsync(user);

        return new ApiResponse();
    }


    public async Task<ApiResponse<List<ApplicationUserResponse>>> GetAll()
    {
        var list = userManager.Users.ToList();
        var mapped = mapper.Map<List<ApplicationUserResponse>>(list);
        return new ApiResponse<List<ApplicationUserResponse>>(mapped);
    }
    public async Task<ApiResponse<ApplicationUserResponse>> GetById(int id)
    {
        var list = userManager.Users.Where(x => x.Id == id).FirstOrDefault();
        var mapped = mapper.Map<ApplicationUserResponse>(list);
        return new ApiResponse<ApplicationUserResponse>(mapped);
    }
    public async Task<ApiResponse<string>> GetUserId(ClaimsPrincipal User)
    {
        var id = userManager.GetUserId(User);
        return new ApiResponse<string>(id);
    }
}
