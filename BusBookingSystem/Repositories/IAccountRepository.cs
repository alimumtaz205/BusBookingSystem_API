using BusBookingSystem.Models;

namespace BusBookingSystem.Repositories
{
    public interface IAccountRepository
    {
        public BaseResponse Login(Account account);
    }
}