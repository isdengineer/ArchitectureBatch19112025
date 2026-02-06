using CustomerManagementSystem.DTO;
using CustomerManagementSystem.Entities;
using CustomerManagementSystem.Services;
using CustomerManagementSystem.ValueObjects;

namespace CustomerManagementSystem.Application
{
    public class CreateCustomerCommand : ICommand
    {
        public int Id { get; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string User { get; set; }
        public List<Address> Addresses { get; set; }
        public CreateCustomerCommand()
        {
                this.Guid = Guid.NewGuid();
            this.Addresses = new List<Address>();
        }
    }
    
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        public void Handle(CreateCustomerCommand command)
        {
            var ar = FactoryCustomer.Create(command.Name, 
                                            command.Amount,
                                            command.Addresses);
            if (ar.Validate())
            {
                var ent = ar.GetCustomer();
                IRepository<Customer> rep = new EfCustomer();
                rep.Save(ent); // internal
            }
            // Save to Audit( Event sourcing)
            IEventStore<IEvent> eventDb = new SqlServerEventDb();
            foreach (var item in ar.getEvents())
            {
                eventDb.AppendEvent(item);
            }
            // Send to the queue // not there

            // List<Event> evts = ar.getEvents();
            // foreach on events{
            //evnt.AppendEvent(command)
            //}
            // resilency
        }
    }

}
