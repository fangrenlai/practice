using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.DesignPattern.代理模式
{
    public class ActualHandler :IGiveGift
    {
        public void GiveDolls()
        {
            Console.WriteLine("ActualHandler GiveDolls");
        }

        public void GiveFlowers()
        {
            Console.WriteLine("ActualHandler GiveFlowers");
        }

        public void GiveChocolate()
        {
            Console.WriteLine("ActualHandler GiveChocolate");
        }
    }
}
