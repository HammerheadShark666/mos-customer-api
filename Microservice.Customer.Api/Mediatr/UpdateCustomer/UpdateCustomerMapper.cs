using AutoMapper;

namespace Microservice.Customer.Api.Mediatr.UpdateCustomer;

public class UpdateCustomerMapper : Profile
{
    public UpdateCustomerMapper()
    {
        CreateMap<UpdateCustomerRequest, Domain.Customer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(x => x.Email, act => act.MapFrom(src => src.Email))
            .ForMember(x => x.Surname, act => act.MapFrom(src => src.Surname))
            .ForMember(x => x.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(m => m.LastUpdated, o => o.MapFrom(s => DateTime.Now));
    }
}