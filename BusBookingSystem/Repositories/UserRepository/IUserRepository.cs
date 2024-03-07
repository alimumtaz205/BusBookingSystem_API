using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;

namespace BusBookingSystem.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public BaseResponse CreateUser(User user);
    }
}