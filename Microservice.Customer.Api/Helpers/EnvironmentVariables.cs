// Ignore Spelling: Jwt

namespace Microservice.Customer.Api.Helpers;

public class EnvironmentVariables
{
    public static string JwtIssuer = Environment.GetEnvironmentVariable(Constants.JwtIssuer) ?? "Environment Variable JwtIssuer not found.";
    public static string JwtAudience = Environment.GetEnvironmentVariable(Constants.JwtAudience) ?? "Environment Variable JwtAudience not found.";
    public static string JwtSymmetricSecurityKey = Environment.GetEnvironmentVariable(Constants.JwtSymmetricSecurityKey) ?? "Environment Variable JwtSymmetricSecurityKey not found.";
}