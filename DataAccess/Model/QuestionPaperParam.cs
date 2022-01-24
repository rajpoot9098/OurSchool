using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class QuestionPaperParam
    {
        public int QueId { get; set; }
        public string QueNo { get; set; }
        public string QueDesc { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int OptionTypeId { get; set; }
        public string OptionTypeDesc { get; set; }
        public List<OptionParam> lstOptionViewModel { get; set; }
    }

    public class OptionParam
    {
        public int OptionId { get; set; }
        public int QueId { get; set; }
        public string OptionCode { get; set; }
        public string OptionDesc { get; set; }
    }
}
