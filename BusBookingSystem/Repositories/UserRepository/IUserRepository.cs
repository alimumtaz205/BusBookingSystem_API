using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusBookingSystem.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public BaseResponse CreateUser(UserDTO user);
        public BaseResponse GetUsers();
        public BaseResponse GetUserByID(User_ID ID);
        public BaseResponse UpdateUser(User request);
        public BaseResponse DeleteUser(User_ID ID);
    }
}