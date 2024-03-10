namespace BusBookingSystem.Models.BusModel
{
    public class Bus
    {
        public int BusID { get; set; }
        public string? BusName { get; set; }
        public int Capacity { get; set; }
        public string? BusNo { get; set; }
        public string? BusType { get; set; }

    }

    public class BusDTO
    {
        public string? BusName { get; set; }
        public int Capacity { get; set; }
        public string? BusNo { get; set; }
        public string? BusType { get; set; }

    }

    public class BusID
    {
        public int Bus_ID { get; set; }
    }
}
