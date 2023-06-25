using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.UserSrvc
{
    public interface IUserService:IBaseService<User,UserRequest,UserResponse>
    {
        ApiResponse<UserResponse> AddMoney(int userId, int value);
        ApiResponse<UserResponse> AddUser(string userName, string mail, string firstName, string lastName, string Adress, string password, bool admin);
        ApiResponse<UserResponse> UpdateUser(string userName, UserRequest request);
        ApiResponse<UserResponse> GetUserByName(string userName);
        public ApiResponse<bool> DeleteUser(int userId);
        ApiResponse<List<UserResponse>> GetAllUsers();
        ApiResponse<UserResponse> GetUserById(int userId);
    }
}
