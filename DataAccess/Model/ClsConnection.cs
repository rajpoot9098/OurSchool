using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ClsConnection
    {
        public string SqlDBConn()
        {
            return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString.ToString();
        }
    }
}
