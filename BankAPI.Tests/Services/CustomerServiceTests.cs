using BankAPI.Models;
using BankAPI.Repositories;
using BankAPI.Services;


namespace BankAPI.Tests;

public class CustomerServiceTests
{
    /*
    private CustomerService _customerService;
    private CustomerRepository _customerRepo;

    [SetUp]
    public void Setup()
    {
       // _customerRepo;  // Already initialized with dummy data
        _customerService = new CustomerService(_customerRepo);
    }

    // Function_Passed_ExpectedResult
    [Test]
    public void GetCustomerById_ExistingId_ReturnsCustomer()
    {
        // Arrange/Setup
        int customerId = 1;

        // Act/Call
        Customer? result = _customerService.GetCustomerById(customerId);

        // Assert/Test
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetCustomerById_InvalidId_ReturnsNull()
    {
        int customerId = 10;

        Customer? result = _customerService.GetCustomerById(customerId);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetAllCustomers_ReturnsListOfCustomers()
    {
        List<Customer> result = _customerService.GetAllCustomers();

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetCustomerByName_ValidName_ReturnsValidCustomer()
    {
        string name = "John Wick";

        Customer? result = _customerService.GetCustomerByName(name);

        Assert.That(name, Is.EqualTo(result?.Name));
    }

    [Test]
    public void CreateCustomer_ValidCustomer_ReturnsValidCusotmer()
    {
        Customer testCustomer = new()
        {
            Name = "Sebastian",
            Email = "myEmail.example.com",
            Id = 100
        };

        Customer? result = _customerService.CreateCustomer(testCustomer);

        Assert.That(result, Is.EqualTo(testCustomer));
        Assert.That(result.Name, Is.EqualTo(testCustomer.Name));
        Assert.That(result.Accounts, Is.EqualTo(testCustomer.Accounts));
    }

    [Test]
    public void UpdateCustomer_ValidUpdate_ReturnsValidCustomer()
    {
        Customer oldCustomer = new()
        {
            Name = "Sebastian",
            Email = "myEmail.example.com",
            Id = 100
        };
        Customer? result = _customerService.CreateCustomer(oldCustomer);
        Assert.That(result, Is.EqualTo(oldCustomer));


        Customer newCustomer = new()
        {
            Name = "Marco",
            Email = "marco.example.com",
            Id = 100
        };
        result = _customerService.UpdateCustomer(100, newCustomer);
        Assert.That(result?.Name, Is.EqualTo(newCustomer.Name));
        
    }
    */
}