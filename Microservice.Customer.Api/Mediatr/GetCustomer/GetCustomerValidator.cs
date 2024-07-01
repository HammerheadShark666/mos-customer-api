using FluentValidation;
using Microservice.Customer.Api.Data.Repository.Interfaces;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerValidator : AbstractValidator<GetCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}