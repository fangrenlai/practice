using Com.Practice.DesignPattern.代理模式;
using Com.Practice.DesignPattern.单例模式;
using Com.Practice.DesignPattern.简单工厂;
using Com.Practice.DesignPattern.模板方法;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern
{
    public class Test
    {
        public static void Main()
        {

            // 代理模式测试------START
            //ProxyHandler proxyHandler = new ProxyHandler();
            //proxyHandler.GiveDolls();
            //proxyHandler.GiveFlowers();
            //proxyHandler.GiveChocolate();
            // 代理模式测试------END
            // 模板方法测试------START
            //TestPaper studentA = new TestPaperA();
            //studentA.Question1();
            //studentA.Question2();
            //studentA.Question3();
            //TestPaper studentB = new TestPaperB();
            //studentB.Question1();
            //studentB.Question2();
            //studentB.Question3();
            //// 模板方法测试------END
            // 简单工厂测试------START
            //Operation opera = OperationFactory.CreateOperation("+");
            //opera.NumberA = 10;
            //opera.NumberB = 2;
            //Console.WriteLine("计算的结果为：" + opera.GetResult());
            // 简单工厂测试------END

            // 单例模式测试------START
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例");
            }
            // 单例模式测试------END
            Console.ReadKey();
        }
    }
}
