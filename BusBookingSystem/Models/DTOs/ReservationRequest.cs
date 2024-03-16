namespace BusBookingSystem.Models.DTOs
{
    public class ReservationRequest
    {
        public string? departureCity { get; set; }
        public string? arrivalCity { get; set; }
        public string? departureTime { get; set; }
    }

    public class CreateReservation
    {
        public string? busID { get; set; }
        public string? routeID { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public string? availableSeats { get; set; }
    }

    public class UpdateReservation
    {
        public string scheduleID { get; set; }
        public string? busID { get; set; }
        public string? routeID { get; set; }
        public DateTime? departureTime { get; set; }
        public DateTime? arrivalTime { get; set; }
        public string? availableSeats { get; set; }
    }

    public class DeleteReservation
    {
        public string scheduleID { get; set; }
    }
}
