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
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //
        public ActionResult GetUsersByPage()
        {
            int page = 0;
            int rows = 0;
            string sort = "";
            string order = "";
            string queryLoginName = "";
            string nickName = "";
            UserBLL userBLL = null;
            try
            {
                // page=1&rows=10&sort=UserName&order=desc
                page = null == Request["page"] ? 0 : Convert.ToInt32(Request["page"].ToString());// 当前第？页
                rows = null == Request["rows"] ? 0 : Convert.ToInt32(Request["rows"].ToString());// 每页显示？条数据
                sort = null == Request["sort"] ? "" : Request["sort"].ToString();
                order = null == Request["order"] ? "" : Request["order"].ToString();
                queryLoginName = null == Request["query_login_name"] ? "" : Request["query_login_name"].ToString();
                nickName = null == Request["nick_name"] ? "" : Request["nick_name"].ToString();
                userBLL = new UserBLL();
                UserQueryModel queryModel = new UserQueryModel();
                queryModel.NickName = nickName;
                queryModel.QueryLoginName = queryLoginName;
                PaginationModel paginationModel = new PaginationModel(page, rows, sort, order);
                string pageDataStr = userBLL.GetUsersByPage(paginationModel, queryModel);
                return Content(pageDataStr);

            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        //
        public ActionResult GetUserAuth()
        {
            string result = "";
            int paramId = null == Request["id"] ? 0 : Convert.ToInt32(Request["id"]);
            int userId = null == Request["userId"] ? 0 : Convert.ToInt32(Request["userId"]);
            UserBLL userBLL = null;
            try
            {
                userBLL = new UserBLL();
                result = userBLL.GetNodeInfo(userId, paramId);
                return Content(result);
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }
        }

        //
        public ActionResult GetUserRoles()
        {
            string result = "";
            int id = null == Request["id"] ? 0 : Convert.ToInt32(Request["id"]);
            int userId = null == Request["userId"] ? 0 : Convert.ToInt32(Request["userId"]);
            UserBLL userBLL = null;
            try
            {
                userBLL = new UserBLL();
                result = userBLL.GetUserRoles(userId, id);
                return Content(result);
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }
        }


        //
        public ActionResult SaveRoleConfig()
        {
            string ids = null == Request["ids"] ? "" : Request["id"].ToString();
            int userId = null == Request["userId"] ? 0 : Convert.ToInt32(Request["userId"]);
            UserBLL userBLL = null;
            if (0 == userId)
            {
                return Json(new { result = -1, msg = "用户id角色为空" });
            }
            else
            {
                try
                {
                    userBLL = new UserBLL();
                    if (userBLL.MergeUserRoles(userId, ids))
                    {
                        return Json(new { result = 1, msg = "保存/更新角色信息成功" });
                    }
                    else 
                    {
                        return Json(new { result = -1, msg = "数据库操作遇到错误" });
                    }
                }
                catch (Exception e)
                {
                    return Json(new { result = -1, msg = e.Message });
                }
            }
        }


        //

    }
}
