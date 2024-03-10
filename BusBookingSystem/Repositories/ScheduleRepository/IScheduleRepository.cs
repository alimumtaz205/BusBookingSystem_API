using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models;

namespace BusBookingSystem.Repositories.ScheduleRepository
{
    public interface IScheduleRepository
    {
        public BaseResponse GetScheduleData(ReservationRequest request, string numberOfPassangers);
        public BaseResponse CreateSchedule(CreateReservation request);
    }
}