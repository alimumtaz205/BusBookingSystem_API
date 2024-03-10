using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models.BusModel;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusBookingSystem.Repositories.BusesRepository
{
    public interface IBus_Repository
    {
        public BaseResponse AddBus(BusDTO request);
        public BaseResponse GetBusesData();
        public BaseResponse GetBuseByID(BusID BusID);
        public BaseResponse DeleteBus(BusID BusID);
        public BaseResponse UpdateBus(Bus request);
    }
}