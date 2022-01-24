using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurSchool.Models
{
    public class PaperDataTable
    {
        public double QueId { get; set; }
        public string QueNo { get; set; }
        public string QueDesc { get; set; }
        public double SubjectId { get; set; }
        public string SubjectName { get; set; }
        public double OptionTypeId { get; set; }
        public string OptionTypeDesc { get; set; }
        public double AOptionId { get; set; }
        public string AOptionCode { get; set; }
        public string AOptionDesc { get; set; }
        public double BOptionId { get; set; }
        public string BOptionCode { get; set; }
        public string BOptionDesc { get; set; }
        public double COptionId { get; set; }
        public string COptionCode { get; set; }
        public string COptionDesc { get; set; }
        public double DOptionId { get; set; }
        public string DOptionCode { get; set; }
        public string DOptionDesc { get; set; }
    }
}