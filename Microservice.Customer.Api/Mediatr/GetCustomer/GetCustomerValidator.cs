using FluentValidation;
using Microservice.Customer.Api.Data.Repository.Interfaces;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerValidator(ICustomerRepository customerRepository) : AbstractValidator<GetCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
}