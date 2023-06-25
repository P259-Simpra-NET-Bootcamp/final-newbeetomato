using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.User;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.UserSrvc
{
    public class UserService : BaseService<Data.Domain.User, UserRequest, UserResponse>, IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ApiResponse<UserResponse> AddMoney(int userId, int value)
        {
            try
            {
                var user = unitOfWork.UserRepository().AddMoney(userId, value);
                if (user is null)
                {
                    Log.Warning("Record not found for UserId " + userId);
                    return new ApiResponse<UserResponse>("Record not found");
                }

                unitOfWork.Complete();
                var mapped = mapper.Map<UserResponse>(user);
                return new ApiResponse<UserResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AddMoney Exception");
                return new ApiResponse<UserResponse>(ex.Message);
            }
        }
        public ApiResponse<UserResponse> AddUser(string userName, string mail, string firstName, string lastName,string adress,string password,bool admin)
        {
            try
            {
                var entity = new Data.Domain.User
                {
                    UserName = userName,
                    Email = mail,
                    FirstName = firstName,
                    LastName = lastName,
                    Address=adress,
                    Password=password,
                    IsAdmin = admin
                };
                if(entity is null) 
                {
                    return new ApiResponse<UserResponse>("Missing or Wrong enterence");
                }

                unitOfWork.UserRepository().Insert(entity);
                unitOfWork.Complete();

                var mapped = mapper.Map<UserResponse>(entity);
                return new ApiResponse<UserResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AddAdmin Exception");
                return new ApiResponse<UserResponse>(ex.Message);
            }
        }

        public ApiResponse<UserResponse> GetUserById(int userId)
        {
            try
            {
                var user = unitOfWork.UserRepository().GetById(userId);
                if (user is null)
                {
                    Log.Warning("Record not found for UserId " + userId);
                    return new ApiResponse<UserResponse>("Record not found");
                }

                var mapped = mapper.Map<UserResponse>(user);
                return new ApiResponse<UserResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetUserById Exception");
                return new ApiResponse<UserResponse>(ex.Message);
            }
        }

        public ApiResponse<List<UserResponse>> GetAllUsers()
        {
            try
            {
                var users = unitOfWork.UserRepository().GetAll();
                var mapped = mapper.Map<List<UserResponse>>(users);
                return new ApiResponse<List<UserResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAllUsers Exception");
                return new ApiResponse<List<UserResponse>>(ex.Message);
            }
        }
        public ApiResponse<bool> DeleteUser(int userId)
        {
            try
            {
                var existingUser = unitOfWork.UserRepository().GetById(userId);
                if (existingUser is null)
                {
                    Log.Warning("Record not found for UserId " + userId);
                    return new ApiResponse<bool>("Record not found");
                }

                unitOfWork.UserRepository().Delete(existingUser);
                unitOfWork.Complete();

                return new ApiResponse<bool>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "DeleteUser Exception");
                return new ApiResponse<bool>(ex.Message);
            }
        }
        public ApiResponse<UserResponse> GetUserByName(string userName)
        {
            try
            {
                var user = unitOfWork.UserRepository().Where(u => u.UserName == userName).FirstOrDefault();
                if (user is null)
                {
                    Log.Warning("User not found with UserName " + userName);
                    return new ApiResponse<UserResponse>("User not found");
                }

                var mapped = mapper.Map<UserResponse>(user);
                return new ApiResponse<UserResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetUserByName Exception");
                return new ApiResponse<UserResponse>(ex.Message);
            }
        }

        public ApiResponse<UserResponse> UpdateUser(string userName, UserRequest request)
        {
            try
            {
                var existingUser = unitOfWork.UserRepository().Where(u => u.UserName == userName).FirstOrDefault();
                if (existingUser is null)
                {
                    Log.Warning("User not found with UserName " + userName);
                    return new ApiResponse<UserResponse>("User not found");
                }

                existingUser.UserName = request.UserName;
                existingUser.Email = request.Email;
                existingUser.FirstName = request.FirstName;
                existingUser.LastName = request.LastName;
                existingUser.Address = request.Address;
                existingUser.IsAdmin = request.IsAdmin;

                unitOfWork.Complete();

                var mapped = mapper.Map<UserResponse>(existingUser);
                return new ApiResponse<UserResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "UpdateUser Exception");
                return new ApiResponse<UserResponse>(ex.Message);
            }
        }

    }
}
