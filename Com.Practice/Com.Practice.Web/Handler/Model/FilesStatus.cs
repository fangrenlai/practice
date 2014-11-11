using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Web.Handler.Model
{
    public class FilesStatus
    {
        public const string HandlerPath = "/Handler/Upload/";

        public string group { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string progress { get; set; }
        public string url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_url { get; set; }
        public string delete_type { get; set; }
        public string error { get; set; }

        public FilesStatus() { }

        public FilesStatus(FileInfo fileInfo) { SetValues(fileInfo.Name, (int)fileInfo.Length, fileInfo.FullName); }

        public FilesStatus(string fileName, int fileLength, string fullPath) { SetValues(fileName, fileLength, fullPath); }

        private void SetValues(string fileName, int fileLength, string fullPath)
        {
            name = fileName;
            type = "image/png";
            size = fileLength;
            progress = "1.0";
            url = HandlerPath + "UploadHandler.ashx?f=" + fileName;
            delete_url = HandlerPath + "UploadHandler.ashx?f=" + fileName;
            delete_type = "HEAD";// IIS出于安全考虑，禁用了DELETE方法，用HEAD代替
            var ext = Path.GetExtension(fullPath);

            //var fileSize = ConvertBytesToMegabytes(new FileInfo(fullPath).Length);
            //if (fileSize > 3 || !IsImage(ext)) { 
            if (!IsImage(ext))
            { 
                // 如果不是图片类型的文件，就用通用文件缩略图展示
                thumbnail_url = "/Images/generalFile.png"; 
            } 
            else { 
                // 缩略图
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath); 
            }
        }

        private bool IsImage(string ext)
        {
            return ext == ".gif" || ext == ".jpg" || ext == ".png";
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
