using CustomerManagementSystem.ValueObjects;

namespace CustomerManagementSystem.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                if (value.Length == 0)
                {
                    throw new Exception("name is required");
                }
                _name = value; 
            }
        }

        public RecMoney  Amount { get; set; }
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }
       
    }
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
    }
}
