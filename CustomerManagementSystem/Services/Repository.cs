using CustomerManagementSystem.Entities;
using System.Data.SqlClient;

namespace CustomerManagementSystem.Services
{
    public interface IRepository<T>
    {
        bool Save(T entity); // save to DB
        bool Add(T entity); // adds in memory
        List<T> GetAll();
        List<T> GetAll(int id);

    }
    public abstract class RepositoryAbstract<T> : IRepository<T>
    {
        protected List<T> _entities = new List<T>();
        public bool Add(T entity)
        {
            _entities.Add(entity);
            return true;
        }

        public abstract List<T> GetAll();

        public abstract List<T> GetAll(int id);

        public abstract bool Save(T entity);
    }

    //public abstract class AdoDotnet<T> : RepositoryAbstract<T>
    //{
    //    protected SqlConnection cn = null;
    //    protected SqlCommand comm = null;
    //    public override bool Save(T entity)
    //    {
    //        OpenConnection(); // Templater
    //        ExecuteQuery(entity);
    //        CloseConnection();
    //        return true;

    //    }
    //    protected abstract void ExecuteQuery(T entity);
    //    private void OpenConnection()
    //    {
            
    //        cn.Open();
    //    }
    //    private void CloseConnection()
    //    {
    //        cn.Close();
    //    }
    //}
    //public class AdoCustomer : AdoDotnet<Customer>
    //{
    //    public override List<Customer> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override List<Customer> GetAll(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override void ExecuteQuery(Customer entity)
    //    {
    //        comm.CommandText = "insert in to..." + entity.Amount;
    //        comm.ExecuteNonQuery();
    //    }
    //}
    public abstract class EfDotNet<T> : RepositoryAbstract<T>
    {
        protected CustomerDbContext dbcontext = new CustomerDbContext();
        
        
    }
    public class EfCustomer : EfDotNet<Customer>
    {
        public override List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Customer> GetAll(int id)
        {
            return null;
        }

        public override bool Save(Customer entity)
        {
            dbcontext.Customers.Add(entity);
            dbcontext.SaveChanges();
            return true;    
        }
    }

}
