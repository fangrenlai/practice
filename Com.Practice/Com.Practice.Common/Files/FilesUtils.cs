using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Common.Files
{
    public class FilesUtils
    {
        public static string RenameFile(string oldName, string rootName)
        {
            string newName = "";
            if (string.IsNullOrEmpty(oldName) || string.IsNullOrEmpty(rootName))
            {
                throw new Exception("传入值不正确");
            }
            else
            {
                try
                {
                    // 取得原文件的后缀名
                    string[] arr = oldName.Split('.');
                    // 获得新的文件名
                    DateTime dt = DateTime.Now;
                    newName = rootName + "-" + dt.ToFileTime() + "." + arr[arr.Length - 1];
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return newName;
        }
    }
}
