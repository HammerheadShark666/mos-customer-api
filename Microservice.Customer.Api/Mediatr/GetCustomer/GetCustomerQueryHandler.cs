using AutoMapper;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers.Exceptions;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerQueryHandler(ICustomerRepository customerRepository,
                                     ILogger<GetCustomerQueryHandler> logger,
                                     IMapper mapper) : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    public async Task<GetCustomerResponse> Handle(GetCustomerRequest getCustomerRequest, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.ByIdAsync(getCustomerRequest.Id);
        if (customer == null)
        {
            logger.LogError("Customer not found - {getCustomerRequest.Id}", getCustomerRequest.Id);
            throw new NotFoundException("Customer not found.");
        }

        return mapper.Map<GetCustomerResponse>(customer);
    }
}