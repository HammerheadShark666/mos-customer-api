namespace Microservice.Customer.Api.Data.Context;

public class DefaultData
{
    public static List<Domain.Customer> GetCustomerDefaultData()
    {
        return new List<Domain.Customer>()
        {
            CreateCustomer(new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), "Hopkins", "Jane", "jhopkins@hotmail.com"),
            CreateCustomer(new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"), "James", "Arthur", "jarthur@hotmail.com"),
            CreateCustomer(new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), "Patel", "Mohammed", "pmohammed@hotmail.com"),
            CreateCustomer(new Guid("2385de72-2302-4ced-866a-fa199116ca6e"), "Mateal", "Sam", "smateal@hotmail.com"),
            CreateCustomer(new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), "Abertson", "Tanya", "tabertson@hotmail.com"),
            CreateCustomer(new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), "Tansor", "Steven", "stansor@hotmail.com"),
            CreateCustomer(new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), "Orton", "Beth", "borton@hotmail.com"),
            CreateCustomer(new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "Amos", "Tori", "tamos@hotmail.com"),
            CreateCustomer(new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "Page", "James", "jpage@hotmail.com"),
            CreateCustomer(new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"), "Osbourne", "John", "josbourne@hotmail.com") 
        };
    }

    private static Domain.Customer CreateCustomer(Guid id, string surname, string firstName, string email)
    {
        return new Domain.Customer { Id = id, Surname = surname, FirstName = firstName, Email = email };
    }
}