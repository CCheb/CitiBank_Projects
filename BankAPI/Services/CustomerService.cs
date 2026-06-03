using BankAPI.Models;
using BankAPI.Repositories;

namespace BankAPI.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepo;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepo = customerRepository;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _customerRepo.GetAllCustomers();
    }

    public Customer? GetCustomerById(int id)
    {
        return _customerRepo.GetCustomerById(id);
    }

    public Customer? GetCustomerByName(string name)
    {
        return _customerRepo.GetCustomerByName(name);
    }

    public List<Customer>? GetAllPremiumCustomers()
    {
        return _customerRepo.GetAllPremiumCustomers();
    }

    public Customer? CreateCustomer(Customer cus)
    {
        // Validation here
        return _customerRepo.CreateCustomer(cus);

    }

    public Customer? UpdateCustomer(int id, Customer cus)
    {
        return _customerRepo.UpdateCustomer(id, cus);
    }
}