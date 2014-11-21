using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.Practice.Test
{
    public class FilesUtilsTest
    {

        /// <summary>
        /// 临时方法，批量将之前的客户代码命名的图片改成id命名
        /// </summary>
        /// <param name="cstCode"></param>
        /// <param name="cstId"></param>
        /// <returns></returns>
        public static bool TempRename(string cstCode, string cstId)
        {
            bool result = false;
            try
            {
                List<string> pathList = new List<string>();
                pathList.Add(@"C:\UploadedFile\Customer\BusLic\");
                pathList.Add(@"C:\UploadedFile\Customer\LegRepReg\");
                pathList.Add(@"C:\UploadedFile\Customer\TaxReg\");
                foreach (string folderPath in pathList)
                {
                    DirectoryInfo folder = new DirectoryInfo(folderPath);
                    foreach (FileInfo file in folder.GetFiles(cstCode + "-*.*"))
                    {
                        // C:\UploadedFile\Customer\BusLic\021XHD000115-130601434673098343.png
                        string oldFullName = file.FullName;
                        string newFullName = oldFullName.Replace(cstCode, cstId);
                        File.Move(oldFullName, newFullName);

                    }
                }
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("批量重命名名称时出错：" + e.Message);
                throw new Exception("批量重命名名称时出错：" + e.Message);
            }
            return result;
        }

        public static void EditRenameName(string cstCode)
        {
            try
            {
                List<string> pathList = new List<string>();
                pathList.Add(@"C:\UploadedFile\Customer\BusLic\");
                pathList.Add(@"C:\UploadedFile\Customer\LegRepReg\");
                pathList.Add(@"C:\UploadedFile\Customer\TaxReg\");
                string newValue = cstCode.Substring(0, 6);
                string matchExp = cstCode.Substring(6, 6);
                foreach (string folderPath in pathList)
                {
                    DirectoryInfo folder = new DirectoryInfo(folderPath);
                    foreach (FileInfo file in folder.GetFiles("*" + matchExp + "-*.*"))
                    {
                        // C:\UploadedFile\Customer\BusLic\021XHD000115-130601434673098343.png
                        string oldFullName = file.FullName;
                        string oldValue = oldFullName.Substring(oldFullName.LastIndexOf(@"\") + 1, 6);
                        string newFullName = oldFullName.Replace(oldValue, newValue);
                        if (oldFullName == newFullName) { }
                        else
                        {
                            File.Copy(oldFullName, newFullName, true);
                            File.Delete(oldFullName);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static string RenameFile(string oldName, string rootName)
        {
            string newName = "";
            if (string.IsNullOrEmpty(oldName) || string.IsNullOrEmpty(rootName))
            {
                throw new Exception("传入值不正fdsad确");
            }
            else
            {
                try
                {
                    // 取得原文件的后缀名
                    //string[] arr = oldName.Split('.');
                    // 获得新的文件名
                    DateTime dt = DateTime.Now;
                    string extName = Path.GetExtension(oldName);
                    newName = rootName + "-" + dt.ToFileTime() + extName;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return newName;
        }


        public static void GetFiles(string folderPath)
        {

            DirectoryInfo folder = new DirectoryInfo(folderPath);

            foreach (FileInfo file in folder.GetFiles("frl-*.*"))
            {
                Console.WriteLine(file.FullName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath">@"D:/ComPracticeFiles/"</param>
        /// <param name="matchExpression">"frl-*.*"</param>
        /// <returns></returns>
        public static FileInfo[] GetFiles(string folderPath, string matchExpression)
        {
            DirectoryInfo folder = null;
            FileInfo[] fileArr = null;
            try
            {
                folder = new DirectoryInfo(folderPath);
                fileArr = folder.GetFiles(matchExpression);
                if (0 < fileArr.Length)
                {
                    return fileArr;
                }
                else
                {
                    throw new Exception("没有相关的文件");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
