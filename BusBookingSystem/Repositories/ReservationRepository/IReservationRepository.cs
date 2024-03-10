using BusBookingSystem.Models.ReservationModel;
using BusBookingSystem.Models;

namespace BusBookingSystem.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        public BaseResponse AddReservation(ReservationDTO request);
        public BaseResponse GetReservation(Reservation_ID request);
        public BaseResponse CancelReservation(Reservation_ID request);
        public BaseResponse UpdateReservation(Reservation request);
    }
}