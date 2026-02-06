using CustomerManagementSystem.Application;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.Services
{
    public interface IEventStore<T>
    {
        List<IEventRecord> GetEvents(Guid aggregateId);
        List<IEventRecord> GetEvents();

        bool AppendEvent(T e);
    }
    public interface IEventRecord : IEvent
    {

        string eventData { get; set; }

    }
    public class EventRecord : IEventRecord
    {
        [Key]
        public int Id { get; set; }
        public Guid guid { get; set; }
        public int Version { get; set; }
        public string eventType { get; set; }
        public string eventData { get; set; }
        public string Status { get; set; }
        public EventRecord()
        {
            Status = "Created";
        }
    }
    public class SqlServerEventDb : IEventStore<IEvent>
    {
        EventDbContext _db = new EventDbContext();
       
        public bool AppendEvent(IEvent e)
        {
            //var lastEvent = _db.EventRecords
            //                        .Where(e1 => e1.guid == e.guid)
            //                        .MaxBy(r1 => r1.Version);
            var er = new EventRecord()
            {
                guid = e.guid,
                eventType = e.eventType,
                //Version = (lastEvent?.Version ?? 0) + 1,
                eventData = JsonConvert.SerializeObject(e)
            };


            _db.EventRecords.Add(er);
            _db.SaveChanges();
            return true;
        }

        public List<IEventRecord> GetEvents(Guid aggregateId)
        {
            return (List<IEventRecord>)
                _db.EventRecords.Where(e => e.guid == aggregateId);
        }

        public List<IEventRecord> GetEvents()
        {
            return _db.EventRecords.ToList<IEventRecord>();

        }
    }
    public class EventDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
               UseSqlServer(@"Data Source=DESKTOP-ILFSBH1\SQLEXPRESS;Initial Catalog=CustomerEventDB19112025Batch;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRecord>().ToTable("tblEvent");
        }
        public DbSet<EventRecord> EventRecords { get; set; }
    }
}
