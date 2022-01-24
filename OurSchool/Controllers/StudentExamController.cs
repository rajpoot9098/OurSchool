using DataAccess.Repository;
using Newtonsoft.Json;
using OurSchool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurSchool.Controllers
{
    public class StudentExamController : Controller
    {
        // GET: StudentExam
        public ActionResult StudentExamPaper()
        {
            FillFormData();
            return View();
        }
        QuestionDataAccess regData;
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

        public JsonResult GetQuestion(ExamPaperViewModel model)
        {
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            //DataTable dtparam = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            //regData = new QuestionDataAccess();
            //DataTable dt = regData.SaveQuestionData(model);

            model.QueId = 1;
            model.QueNo = "1001";
            model.QueDesc = "Captal Of India?";
            model.SubjectId = 2;
            model.SubjectName = "English";
            model.OptionTypeId = 1;
            model.OptionTypeDesc = "Single";
            model.AOptionId = 1;
            model.AOptionCode = "A";
            model.AOptionDesc = "Mumbail";
            model.BOptionId = 2;
            model.BOptionCode = "B";
            model.BOptionDesc = "Delhi";
            model.COptionId = 3;
            model.COptionCode = "C";
            model.COptionDesc = "Bhopal";
            model.DOptionId = 4;
            model.DOptionCode = "D";
            model.DOptionDesc = "Indore";

            //string json = JsonConvert.SerializeObject(model);

            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}