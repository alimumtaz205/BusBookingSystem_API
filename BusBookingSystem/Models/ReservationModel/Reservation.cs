namespace BusBookingSystem.Models.ReservationModel
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime BookingDateTime { get; set; }
        public bool IsCancelled { get; set; }

    }
}
