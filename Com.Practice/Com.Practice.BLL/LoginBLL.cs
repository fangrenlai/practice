using Com.Practice.DAL;
using Com.Practice.Model;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.BLL
{
    public class LoginBLL
    {
        public bool CheckLogin(string loginName, string pwd)
        {
            bool result = false;

            if ("admin".Equals(loginName) && "admin".Equals(pwd))// 验证密码的正确性
            {
                result = true;
            }
            else
            {

            }
            return result;
        }

        public OnlineUserInfoModel GetCurrentOnlineUserInfo(string loginName)
        {
            UserBLL userBLL = new UserBLL();
            OnlineUserInfoModel onlineUserModel = new OnlineUserInfoModel();
            UserModel userModel = new UserModel();
            try 
            {
                userModel = userBLL.GetModel(loginName);
                onlineUserModel.UserModel = userModel;
            }
            catch(Exception e){
                onlineUserModel = null;
                throw e;
            }
            finally{}
            return onlineUserModel;
        }
    }
}
