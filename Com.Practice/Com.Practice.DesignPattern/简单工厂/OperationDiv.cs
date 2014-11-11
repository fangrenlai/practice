using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.简单工厂
{
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (0 == NumberB)
            {
                throw new Exception("出书不能为0！");
            }
            else { result = NumberA / NumberB; }

            return result;
        }
    }
}
