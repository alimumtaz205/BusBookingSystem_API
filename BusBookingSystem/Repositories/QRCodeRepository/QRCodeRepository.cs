using BusBookingSystem.Common;
using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.QRCodeModel;
using BusBookingSystem.Models.ReservationModel;
using QRCoder;

namespace BusBookingSystem.Repositories.QRCodeRepository
{
    public class QRCodeRepository : IQRCodeRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public QRCodeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BaseResponse GenerateQRCode(QRCodeModel qRCode)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CONN_STR")))
            {
                using (SqlCommand command = new SqlCommand("sp_GenerateQRCode", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ReservationID", qRCode.ReservationID);
                    command.Parameters.AddWithValue("@QRCodeData", qRCode.QRCodeData);

                    // Output parameters
                    command.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Read the output parameters
                        int resultCode = (int)command.Parameters["@ResultCode"].Value;
                        string resultMessage = command.Parameters["@ResultMessage"].Value.ToString();

                        return new BaseResponse
                        {
                            resCode = ResCodes.Success,
                            Message = resultMessage
                        };
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions, log, etc.
                        Console.WriteLine("Error: " + ex.Message);
                        return new BaseResponse
                        {
                            resCode = 0,
                            Message = "Error occurred during QR code generation."
                        };
                    }
                }
            }
        }

    }
}
