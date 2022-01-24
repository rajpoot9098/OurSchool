using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class RegisterDataModel
    {
        public double SRNO { get; set; }

        public double RecordNo { get; set; }

        public string UserName { get; set; }

        public string UserCode { get; set; }

        public string DepartmentName { get; set; }

        public int DepartmentId { get; set; }

        public double ContectNo { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class lstRegisterDataModel
    {
        public List<RegisterDataModel> lstRegisterData { get; set; }
    }
}
