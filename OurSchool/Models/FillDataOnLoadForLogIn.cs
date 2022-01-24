using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurSchool.Models
{
    public class OptionType
    {
        public int OptionTypeId { get; set; }
        public string OptionTypeDesc { get; set; }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}