using AutoMapper;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers.Exceptions;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    private ICustomerRepository _customerRepository { get; set; } = customerRepository;
    private IMapper _mapper { get; set; } = mapper;

    public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.ByIdAsync(request.Id);
        if (customer == null)
        {
            throw new NotFoundException("Customer not found.");
        }

        return _mapper.Map<GetCustomerResponse>(customer);
    }
}