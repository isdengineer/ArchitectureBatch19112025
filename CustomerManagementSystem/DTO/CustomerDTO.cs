using CustomerManagementSystem.Entities;

namespace CustomerManagementSystem.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Amount { get; set; }
        public List<Address> Addresses { get; set; }
        public CustomerDTO()
        {
            this.Addresses = new List<Address>();
        }
    }
    public class AddressDto 
    {

        public string Street1 { get; set; }

    }
}
