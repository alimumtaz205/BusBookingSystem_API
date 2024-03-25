using BusBookingSystem.Models.City;
using BusBookingSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusBookingSystem.Repositories.CityRepository
{
    public interface ICityRepository
    {
        public BaseResponse AddCity(CityDTO request);

        public BaseResponse GetCity();

        public BaseResponse GetCityID(City_ID CityID);

        public BaseResponse DeleteCity(City_ID CityID);

        public BaseResponse UpdateCity(City request);
        

    }
}