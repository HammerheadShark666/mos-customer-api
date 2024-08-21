using FluentValidation;
using MediatR;
using Microservice.Customer.Api.Data.Repository.Interfaces;
using Microservice.Customer.Api.Helpers;
using Microservice.Customer.Api.Helpers.Interfaces;
using Microservice.Customer.Api.MediatR.AddCustomer;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Reflection;

namespace Microservice.Customer.Api.Test.Unit;

[TestFixture]
public class UpdateCustomerMediatrTests
{
    private Mock<ICustomerRepository> customerRepositoryMock = new();
    private Mock<ICustomerHttpAccessor> customerHttpAccessorMock = new();
    private ServiceCollection services = new();
    private ServiceProvider serviceProvider;
    private IMediator mediator;
    private Guid customerId;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateCustomerCommandHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped<ICustomerRepository>(sp => customerRepositoryMock.Object);
        services.AddScoped<ICustomerHttpAccessor>(sp => customerHttpAccessorMock.Object);
        services.AddAutoMapper(Assembly.GetAssembly(typeof(UpdateCustomerMapper)));

        serviceProvider = services.BuildServiceProvider();
        mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        services.Clear();
        serviceProvider.Dispose();
    }

    [SetUp]
    public void SetUp()
    {
        customerId = Guid.NewGuid();

        customerRepositoryMock
                .Setup(x => x.ExistsAsync(customerId))
                .Returns(Task.FromResult(true));
    }

    [Test]
    public async Task Customer_updated_return_success_message()
    {
        var customerId = Guid.NewGuid();

        var customer = new Domain.Customer() { Id = customerId, Email = "ValidEmail@hotmail.com", Surname = "TestSurname", FirstName = "TestFirstName" };

        customerHttpAccessorMock.Setup(x => x.CustomerId)
            .Returns(customerId);

        customerRepositoryMock
                .Setup(x => x.ByIdAsync(customerId))
                .Returns(Task.FromResult(customer));

        customerRepositoryMock
                .Setup(x => x.ExistsAsync(customerId))
                .Returns(Task.FromResult(true));

        customer.Surname = "Changed Surname";
        customer.FirstName = "Changed FirstName";
        customer.Email = "Changed Email";

        customerRepositoryMock
                .Setup(x => x.UpdateAsync(customer));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "ValidEmail@hotmail.com", "TestSurname", "TestFirstName");

        var actualResult = await mediator.Send(updateCustomerRequest);
        var expectedResult = "Customer Updated.";

        Assert.That(actualResult.message, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Customer_not_updated_id_does_not_exists_return_exception_fail_message()
    {
        customerRepositoryMock
                .Setup(x => x.ExistsAsync(customerId))
                .Returns(Task.FromResult(false));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "ValidEmail@hotmail.com", "TestSurname", "TestFirstName");

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateCustomerRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("The customer does not exists."));
    }

    [Test]
    public void Customer_not_updated_email_exists_return_exception_fail_message()
    {
        customerRepositoryMock
                .Setup(x => x.ExistsAsync("InvalidEmail@hotmail.com", customerId))
                .Returns(Task.FromResult(true));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "InvalidEmail@hotmail.com", "TestSurname", "TestFirstName");

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateCustomerRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Customer with this email already exists"));
    }

    [Test]
    public void Customer_not_updated_invalid_email_return_exception_fail_message()
    {
        customerRepositoryMock
                .Setup(x => x.ExistsAsync("InvalidEmail"))
                .Returns(Task.FromResult(false));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "InvalidEmail", "TestSurname", "TestFirstName");

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateCustomerRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Invalid Email."));
    }

    [Test]
    public void Customer_not_updated_invalid_surname_firstname_return_exception_fail_message()
    {
        customerRepositoryMock
                .Setup(x => x.ExistsAsync("ValidEmail@hotmail.com"))
                .Returns(Task.FromResult(false));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "ValidEmail@hotmail.com", "TestSurnameTestSurnameTestSurnameTestSurnameTestSurnameTestSurname", "TestFirstNameTestFirstNameTestFirstNameTestFirstNameTestFirstName");

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateCustomerRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(2));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Surname length between 1 and 30."));
        Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("First name length between 1 and 30."));
    }

    [Test]
    public void Customer_not_updated_no_email_surname_firstname_return_exception_fail_message()
    {
        customerRepositoryMock
                .Setup(x => x.ExistsAsync("ValidEmail@hotmail.com"))
                .Returns(Task.FromResult(false));

        var updateCustomerRequest = new UpdateCustomerRequest(customerId, "", "", "");

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateCustomerRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(7));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Email is required."));
        Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("Email length between 8 and 150."));
        Assert.That(validationException.Errors.ElementAt(2).ErrorMessage, Is.EqualTo("Invalid Email."));
        Assert.That(validationException.Errors.ElementAt(3).ErrorMessage, Is.EqualTo("Surname is required."));
        Assert.That(validationException.Errors.ElementAt(4).ErrorMessage, Is.EqualTo("Surname length between 1 and 30."));
        Assert.That(validationException.Errors.ElementAt(5).ErrorMessage, Is.EqualTo("First name is required."));
        Assert.That(validationException.Errors.ElementAt(6).ErrorMessage, Is.EqualTo("First name length between 1 and 30."));
    }
}