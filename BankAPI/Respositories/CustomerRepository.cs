using BankAPI.Models;
using MongoDB.Driver;

namespace BankAPI.Repositories;

public class CustomerRepository
{
    private readonly List<Customer> _customers = [];
    private readonly IMongoCollection<Customer> _customersDB;   // Query interface to a remote database

    public CustomerRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]); // Accessing the BankAPI

        _customersDB = database.GetCollection<Customer>("Customers"); // Equal to a list of the customers 
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _customersDB.Find(_ => true).ToListAsync();
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        // Find the customer within the Customer collection (_customerDB) where its id matches the passed id
        // If not then return null;
        return await _customersDB.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerByName(string name)
    {
        return await _customersDB.Find(c => c.Name == name).FirstOrDefaultAsync();
    }

    public async Task<List<Customer>?> GetAllPremiumCustomers()
    {
        const float THRESHOLD = 5000f;
        List<Customer> premiumCustomers = [];
        var customers = await _customersDB.Find(_ => true).ToListAsync();

        foreach(var cus in customers)
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

    public async Task<Customer?> CreateCustomer(Customer cus)
    {
        await _customersDB.InsertOneAsync(cus);

        return cus;
    }

    public async Task<Customer?> UpdateCustomer(int id, Customer cus)
    {
        var result = await _customersDB.ReplaceOneAsync(c => c.Id == id, cus);

        if (result.MatchedCount == 0)
            return null;

        return cus;
    }

    public async Task<Customer?> DeleteCustomer(int id)
    {
        var customer = await _customersDB.Find(c => c.Id == id).FirstOrDefaultAsync();

        if (customer == null)
            return null;

        await _customersDB.DeleteOneAsync(c => c.Id == id);

        return customer;
    }
    
}