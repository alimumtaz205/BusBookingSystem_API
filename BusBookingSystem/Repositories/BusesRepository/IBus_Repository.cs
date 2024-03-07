using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Models.DTOs;

namespace BusBookingSystem.Repositories.BusesRepository
{
    public interface IBus_Repository
    {
        public BaseResponse GetScheduleData(ReservationRequest user, string numberOfPassangers);
    }
}