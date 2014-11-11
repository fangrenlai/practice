using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    public class UploadController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormUpload()
        {
            return View();
        }

        public ActionResult SaveFormData()
        {
            string name1 = Request["name1"].ToString();
            string name2 = Request["name2"].ToString();
            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {
                return Json(new { result = 2, data = "数据不完整" });
            }
            else
            {
                try
                {
                    string name = name1 + name2;
                    Session["FILES_ROOT_NAME"] = name;
                    return Json(new { result = 1, data = name });
                }
                catch (Exception e)
                {
                    return Json(new { result = 2, data = e.Message });
                }

            }
        }

    }
}