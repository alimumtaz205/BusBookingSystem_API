using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models;
using BusBookingSystem.Models.RouteModel;

namespace BusBookingSystem.Repositories.ScheduleRepository
{
    public interface IScheduleRepository
    {
        public BaseResponse GetScheduleData(ReservationRequest request, string numberOfPassangers);
        public BaseResponse CreateSchedule(CreateReservation request);
        public BaseResponse UpdateSchedule(UpdateReservation request);
        public BaseResponse DeleteSchedule(DeleteReservation request);
        public BaseResponse GetFare(FareModel request);
    }
}