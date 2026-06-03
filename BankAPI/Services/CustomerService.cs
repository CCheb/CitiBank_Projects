using System.Runtime.CompilerServices;
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

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _customerRepo.GetCustomerById(id);
    }

    public async Task<Customer?> GetCustomerByName(string name)
    {
        return await _customerRepo.GetCustomerByName(name);
    }

    public async Task<List<Customer>?> GetAllPremiumCustomers()
    {
        return await _customerRepo.GetAllPremiumCustomers();
    }

    public async Task<Customer?> CreateCustomer(Customer cus)
    {
        // Validation here
        return await _customerRepo.CreateCustomer(cus);

    }

    public async Task<Customer?> UpdateCustomer(int id, Customer cus)
    {
        return await _customerRepo.UpdateCustomer(id, cus);
    }
}