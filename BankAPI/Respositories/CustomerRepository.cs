using System.ComponentModel;
using BankAPI.Models;

namespace BankAPI.Repositories;

public class CustomerRepository
{
    private readonly List<Customer> _customers = [];

    public CustomerRepository()
    {
        Random randValues = new();
        _customers.Add(new Customer
        {
            Id = 1,
            Name = "John Doe",
            Email = "Doe@example.com",
            Accounts = [
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000)),
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000))
            ]
        });

        _customers.Add(new Customer
        {
            Id = 2,
            Name = "John Wick",
            Email = "Wick@example.com",
            Accounts = [
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000)),
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000))
            ]
        });

        _customers.Add(new Customer
        {
            Id = 3,
            Name = "John Smith",
            Email = "Smith@example.com",
            Accounts = [
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000)),
                new Account(randValues.Next(100, 200), randValues.Next(1000, 2000).ToString(), randValues.Next(500, 10000))
            ]
        });
    }
    // Add functionalities simulating access to a database here

    public List<Customer> GetAllCustomers()
    {
        return _customers;
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