using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DIandIOC
{
    public class Supplier
    {
        public string SupplierName { get; set; }
        public decimal Amount { get; set; }
        public int Age { get; set; }
        private IDiscount dis = null;
        public Supplier(IDiscount _dis)
        {
            dis = _dis;
        }
        public decimal CalculateDiscount()
        {
            return dis.CalculateDiscount(this);
        }
    }
    public interface IDiscount
    {
        public decimal CalculateDiscount(Supplier obj);
    }
    public class SeniorDiscount : IDiscount
    {
        public decimal CalculateDiscount(Supplier obj)
        {
            //if(obj.Age>90)
            return 10;
        }
    }
    public class AmountLimit : IDiscount
    {
        public decimal CalculateDiscount(Supplier obj)
        {
            //if(obj.Amount>90000)
            return 80;
        }
    }
}
