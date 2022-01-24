using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ExamPaperParam
    {
        public int QueId { get; set; }
        public string QueNo { get; set; }
        public string QueDesc { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int OptionTypeId { get; set; }
        public string OptionTypeDesc { get; set; }
        public int AOptionId { get; set; }
        public string AOptionCode { get; set; }
        public string AOptionDesc { get; set; }
        public int BOptionId { get; set; }
        public string BOptionCode { get; set; }
        public string BOptionDesc { get; set; }
        public int COptionId { get; set; }
        public string COptionCode { get; set; }
        public string COptionDesc { get; set; }
        public int DOptionId { get; set; }
        public string DOptionCode { get; set; }
        public string DOptionDesc { get; set; }
    }
}
