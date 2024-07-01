using AutoMapper;

namespace Microservice.Customer.Api.MediatR.GetCustomer;

public class GetCustomerMapper : Profile
{
    public GetCustomerMapper()
    {
        base.CreateMap<Api.Domain.Customer, GetCustomerResponse>(); 
    }
}