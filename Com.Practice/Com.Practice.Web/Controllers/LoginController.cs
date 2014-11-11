using Com.Practice.BLL;
using Com.Practice.Common.Json;
using Com.Practice.Model;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DoLogin()
        {
            // 在DAL中明文写明，只有admin和admin才能登录成功
            string loginName = Request["loginName"];
            string pwd = Request["pwd"];
            LoginBLL loginBLL = new LoginBLL();
            if (loginBLL.CheckLogin(loginName, pwd))
            {
                OnlineUserInfoModel onlineUserInfoModel = new OnlineUserInfoModel();
                
                try
                {
                    onlineUserInfoModel = loginBLL.GetCurrentOnlineUserInfo(loginName);
                }
                catch (Exception e)
                {
                    onlineUserInfoModel = null;
                    return Content("-1");
                }
                finally 
                {
                    Session["CURRENT_ONLINE_USER_INFO"] = JsonUtils.ObjectToJson(onlineUserInfoModel);
                }
                return Content("1");
                // return Content(JsonUtils.ObjectToJson(onlineUserInfoModel));// 通过了验证
            }
            else
            {
                return Content("0");// 没有通过验证
            }


        }

    }
}
