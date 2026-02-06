using CustomerManagementSystem.Entities;
using CustomerManagementSystem.ValueObjects;
using System.Diagnostics.Eventing.Reader;

namespace CustomerManagementSystem.Application
{
    public interface IEvent
    {
        public int Id { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        Guid guid { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        int Version { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        string eventType { get; set; }

    }
    public class CreateCustomerEvent : IEvent 
    {
        public string Name { get; set; }
        public RecMoney Amount { get; set; }
        public int Id  { get; set; } 
        public Guid guid { get; set; }
        public int Version { get; set; }
        public string eventType { get; set; }
        public CreateCustomerEvent()
        {
            this.eventType = "CreateCustomer";
        }
    }
    public class CreateAddressEvent : IEvent
    {
        public string NameStreet1 { get; set; }
        public int Id { get; set; }
        public Guid guid { get; set; }
        public int Version { get; set; }
        public string eventType { get; set; }
        public CreateAddressEvent()
        {
            this.eventType = "CreateAddress";

        }
    }
    //public interface IEventStore<T>
    //{
    //    List<IEvent> GetEvents(Guid aggregateId);
    //    List<IEvent> GetEvents();

    //    bool AppendEvent(T e);
    //}
}
