using System.Security.Claims;

namespace Microservice.Customer.Api.Helpers;

public class CustomerHttpAccessor(IHttpContextAccessor accessor) : Interfaces.ICustomerHttpAccessor
{
    public Guid CustomerId
    {
        get
        {
            if (accessor == null || accessor.HttpContext == null || accessor.HttpContext.User == null)
                throw new ArgumentNullException("IHttpContextAccessor not found.");

            var customerId = accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return customerId == null ? throw new ArgumentNullException("NameIdentifier not found with customer Id.") : new(customerId);
        }
    }
}