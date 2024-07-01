using AutoMapper;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers.Exceptions;
using Microservice.Customer.Api.Helpers.Interfaces;

namespace Microservice.Customer.Api.MediatR.AddCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository, 
                                          IMapper mapper, ICustomerHttpAccessor customerHttpAccessor) : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
    private ICustomerRepository _customerRepository { get; set; } = customerRepository;
    private IMapper _mapper { get; set; } = mapper;
    private ICustomerHttpAccessor _customerHttpAccessor { get; set; } = customerHttpAccessor;

    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest updateCustomerRequest, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.ByIdAsync(_customerHttpAccessor.CustomerId);
        if (existingCustomer == null)
            throw new NotFoundException("Customer not found.");

        existingCustomer = _mapper.Map(updateCustomerRequest, existingCustomer); 

        await _customerRepository.UpdateAsync(existingCustomer);

        return new UpdateCustomerResponse("Customer Updated.");
    }
}