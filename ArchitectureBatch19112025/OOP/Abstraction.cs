using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.OOP
{
   public interface IRepo // abstraction
    {
        bool Save(object o);
        List<object> GetAll(); // Abstractly
        bool Update();
        bool Something()
        {
            // common code
            return true;
        }
    }
    public interface IRepoDelete
    {
        bool Delete(object o);
    }
    public abstract class CommonRepo : IRepo, IRepoDelete
    {
        public string ConnectionString { get; set; }
        public bool Delete(object o)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(object o)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
    public class SqlServerRepo : CommonRepo , 
        IRepoDelete, IRepo
    {
      
    }


    public interface ICustomer
    {
         string Name { get; set; }
    }
    public interface ICustomerPaid : ICustomer
    {
        decimal BillAmount { get; set; }
       

    }
    public class Enquiry : ICustomerPaid
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal BillAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Disptach()
        {
            throw new NotImplementedException("NA");
        }
    }
}
