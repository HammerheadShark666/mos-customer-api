// Ignore Spelling: Jwt

using Microservice.Customer.Api.Helpers.Exceptions;

namespace Microservice.Customer.Api.Helpers;

public class EnvironmentVariables
{
    public static string JwtIssuer => GetEnvironmentVariable(Constants.JwtIssuer);
    public static string JwtAudience => GetEnvironmentVariable(Constants.JwtAudience);
    public static string JwtSymmetricSecurityKey => GetEnvironmentVariable(Constants.JwtSymmetricSecurityKey);
    public static string AzureUserAssignedManagedIdentityClientId => GetEnvironmentVariable(Constants.AzureUserAssignedManagedIdentityClientId);
    public static string LocalDevelopmentClientId => GetEnvironmentVariable(Constants.AzureLocalDevelopmentClientId);
    public static string LocalDevelopmentClientSecret => GetEnvironmentVariable(Constants.AzureLocalDevelopmentClientSecret);
    public static string LocalDevelopmentTenantId => GetEnvironmentVariable(Constants.AzureLocalDevelopmentTenantId);

    public static string GetEnvironmentVariable(string name)
    {
        var variable = Environment.GetEnvironmentVariable(name);

        if (string.IsNullOrEmpty(variable))
            throw new EnvironmentVariableNotFoundException($"Environment Variable Not Found: {name}.");

        return variable;
    }
}