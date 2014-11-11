using Com.Practice.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenuTree()
        {
            string menuId = null == Request["id"] ? "" : Request["id"].ToString();
            MenuBLL menuBLL = null;
            string jsonStr = "";
            try
            {
                menuBLL = new MenuBLL();
                jsonStr = menuBLL.GetMenuTreeJsonStr(menuId);
                return Content(jsonStr);
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
