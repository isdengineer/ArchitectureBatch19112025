using CustomerManagementSystem.Application;
using CustomerManagementSystem.Entities;
using CustomerManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<CustomerDbContext>(options =>
            //               options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));
            //builder.Services.AddDbContext<EventDbContext>(options =>
            //               options.UseSqlServer(builder.Configuration.GetConnectionString("Audit")));
            //builder.Services.AddScoped<IRepository<Customer>, EfCustomer>();
            //builder.Services.AddScoped<IEventStore<IEvent>, SqlServerEventDb>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
