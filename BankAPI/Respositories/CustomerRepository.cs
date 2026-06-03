using System.ComponentModel;
using BankAPI.Models;
using MongoDB.Driver;

namespace BankAPI.Repositories;

public class CustomerRepository
{
    private readonly List<Customer> _customers = [];
    private readonly IMongoCollection<Customer> _customersDB;

    public CustomerRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]); // Accessing the BankAPI

        _customersDB = database.GetCollection<Customer>("Customers"); // Equal to a list of the customers 
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _customersDB.Find(_ => true).ToListAsync();
    }

    public Customer? GetCustomerById(int id)
    {
        foreach(Customer cus in _customers)
        {
            if(cus.Id == id)
                return cus;
        }

        // Could return status codes here instead
        return null;
    }

    public Customer? GetCustomerByName(string name)
    {
        foreach(Customer cus in _customers)
        {
            if(cus.Name == name)
                return cus;
        }

        // Could implement error codes
        return null;
    }

    public List<Customer>? GetAllPremiumCustomers()
    {
        const float THRESHOLD = 5000f;
        List<Customer> premiumCustomers = [];

        foreach(var cus in _customers)
        {
            float totalBalance = 0.0f;

            if(cus.Accounts == null)
                continue;
        
            foreach(Account account in cus.Accounts)
            {
                totalBalance += account.Balance;
            }

            if(totalBalance > THRESHOLD)
                premiumCustomers.Add(cus);
        }

        return premiumCustomers;
    }

    public Customer? CreateCustomer(Customer cus)
    {
        _customers.Add(cus);
        return cus;
    }

    public Customer? UpdateCustomer(int id, Customer cus)
    {
        foreach(var customer in _customers)
        {
            if(customer.Id == id)
            {
                customer.Name = cus.Name;
                customer.Email = cus.Email;
                customer.Accounts = cus.Accounts;
                return customer;
            }
        }

        return null;
    }
    
}