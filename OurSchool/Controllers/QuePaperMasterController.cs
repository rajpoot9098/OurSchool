using DataAccess.Model;
using DataAccess.Repository;
using OurSchool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurSchool.Controllers
{
    public class QuePaperMasterController : Controller
    {
        QuestionDataAccess regData;
        // GET: QutPaperMaster
        public ActionResult Index()
        {
            FillFormData();
            FillTableData();

            if (Session["ID"] != null && Convert.ToInt32(Session["ID"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "LogInLogOut");

            }
        }

        private void FillFormData()
        {
            regData = new QuestionDataAccess();
            DataSet ds = regData.GetQuestionPaperLoadData();
            DataTable dt = (DataTable)ds.Tables[0];

            List<OptionType> list = new List<OptionType>();
            list = (from DataRow dr in dt.Rows
                    select new OptionType()
                    {
                        OptionTypeId = Convert.ToInt32(dr["OptionTypeId"].ToString()),
                        OptionTypeDesc = Convert.ToString(dr["OptionTypeDesc"].ToString())
                    }).ToList();

            ViewBag.OptionTypeList = new SelectList(list, "OptionTypeId", "OptionTypeDesc");

            dt = (DataTable)ds.Tables[1];

            List<Subject> listSubject = new List<Subject>();
            listSubject = (from DataRow dr in dt.Rows
                           select new Subject()
                           {
                               SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                               SubjectName = Convert.ToString(dr["SubjectName"].ToString())
                           }).ToList();

            ViewBag.SubjectList = new SelectList(listSubject, "SubjectId", "SubjectName");
        }

        public JsonResult SaveQuestion(QuestionPaperParam model)
        {
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            //DataTable dtparam = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            regData = new QuestionDataAccess();
            DataTable dt = regData.SaveQuestionData(model);

            if (dt != null && dt.Rows.Count > 0)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        private void FillTableData()
        {
            regData = new QuestionDataAccess();
            DataTable dt = regData.GetQuestionPaperSavedData();

            List<PaperDataTable> List = new List<PaperDataTable>();

            List = (from DataRow dr in dt.Rows
                    select new PaperDataTable()
                    {
                        QueId = Convert.ToDouble(dr["QueId"].ToString()),
                        QueNo = Convert.ToString(dr["QueNo"].ToString()),
                        QueDesc = Convert.ToString(dr["QueDesc"].ToString()),
                        SubjectId = Convert.ToDouble(dr["SubjectId"].ToString()),
                        SubjectName = Convert.ToString(dr["SubjectName"].ToString()),
                        OptionTypeId = Convert.ToDouble(dr["OptionTypeId"].ToString()),
                        OptionTypeDesc = Convert.ToString(dr["OptionTypeDesc"].ToString()),
                        AOptionId = Convert.ToDouble(dr["AOptionId"].ToString()),
                        AOptionCode = Convert.ToString(dr["AOptionCode"].ToString()),
                        AOptionDesc = Convert.ToString(dr["AOptionDesc"].ToString()),
                        BOptionId = Convert.ToDouble(dr["BOptionId"].ToString()),
                        BOptionCode = Convert.ToString(dr["BOptionCode"].ToString()),
                        BOptionDesc = Convert.ToString(dr["BOptionDesc"].ToString()),
                        COptionId = Convert.ToDouble(dr["COptionId"].ToString()),
                        COptionCode = Convert.ToString(dr["COptionCode"].ToString()),
                        COptionDesc = Convert.ToString(dr["COptionDesc"].ToString()),
                        DOptionId = Convert.ToDouble(dr["DOptionId"].ToString()),
                        DOptionCode = Convert.ToString(dr["DOptionCode"].ToString()),
                        DOptionDesc = Convert.ToString(dr["DOptionDesc"].ToString()),
                    }).ToList();

            ViewBag.PaperDataTable = List;
        }

    }
}