using Com.Practice.Common.Json;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/

        public ActionResult IndexTop()
        {
            return View();
        }
        public ActionResult IndexFoot()
        {
            return View();
        }
        public ActionResult IndexLeft()
        {
            return View();
        }
        public ActionResult IndexMain()
        {
            return View();
        }

        /// <summary>
        /// 获取当前在线用户的信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCurrentUserInfo()
        {
            OnlineUserInfoModel onlineUserInfoModel = new OnlineUserInfoModel();
            string onlineUserInfoString = Session["CURRENT_ONLINE_USER_INFO"].ToString();
            if (string.IsNullOrEmpty(onlineUserInfoString))
            {
                return Json(new { result = -1, msg = "获取不到当前用户信息，请重新登录" });
            }
            else
            {
                onlineUserInfoModel = (OnlineUserInfoModel)JsonUtils.JsonToObject(onlineUserInfoString, onlineUserInfoModel);
                //return Json(new { result = 1, msg = onlineUserInfoString }, JsonRequestBehavior.AllowGet);
                return Json(onlineUserInfoModel, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
