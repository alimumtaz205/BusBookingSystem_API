using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models.UserModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;

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

        public BaseResponse CreateUser(UserDTO user)
        {
            string userName = "system";
            int Code = 0;

            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_RegisterUser]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@User_name", userName);

                    // Output parameters
                    cmd.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        if (!string.IsNullOrEmpty(cmd.Parameters["@ResultCode"].Value.ToString()))
                        {
                            Code = Convert.ToInt32(cmd.Parameters["@ResultCode"].Value);
                        }
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

        public BaseResponse GetUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<User> ListData = new List<User>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_GetUsers]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@userID", "0");

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            User obj = new User();

                            obj.UserID = Convert.ToInt32(dr["UserID"]);
                            obj.Email = Convert.ToString(dr["Email"]);
                            obj.FirstName = Convert.ToString(dr["FirstName"]);
                            obj.LastName = Convert.ToString(dr["LastName"]);
                            obj.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            obj.Gender = Convert.ToString(dr["Gender"]);
                            ListData.Add(obj);
                        }
                    }
                    isSuccess = true;
                    con.Close();
                    resCode = ResCodes.Success;
                    Message = "";
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse GetUserByID(User_ID ID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<User> ListData = new List<User>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetUsers", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@userID", ID.UserID);

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            User obj = new User();

                            obj.UserID = Convert.ToInt32(dr["UserID"]);
                            obj.Email = Convert.ToString(dr["Email"]);
                            obj.FirstName = Convert.ToString(dr["FirstName"]);
                            obj.LastName = Convert.ToString(dr["LastName"]);
                            obj.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            obj.Gender = Convert.ToString(dr["Gender"]);
                            ListData.Add(obj);
                        }
                    }
                    isSuccess = true;
                    con.Close();
                    resCode = ResCodes.Success;
                    Message = "";
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse UpdateUser(User request)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters

                      cmd.Parameters.AddWithValue("@userID", request.UserID);
                      cmd.Parameters.AddWithValue("@Email", request.Email);
                      cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                      cmd.Parameters.AddWithValue("@LastName", request.LastName);
                      cmd.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                      cmd.Parameters.AddWithValue("@Gender", request.Gender);
                      cmd.Parameters.AddWithValue("@user_Name", "");

                    SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the output message
                    Message = messageParameter.Value.ToString();

                    isSuccess = true;
                    con.Close();
                    //tranCode = TranCodes.Success;
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = request };
        }

        public BaseResponse DeleteUser(User_ID ID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_DeleteUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@userID", ID.UserID);

                    SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the output message
                    Message = messageParameter.Value.ToString();

                    isSuccess = true;
                    con.Close();
                    //tranCode = TranCodes.Success;
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

        //public BaseResponse DeleteUser(BusID BusID)
        //{
        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

        //        using (SqlCommand cmd = new SqlCommand("sp_DeleteBus", con))
        //        {
        //            con.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // Parameters
        //            cmd.Parameters.AddWithValue("@busID", BusID.Bus_ID);

        //            SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
        //            messageParameter.Direction = ParameterDirection.Output;

        //            cmd.ExecuteNonQuery();

        //            // Retrieve the output message
        //            Message = messageParameter.Value.ToString();

        //            isSuccess = true;
        //            con.Close();
        //            //tranCode = TranCodes.Success;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        //}

        //public BaseResponse UpdateBus(Bus request)
        //{
        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

        //        using (SqlCommand cmd = new SqlCommand("sp_UpdateBus", con))
        //        {
        //            con.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // Parameters
        //            cmd.Parameters.AddWithValue("@busID", request.BusID);
        //            cmd.Parameters.AddWithValue("@newBusName", request.BusName);
        //            cmd.Parameters.AddWithValue("@newBusCapacity", request.Capacity);
        //            cmd.Parameters.AddWithValue("@newBusNo", request.BusNo);
        //            cmd.Parameters.AddWithValue("@newBusType", request.BusType);

        //            SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
        //            messageParameter.Direction = ParameterDirection.Output;

        //            cmd.ExecuteNonQuery();

        //            // Retrieve the output message
        //            Message = messageParameter.Value.ToString();

        //            isSuccess = true;
        //            con.Close();
        //            //tranCode = TranCodes.Success;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        //}


        //public BaseResponse Login(User user)
        //{
        //    Algorithms obj_Algorithms = new Algorithms();
        //    Credentials credentials = new Credentials();

        //    credentials = obj_Algorithms.GenerateSaltedHash(user.Password);

        //    try
        //    {
        //        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

        //        using (SqlCommand cmd = new SqlCommand("[sp_CreateUser]", con))
        //        {
        //            con.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // Parameters
        //            cmd.Parameters.AddWithValue("@Email", user.Email);
        //            cmd.Parameters.AddWithValue("@PasswordHash", credentials.hashedPassword);
        //            cmd.Parameters.AddWithValue("@Salt", credentials.salt);
        //            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        //            cmd.Parameters.AddWithValue("@LastName", user.LastName);

        //            // Output parameters
        //            cmd.Parameters.Add("@ResultCode", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                int Code = Convert.ToInt32(cmd.Parameters["@ResultCode"].Value);
        //                Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
        //                if (Code == 1)
        //                {
        //                    resCode = ResCodes.Success;
        //                    isSuccess = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Message = ex.Message;
        //            }
        //            con.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        //}

    }
}
