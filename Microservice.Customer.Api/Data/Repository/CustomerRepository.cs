using Microservice.Customer.Api.Data.Context;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Customer.Api.Data.Repository;

public class CustomerRepository(IDbContextFactory<CustomerDbContext> dbContextFactory) : ICustomerRepository
{
    public async Task UpdateAsync(Domain.Customer entity)
    {
        using var db = dbContextFactory.CreateDbContext();
        db.Customer.Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Domain.Customer?> ByIdAsync(Guid id)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Customer.FindAsync(id);
    }

    public async Task<bool> ExistsAsync(string email)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Customer.AsNoTracking().AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> ExistsAsync(string email, Guid id)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Customer.AsNoTracking().AnyAsync(x => x.Email.Equals(email) && !x.Id.Equals(id));
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Customer.AsNoTracking().AnyAsync(x => x.Id.Equals(id));
    }
}