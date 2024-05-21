using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.util
{
    internal class DBConnUtil
    {
        String constr = DBPropertyUtil.conString();

        public SqlConnection conObj()
        {
            var con = new SqlConnection(constr);
            return con;
        }
    }
}
