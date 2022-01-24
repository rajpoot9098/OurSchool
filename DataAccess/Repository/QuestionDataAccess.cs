using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class QuestionDataAccess
    {
        DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private ClsConnection constring;
        private SqlConnection con;

        public dynamic GetQuestionPaperLoadData()
        {
            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_QuestionPaper", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 1);
                da.SelectCommand.CommandTimeout = 0;
                ds = new DataSet();
                da.Fill(ds);
            }
            return ds;
        }

        public dynamic SaveQuestionData(QuestionPaperParam model)
        {
            List<OptionParam> lstOptionParam = new List<OptionParam>();
            lstOptionParam = model.lstOptionViewModel;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(lstOptionParam);
            DataTable dtparam = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            dtparam.Columns.RemoveAt(0);
            dtparam.AcceptChanges();

            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_QuestionPaper", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (model.QueId>0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@Ind", 3);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Ind", 2);
                }
                da.SelectCommand.Parameters.AddWithValue("@QueId", model.QueId);
                da.SelectCommand.Parameters.AddWithValue("@QueDesc", model.QueDesc);
                da.SelectCommand.Parameters.AddWithValue("@SubjectId", model.SubjectId);
                da.SelectCommand.Parameters.AddWithValue("@SubjectName", model.SubjectName);
                da.SelectCommand.Parameters.AddWithValue("@OptionTypeId", model.OptionTypeId);
                da.SelectCommand.Parameters.AddWithValue("@OptionTypeDesc", model.OptionTypeDesc);
                da.SelectCommand.Parameters.AddWithValue("@TempOptionTable", dtparam);

                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        public dynamic GetQuestionPaperSavedData()
        {
            constring = new ClsConnection();
            using (con = new SqlConnection(constring.SqlDBConn()))
            {
                da = new SqlDataAdapter("SP_QuestionPaper", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ind", 4);
                da.SelectCommand.CommandTimeout = 0;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }
    }
}
