namespace Microservice.Customer.Api.Helpers;

public class EnvironmentVariables
{
    public static string JwtIssuer = Environment.GetEnvironmentVariable(Constants.JwtIssuer);
    public static string JwtAudience = Environment.GetEnvironmentVariable(Constants.JwtAudience);
    public static string JwtSymmetricSecurityKey = Environment.GetEnvironmentVariable(Constants.JwtSymmetricSecurityKey);
}