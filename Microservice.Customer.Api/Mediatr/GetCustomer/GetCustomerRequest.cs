using MediatR;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public record GetCustomerRequest(Guid Id) : IRequest<GetCustomerResponse>;