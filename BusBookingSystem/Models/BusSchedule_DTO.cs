namespace BusBookingSystem.Models
{
    public class BusSchedule_DTO
    {
        public int BusID { get; set; }
        public int RouteID { get; set; }
        public string? Bus_Name { get; set; }
        public string? Capacity { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime DeparterDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
