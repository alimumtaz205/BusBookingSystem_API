using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using System.Data.SqlClient;
using System.Data;

namespace BusBookingSystem.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse Login(Account account)
        {
            User_ID user_ID = new User_ID();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_UserLogin", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@UserName", account.Email);
                    cmd.Parameters.AddWithValue("@Password", account.Password);


                    // Output parameters
                    cmd.Parameters.Add("@LoginSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    // Retrieve output parameters
                    isSuccess = (bool)cmd.Parameters["@LoginSuccess"].Value;
                    Message = (string)cmd.Parameters["@Message"].Value;

                    if (isSuccess)
                    {
                        user_ID.UserID = (int)cmd.Parameters["@UserID"].Value;
                    }
               

                    con.Close();
                    resCode = ResCodes.Success;
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = user_ID };
        }

    }
}
