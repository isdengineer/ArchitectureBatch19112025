using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DIandIOC
{
    public  class SomeTask
    {
        public Action callBack = null;
        public bool CallMe()
        {
            var rn = new Random();
            if (rn.Next(5) > 3)
            {
                callBack();
                return true;
              
            }
            return false;
        }
    }
    // client Code for IOC
    //static void Main(string[] args)
    //{
    //    var t = new SomeTask();

    //    t.callBack = new Action(SomeMethod);
    //    t.CallMe();
    //    Console.WriteLine("Finished");

    //}
    //static void SomeMethod()
    //{
    //    Console.WriteLine("Some method");

    //}
}
