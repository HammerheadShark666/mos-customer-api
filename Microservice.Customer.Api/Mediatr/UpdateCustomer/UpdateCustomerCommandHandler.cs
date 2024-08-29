using AutoMapper;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers.Exceptions;
using Microservice.Customer.Api.Helpers.Interfaces;

namespace Microservice.Customer.Api.Mediatr.UpdateCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository,
                                          ILogger<UpdateCustomerCommandHandler> logger,
                                          IMapper mapper,
                                          ICustomerHttpAccessor customerHttpAccessor) : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest updateCustomerRequest, CancellationToken cancellationToken)
    {
        var existingCustomer = await customerRepository.ByIdAsync(customerHttpAccessor.CustomerId);
        if (existingCustomer == null)
        {
            logger.LogError("Customer not found - {_customerHttpAccessor.CustomerId}", customerHttpAccessor.CustomerId);
            throw new NotFoundException("Customer not found.");
        }

        existingCustomer = mapper.Map(updateCustomerRequest, existingCustomer);

        await customerRepository.UpdateAsync(existingCustomer);

        return new UpdateCustomerResponse("Customer Updated.");
    }
}