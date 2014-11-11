using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Com.Practice.Web.Handler.Uploadify
{
    /// <summary>
    /// UploadifyHandler 的摘要说明
    /// </summary>
    public class UploadifyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            HandlerMethod(context);

        }

        private void HandlerMethod(HttpContext context)
        {
            // 此处不用接受文件列表，每次上传一个文件，已经做好了循环遍历的操作
            HttpPostedFile oFile = context.Request.Files["Filedata"];
            string strUploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";

            if (oFile != null)
            {
                if (!Directory.Exists(strUploadPath))
                {
                    Directory.CreateDirectory(strUploadPath);
                }
                oFile.SaveAs(strUploadPath + oFile.FileName);
                //context.Response.Write("{\"result\":" + 1 + ",\"data\":~/UploadifyFiles/" + oFile.FileName + "}");
                context.Response.Write("/UploadifyFiles/"+oFile.FileName);
            }
            else
            {
                // context.Response.Write("{\"result\":" + 0 + ",\"data\":\"上传失败\"}");
                context.Response.Write("上传失败");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}