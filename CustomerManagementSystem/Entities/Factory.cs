using System.Runtime.InteropServices;

namespace CustomerManagementSystem.Entities
{
    public  class FactoryCustomer
    {
        public static CustomerAR Create(string name, decimal amount , 
            List<Address> adds)
        {
            var ar = new CustomerAR(name, amount);
            foreach (var item in adds)
            {
                ar.AddAdress(item);
            }
            return ar;
        }
    }
}
