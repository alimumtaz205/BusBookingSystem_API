namespace BusBookingSystem.Models.ReservationModel
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int Bus_Id { get; set; }
        public int Charges { get; set; }
        public bool IsCancelled { get; set; }
        public int CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int Deleted { get; set; }
        public int No_of_seats { get; set; }
        public string? Seat_No { get; set; }
        public string? Additional_luggage { get; set; }
        public string? Additional_luggage_details { get; set; }
    }

    public class ReservationDTO
    {
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int Bus_Id { get; set; }
        public int Charges { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int Deleted { get; set; }
        public int No_of_seats { get; set; }
        public string Seat_No { get; set; }
        public string? Additional_luggage { get; set; }
        public string? Additional_luggage_details { get; set; }
    }

    public class Reservation_ID
    {
        public int UserID { get; set; }
        public int ReservationID { get; set; }
    }
}
