using System.Security.Claims;

namespace Microservice.Customer.Api.Helpers;

public class CustomerHttpAccessor : Interfaces.ICustomerHttpAccessor
{
    private readonly IHttpContextAccessor _accessor;
    public CustomerHttpAccessor(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public Guid CustomerId => new(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
}
