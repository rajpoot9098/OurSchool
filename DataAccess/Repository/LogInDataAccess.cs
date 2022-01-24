using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LogInDataAccess
    {
        DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private ClsConnection constring;
        private SqlConnection con;

        public dynamic LogInUser(LoginParam loginparam)
        {
            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_Registration", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 4);
                da.SelectCommand.Parameters.AddWithValue("@UserName", loginparam.UserName);
                da.SelectCommand.Parameters.AddWithValue("@Password", loginparam.Password);
                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }
    }
}
