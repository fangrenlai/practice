using Com.Practice.BLL;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    /// <summary>
    /// 角色管理控制器
    /// at2014年11月21日09:31:17
    /// by方仁来
    /// </summary>
    public class RoleController : Controller
    {
        /// <summary>
        /// 跳转到主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 按查询条件获取分页信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSpecificRolesByPage()
        {
            int page = null == Request["page"] ? 0 : Convert.ToInt32(Request["page"]);
            int rows = null == Request["rows"] ? 0 : Convert.ToInt32(Request["rows"]);
            string queryName = null == Request["query_name"] ? "" : Request["query_name"].ToString();
            if (0 == page || 0 == rows)
            {
                throw new Exception("分页查询参数错误");
            }
            else
            {
                PaginationModel pageModel = new PaginationModel(page, rows, "", "");
                RoleBLL roleBLL = null;
                try
                {
                    roleBLL = new RoleBLL();
                    string dataStr = roleBLL.GetSpecificDataJsonStr(pageModel, queryName);
                    return Content(dataStr);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// 添加一条记录信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRole()
        {

            return null;
        }

        /// <summary>
        /// 更新一条记录信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRole()
        {

            return null;
        }

        /// <summary>
        /// 删除若干条角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteRoles()
        {

            return null;
        }

        //

    }
}
