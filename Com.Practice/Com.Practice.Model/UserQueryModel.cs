using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Model
{
    public class UserQueryModel
    {
        
        private string queryLoginName;

        public string QueryLoginName
        {
            get { return queryLoginName; }
            set { queryLoginName = value; }
        }
        private string nickName;

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
    }
}
