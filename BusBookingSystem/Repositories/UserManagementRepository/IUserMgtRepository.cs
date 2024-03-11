using BusBookingSystem.Models.UserRoles;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;

namespace BusBookingSystem.Repositories.UserManagementRepository
{
    public interface IUserMgtRepository
    {
        public BaseResponse AssignRole(UserRole user);
        public BaseResponse DeleteRole(User_ID user);
    }
}