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
    public class LogInLogOutController : Controller
    {
        LogInDataAccess regData;
        // GET: LogInLogOut
        public ActionResult Index()
        {
            Session["ID"] = 0;
            Session["UserName"] = "";
            return View();
        }

        public JsonResult UserLogin(LoginParam model)
        {
            regData = new LogInDataAccess();
            DataTable dt = regData.LogInUser(model);

            if (dt != null && dt.Rows.Count > 0)
            {
                Session["ID"] = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }


    }
}