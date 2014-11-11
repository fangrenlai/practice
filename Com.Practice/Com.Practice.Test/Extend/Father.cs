using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.Test.Extend
{
    public abstract class Father
    {
        public virtual string GetValue() {

            return "Father";
        }

        public void Do() {

            Console.WriteLine(GetValue());
            Console.ReadKey();
        }
    }
}
