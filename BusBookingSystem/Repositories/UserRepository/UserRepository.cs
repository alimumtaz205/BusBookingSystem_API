using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using System.Data;
using System.Data.SqlClient;

namespace BusBookingSystem.Repositories.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration _configuration;
            bool isSuccess = false;
            string Message = string.Empty;
            ResCodes resCode = ResCodes.Exception;

        public UserRepository(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public BaseResponse CreateUser(User user)
        {
            Algorithms obj_Algorithms = new Algorithms();
            Credentials credentials = new Credentials();
            
            credentials = obj_Algorithms.GenerateSaltedHash(user.Password);

            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_CreateUser]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", credentials.hashedPassword);
                    cmd.Parameters.AddWithValue("@Salt", credentials.salt);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);

                    // Output parameters
                    cmd.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        int Code = Convert.ToInt32(cmd.Parameters["@ResultCode"].Value);
                        Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                        if(Code==1)
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

        public BaseResponse Login(User user)
        {
            Algorithms obj_Algorithms = new Algorithms();
            Credentials credentials = new Credentials();

            credentials = obj_Algorithms.GenerateSaltedHash(user.Password);

            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_CreateUser]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", credentials.hashedPassword);
                    cmd.Parameters.AddWithValue("@Salt", credentials.salt);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);

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

    }
}
