using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.模板方法
{
    public class TestPaperB : TestPaper
    {

        protected override string Answer1()
        {
            return "B";
        }

        protected override string Answer2()
        {
            return "B";
        }

        protected override string Answer3()
        {
            return "C";
        }
    }
}
