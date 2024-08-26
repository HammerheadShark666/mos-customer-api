using AutoMapper;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers.Exceptions;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerQueryHandler(ICustomerRepository customerRepository,
                                     ILogger<GetCustomerQueryHandler> logger,
                                     IMapper mapper) : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    private ICustomerRepository _customerRepository { get; set; } = customerRepository;
    private IMapper _mapper { get; set; } = mapper;
    private ILogger<GetCustomerQueryHandler> _logger { get; set; } = logger;

    public async Task<GetCustomerResponse> Handle(GetCustomerRequest getCustomerRequest, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.ByIdAsync(getCustomerRequest.Id);
        if (customer == null)
        {
            _logger.LogError($"Customer not found - { getCustomerRequest.Id }");
            throw new NotFoundException("Customer not found.");
        }

        return _mapper.Map<GetCustomerResponse>(customer);
    }
}