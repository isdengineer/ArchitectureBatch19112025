using CustomerManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Services
{
    public class CustomerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(@"Data Source=DESKTOP-ILFSBH1\SQLEXPRESS;Initial Catalog=Customer19112025Batch;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var owner = modelBuilder.Entity<Customer>()
                    .ToTable("tblCustomer");
            owner.OwnsOne(c => c.Amount, m =>
            {
                m.Property(p => p.Value)
                 .HasColumnName("Amount")
                 .HasPrecision(18, 2);                   // decimal(18,2)

                m.WithOwner();
            });
            modelBuilder.Entity<Address>()
                   .ToTable("tblAddress");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
