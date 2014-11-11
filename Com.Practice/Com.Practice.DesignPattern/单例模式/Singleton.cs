using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.单例模式
{
    public sealed class Singleton// 不能被继承
    {

        private static Singleton instance;
        // 程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();


        private static readonly Singleton instance2 = new Singleton();
        // 构造方法私有，避免外部用new方法来创建实例
        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (null == instance)// 双重锁定,不用线程每次都加锁，而只有当实例未创建的时候才加锁
            {
                lock (syncRoot)// 锁定最先进入的进程对象
                {
                    if (null == instance)
                    {

                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

        public static Singleton GetInstance2() 
        {
            return instance2;
        }
    }
}
