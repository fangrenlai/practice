using Com.Practice.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.Practice.DAL.Common
{
    public class CommonMySQLDAL
    {
        public DataSet QueryDataSetBySQL(string dataSQL)
        {
            return DbHelperMySQL.Query(dataSQL);
        }

        public int QueryCountBySQL(string countSQL) 
        {
            return Convert.ToInt32(DbHelperMySQL.Query(countSQL).Tables[0].Rows[0][0]);
        }
    }
}
