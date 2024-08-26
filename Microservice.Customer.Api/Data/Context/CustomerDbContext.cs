using Microsoft.EntityFrameworkCore;

namespace Microservice.Customer.Api.Data.Context;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Customer> Customer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Customer>().HasData(DefaultData.GetCustomerDefaultData());
    }
}