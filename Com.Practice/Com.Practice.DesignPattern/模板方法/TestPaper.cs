using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.模板方法
{
    public abstract class TestPaper
    {
        public void Question1()
        {

            Console.WriteLine("第1个问题。");
            Console.WriteLine("答案：" + Answer1());
        }

        public void Question2()
        {

            Console.WriteLine("第2个问题。");
            Console.WriteLine("答案：" + Answer2());
        }

        public void Question3()
        {

            Console.WriteLine("第3个问题。");
            Console.WriteLine("答案：" + Answer3());
        }

        protected virtual string Answer1()
        {
            return "";
        }

        protected virtual string Answer2()
        {
            return "";
        }

        protected virtual string Answer3()
        {
            return "";
        }
    }
}
