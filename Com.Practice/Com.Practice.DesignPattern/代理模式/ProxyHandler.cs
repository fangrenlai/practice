using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.代理模式
{
    public class ProxyHandler : IGiveGift
    {
        ActualHandler actualHandler;

        /// <summary>
        /// 在这里，代理方法实际借用了实际方法
        /// 表面上是代理方法，实际用的是代理方法
        /// </summary>
        public ProxyHandler() {

            actualHandler = new ActualHandler();
        }

        public void GiveDolls()
        {
            actualHandler.GiveDolls();
        }

        public void GiveFlowers()
        {
            actualHandler.GiveFlowers();
        }

        public void GiveChocolate()
        {
            actualHandler.GiveChocolate();
        }
    }
}
