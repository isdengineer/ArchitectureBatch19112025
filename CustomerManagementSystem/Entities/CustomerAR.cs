using CustomerManagementSystem.Application;
using CustomerManagementSystem.ValueObjects;

namespace CustomerManagementSystem.Entities
{
    public class CustomerAR
    {
        private Customer _customer = null;
        private List<IEvent> events = new List<IEvent>();

        public void Delete()
        {
            // delete event add
        }
        public  List<IEvent> getEvents()
        {
            return events.ToList<IEvent>();
        }
        public Customer GetCustomer()
        {
            return _customer;
        }
        public CustomerAR(string name , decimal amount)
        {
            _customer = new Customer();
            _customer.Name = name;
            _customer.Amount = new RecMoney(amount);
            _customer.Addresses = new List<Address>();
            // add to event collection
            events.Add(new CreateCustomerEvent() { Name = name , Amount = _customer.Amount });
        }
        public bool Validate()
        {
            return true;
        }
        public bool AddAdress(Address obj)
        {
            if (this._customer.Addresses.Count > 3)
            {
                throw new Exception("can not go above 3");
            }
            this._customer.Addresses.Add(obj);
            events.Add(new CreateAddressEvent() { NameStreet1 = obj.Street1 });
            return true;
        }
    }
}
