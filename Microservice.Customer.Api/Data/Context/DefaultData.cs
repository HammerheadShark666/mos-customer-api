namespace Microservice.Customer.Api.Data.Context;

public class DefaultData
{
    public static List<Domain.Customer> GetCustomerDefaultData()
    {
        return
        [
             CreateCustomer(new Guid("6c84d0a3-0c0c-435f-9ae0-4de09247ee15"), "Intergration_Test", "Intergration_Test", "intergration-test-user@example.com"),
             CreateCustomer(new Guid("929eaf82-e4fd-4efe-9cae-ce4d7e32d159"), "Intergration_Test2", "Intergration_Test2", "intergration-test-user2@example.com")
        ];
    }

    private static Domain.Customer CreateCustomer(Guid id, string surname, string firstName, string email)
    {
        return new Domain.Customer { Id = id, Surname = surname, FirstName = firstName, Email = email };
    }
}