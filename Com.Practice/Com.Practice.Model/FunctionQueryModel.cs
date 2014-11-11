using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Model
{
    /// <summary>
    /// 功能查询条件实体类
    /// </summary>
    public class FunctionQueryModel
    {
        private int queryId;

        public int QueryId
        {
            get { return queryId; }
            set { queryId = value; }
        }

        private string queryCode;

        public string QueryCode
        {
            get { return queryCode; }
            set { queryCode = value; }
        }

        private string queryName;

        public string QueryName
        {
            get { return queryName; }
            set { queryName = value; }
        }

        private string queryCreateStartTime;

        public string QueryCreateStartTime
        {
            get { return queryCreateStartTime; }
            set { queryCreateStartTime = value; }
        }

        private string queryCreateEndTime;

        public string QueryCreateEndTime
        {
            get { return queryCreateEndTime; }
            set { queryCreateEndTime = value; }
        }

    }
}
