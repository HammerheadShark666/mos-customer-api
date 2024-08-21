using FluentValidation;
using Microservice.Customer.Api.Data.Repository.Interfaces;

namespace Microservice.Customer.Api.MediatR.AddCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;

        RuleFor(updateCustomerRequest => updateCustomerRequest).MustAsync(async (updateCustomerRequest, cancellation) =>
        {
            return await CustomerExists(updateCustomerRequest.Id);
        })
        .WithMessage(x => $"The customer does not exists.");

        RuleFor(updateCustomerRequest => updateCustomerRequest.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Length(8, 150).WithMessage("Email length between 8 and 150.")
                .EmailAddress().WithMessage("Invalid Email.");

        RuleFor(updateCustomerRequest => updateCustomerRequest).MustAsync(async (updateCustomerRequest, cancellation) =>
        {
            return await EmailExists(updateCustomerRequest);
        }).WithMessage("Customer with this email already exists");

        RuleFor(updateCustomerRequest => updateCustomerRequest.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Length(1, 30).WithMessage("Surname length between 1 and 30.");

        RuleFor(updateCustomerRequest => updateCustomerRequest.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 30).WithMessage("First name length between 1 and 30.");
    }

    protected async Task<bool> EmailExists(UpdateCustomerRequest updateCustomerRequest)
    {
        return !await _customerRepository.ExistsAsync(updateCustomerRequest.Email, updateCustomerRequest.Id);
    }

    protected async Task<bool> CustomerExists(Guid customerId)
    {
        return await _customerRepository.ExistsAsync(customerId);
    }
}