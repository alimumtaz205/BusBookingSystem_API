namespace BusBookingSystem.Models.City
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }

    }

    public class CityDTO
    {
        public string? CityName { get; set; }
        public string? Country { get; set; }

    }

    public class City_ID
    {
        public int CityID { get; set; }
    }
}
