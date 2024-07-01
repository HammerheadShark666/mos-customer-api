using Microservice.Customer.Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Customer.Api.Data.Contexts;

public class CustomerDbContext : DbContext
{ 
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
 
    public DbSet<Domain.Customer> Customer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

		modelBuilder.Entity<Domain.Customer>().HasData(DefaultData.GetCustomerDefaultData());  
    }
}