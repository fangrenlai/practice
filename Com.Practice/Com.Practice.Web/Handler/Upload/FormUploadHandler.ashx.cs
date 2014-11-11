using Com.Practice.Common.Files;
using Com.Practice.Web.Handler.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Com.Practice.Web.Handler.Upload
{
    /// <summary>
    /// FormUploadHandler 的摘要说明
    /// </summary>
    public class FormUploadHandler : IHttpHandler, IReadOnlySessionState
    {
        //IReadOnlySessionState 只读Session
        //IRequiresSessionState 读写Session
        private readonly JavaScriptSerializer js;

        private string StorageRoot
        {
            //d:\visualstudio2012_Projects\com.practice\com.practice.Web\

            //d:\visualstudio2012_Projects\Com.Practice\Com.Practice.Web\
            get { return @"D:/ComPracticeFiles/"; }
            //get { return Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Files/")); } //Path should! always end with '/'
        }

        public FormUploadHandler()
        {
            js = new JavaScriptSerializer();
            js.MaxJsonLength = 41943040;
        }

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");
            //context.Response.AddHeader("Allow", "DELETE");
            HandleMethod(context);
        }

        // Handle request based on method
        private void HandleMethod(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {

                case "HEAD":// IIS出于安全考虑，禁用了DELETE方法，用HEAD代替
                    DeleteFile(context);
                    break;

                case "GET":
                    if (GivenFilename(context))
                    {
                        DeliverFile(context);
                    }
                    else
                    {
                        ListCurrentFiles(context);
                    }
                    break;

                case "POST":
                case "PUT":
                    UploadFile(context);
                    break;

                case "DELETE":// IIS出于安全考虑，禁用了DELETE方法，用HEAD代替

                    break;
                case "OPTIONS":
                    ReturnOptions(context);
                    break;

                default:
                    context.Response.ClearHeaders();
                    context.Response.StatusCode = 405;
                    break;
            }
        }

        private static void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        // Delete file from the server
        private void DeleteFile(HttpContext context)
        {
            var filePath = StorageRoot + context.Request["f"];
            context.Response.AddHeader("Vary", "Accept");
            context.Response.ContentType = "application/json";
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    context.Response.Write(1);
                }
                catch
                {
                    context.Response.Write(0);
                }

            }

        }

        // Upload file to the server
        private void UploadFile(HttpContext context)
        {
            var statuses = new List<FormFilesStatus>();
            var headers = context.Request.Headers;
            // 新文件名的命名根据
            string formData = context.Request.Params["data"];

            if (string.IsNullOrEmpty(headers["X-File-Name"]))
            {
                UploadWholeFile(context, statuses);
            }
            else
            {
                UploadPartialFile(headers["X-File-Name"], context, statuses);
            }

            WriteJsonIframeSafe(context, statuses);
        }

        // Upload partial file
        private void UploadPartialFile(string fileName, HttpContext context, List<FormFilesStatus> statuses)
        {
            if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("文件的个数太多了");
            var inputStream = context.Request.Files[0].InputStream;
            var fullName = StorageRoot + Path.GetFileName(fileName);

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new FormFilesStatus(new FileInfo(fullName)));
        }



        // Upload entire file
        private void UploadWholeFile(HttpContext context, List<FormFilesStatus> statuses)
        {
            // 获取session中取名的根据，比如“三等奖”
            string rootName = HttpContext.Current.Session["FILES_ROOT_NAME"].ToString();
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var file = context.Request.Files[i];
                // 获取新的文件名称，例如“三等奖-201410081513234567.png”
                string newFileName = FilesUtils.RenameFile(file.FileName, rootName);
                var fullPath = StorageRoot + Path.GetFileName(newFileName);

                file.SaveAs(fullPath);

                string fullName = Path.GetFileName(newFileName);
                statuses.Add(new FormFilesStatus(fullName, file.ContentLength, fullPath));
            }
        }

        private void WriteJsonIframeSafe(HttpContext context, List<FormFilesStatus> statuses)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }

            var jsonObj = js.Serialize(statuses.ToArray());
            context.Response.Write(jsonObj);
        }

        private static bool GivenFilename(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Request["f"]);
        }

        private void DeliverFile(HttpContext context)
        {
            var filename = context.Request["f"];
            var filePath = StorageRoot + filename;

            if (File.Exists(filePath))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
                context.Response.StatusCode = 404;
        }

        private void ListCurrentFiles(HttpContext context)
        {
            var folderPath = context.Request["folderPath"];
            var matchExpression = context.Request["matchExpression"];
            var files =
                new DirectoryInfo(folderPath)
                    .GetFiles(matchExpression, SearchOption.TopDirectoryOnly)
                    .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                    .Select(f => new FormFilesStatus(f))
                    .ToArray();

            string jsonObj = js.Serialize(files);
            context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
            context.Response.Write(jsonObj);
            context.Response.ContentType = "application/json";
        }

    }
}