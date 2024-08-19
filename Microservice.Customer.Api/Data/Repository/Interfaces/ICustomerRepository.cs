namespace Microservice.Customer.Api.Data.Repository.Interfaces;

public interface ICustomerRepository
{
    Task<Domain.Customer> AddAsync(Domain.Customer customer);
    Task UpdateAsync(Domain.Customer entity);
    Task<IEnumerable<Domain.Customer>> AllAsync();
    Task<Domain.Customer> ByIdAsync(Guid id);
    Task<bool> ExistsAsync(string email);
    Task<bool> ExistsAsync(string email, Guid id);
    Task<bool> ExistsAsync(Guid id);
}