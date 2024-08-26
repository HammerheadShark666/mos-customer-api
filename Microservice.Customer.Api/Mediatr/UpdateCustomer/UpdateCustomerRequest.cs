using MediatR;

namespace Microservice.Customer.Api.Mediatr.UpdateCustomer;

public record UpdateCustomerRequest(Guid Id, string Email, string Surname, string FirstName) : IRequest<UpdateCustomerResponse>;