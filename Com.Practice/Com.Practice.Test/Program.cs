using Com.Practice.Test.Extend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.Practice.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(FilesUtilsTest.RenameFile("222.png","frl"));
            //FilesUtilsTest.GetFiles(@"D:/ComPracticeFiles/");

            //FileInfo[] allFiles = null;
            //try
            //{
            //    allFiles = FilesUtilsTest.GetFiles(@"D:/ComPracticeFiles/", "frl-*.*");
            //    foreach (FileInfo file in allFiles)
            //    {
            //        Console.WriteLine(file.FullName);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("出错了：" + e.Message);
            //}
            //Console.ReadKey();

            //Son s = new Son();
            //s.Do();
            //string cd = "";
            //int i = 0;
            //try { i = Convert.ToInt32(cd); }
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //Console.WriteLine(i);

            if (FilesUtilsTest.TempRename("010XHZ000115", "1144"))
            {
                Console.WriteLine("succeed");
            }
            else 
            {
                Console.WriteLine("failed");
            }



            Console.ReadKey();

        }

    }
}
