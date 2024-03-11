using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.UserRoles;

namespace BusBookingSystem.Repositories.UserManagementRepository
{
    public class UserMgtRepository: IUserMgtRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public UserMgtRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse AssignRole(UserRole user)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_AssignRole", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Parameters
                    cmd.Parameters.AddWithValue("@userID", user.UserID);
                    cmd.Parameters.AddWithValue("@Role", user.Role);

                    // Output parameters
                    cmd.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        int Code = Convert.ToInt32(cmd.Parameters["@ResultCode"].Value);
                        Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                        if (Code == 1)
                        {
                            resCode = ResCodes.Success;
                            isSuccess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {

            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

        public BaseResponse DeleteRole(User_ID user)
        {
            int Code = 0;
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_DeleteRole", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Parameters
                    cmd.Parameters.AddWithValue("@userID", user.UserID);

                    // Output parameters
                    cmd.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();

                        if(!string.IsNullOrEmpty(cmd.Parameters["@ResultCode"].Value.ToString()))
                        {
                          Code = Convert.ToInt32(cmd.Parameters["@ResultCode"].Value);
                        }

                        Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                        if (Code == 1)
                        {
                            resCode = ResCodes.Success;
                            isSuccess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {

            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

    }
}
