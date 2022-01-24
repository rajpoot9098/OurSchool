using DataAccess.Model;
using DataAccess.Repository;
using OurSchool.Models;
using OurSchool.Models.RegistrationModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurSchool.Controllers
{
    public class UserRegistrationController : Controller
    {
        RegistrationDataAccess regData;
        //
        // GET: /UserRegistration/
        public ActionResult Index()
        {
            FillFormData();
            FillTableData();
            return View();
        }

        private void FillFormData()
        {
            regData = new RegistrationDataAccess();
            DataTable dt = regData.GetDepartmentData();

            List<Department> list = new List<Department>();
            list = (from DataRow dr in dt.Rows
                    select new Department()
                    {
                        DepartmentId = Convert.ToInt32(dr["DepartmentId"].ToString()),
                        DepartmentName = Convert.ToString(dr["DepartmentName"].ToString())
                    }).ToList();


            //List<Department> list = (List<Department>)Convert.ChangeType(regData.GetDepartmentData(), typeof(List<Department>));

            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");
        }

        [HttpPost]
        public JsonResult RegisterUser(RegisterDataModel model)
        {
            regData = new RegistrationDataAccess();
            DataTable dt = regData.SaveRegistration(model);

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["SuccssCode"].ToString() == "1")
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
            regData = new RegistrationDataAccess();
            DataTable dt = regData.GetRegistrationData();

            List<RegisterDataModel> List = new List<RegisterDataModel>();

            List = (from DataRow dr in dt.Rows
                    select new RegisterDataModel()
                    {
                        SRNO = Convert.ToDouble(dr["SRNO"].ToString()),
                        RecordNo = Convert.ToDouble(dr["RecordNo"].ToString()),
                        UserCode = Convert.ToString(dr["UserCode"].ToString()),
                        UserName = Convert.ToString(dr["UserName"].ToString()),
                        DepartmentId = Convert.ToInt32(dr["DepartmentId"].ToString()),
                        DepartmentName = Convert.ToString(dr["DepartmentName"].ToString()),
                        ContectNo = Convert.ToDouble(dr["ContectNo"].ToString()),
                        Password = Convert.ToString(dr["Password"].ToString())
                    }).ToList();

            ViewBag.RegisterDataModel = List;
        }

    }
}