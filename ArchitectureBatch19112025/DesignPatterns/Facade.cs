using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns
{
    //single, simplified interface to a complex subsystem
    public interface  IFacadeBilling
    {
        void Bill();// facade 
    }
    public class BillingFacade : IFacadeBilling
    {
        public void Bill()
        {
            Inventory g = new Inventory();
            Billing b = new Billing();  
            Accounting a = new Accounting();
            a.DebitCredit();
        }
    }
    public class Accounting // this is not a subsystem (mimic)
    {
        public void DebitCredit()
        {

        }
    }
    public class Billing
    {
        public void Bill()
        {

        }
    }
    public class Inventory
    {
        public void Check()
        {

        }
    }
}
