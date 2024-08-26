using System.Security.Claims;

namespace Microservice.Customer.Api.Helpers;

public class CustomerHttpAccessor(IHttpContextAccessor accessor) : Interfaces.ICustomerHttpAccessor
{
    private readonly IHttpContextAccessor _accessor = accessor;

    public Guid CustomerId => new(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
}
