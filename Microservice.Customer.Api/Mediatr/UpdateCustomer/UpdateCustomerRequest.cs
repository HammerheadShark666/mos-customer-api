using MediatR;

namespace Microservice.Customer.Api.MediatR.AddCustomer;

public record UpdateCustomerRequest(Guid Id, string Email, string Surname, string FirstName) : IRequest<UpdateCustomerResponse>;