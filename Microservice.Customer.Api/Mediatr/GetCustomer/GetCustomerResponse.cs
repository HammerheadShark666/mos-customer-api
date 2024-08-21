namespace Microservice.Customer.Api.MediatR.GetCustomer;

public record GetCustomerResponse(string Email, string Surname, string FirstName);