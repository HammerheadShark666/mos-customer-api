namespace Microservice.Customer.Api.Data.Repository.Interfaces;

public interface ICustomerRepository
{
    Task UpdateAsync(Domain.Customer entity);
    Task<Domain.Customer?> ByIdAsync(Guid id);
    Task<bool> ExistsAsync(string email);
    Task<bool> ExistsAsync(string email, Guid id);
    Task<bool> ExistsAsync(Guid id);
}