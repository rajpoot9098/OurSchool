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
    public class RegistrationDataAccess
    {
        DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private ClsConnection constring;
        private SqlConnection con;

        public dynamic GetDepartmentData()
        {
            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_Registration", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 1);
                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        public dynamic GetRegistrationData()
        {
            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_Registration", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 3);
                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        public dynamic SaveRegistration(dynamic model)
        {
            RegisterDataModel QuotParam = new RegisterDataModel();
            QuotParam = (RegisterDataModel)Convert.ChangeType(model, typeof(RegisterDataModel));

            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_Registration", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 2);
                da.SelectCommand.Parameters.AddWithValue("@UserName", QuotParam.UserName);
                da.SelectCommand.Parameters.AddWithValue("@DepartmentId", QuotParam.DepartmentId);
                da.SelectCommand.Parameters.AddWithValue("@ContectNo", QuotParam.ContectNo);
                da.SelectCommand.Parameters.AddWithValue("@Password", QuotParam.Password);
                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }
    }
}
