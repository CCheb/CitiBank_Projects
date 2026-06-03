using Microsoft.AspNetCore.Mvc;
using BankAPI.Models;
using BankAPI.Services;

namespace BankAPI.Controllers;


[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _customerService.GetAllCustomers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerById(id);
        // This might return null so we can return error codes!
        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("search")]
    public async Task<ActionResult<Customer>> GetCustomerByName(string name)
    {   
        var customer = await _customerService.GetCustomerByName(name);
        // This might return null so we can return error codes!

        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("premium")]
    public async Task<ActionResult<List<Customer>>> GetAllPremiumCustomers()
    {
        List<Customer>? premiumCustomers = await _customerService.GetAllPremiumCustomers();

        if(premiumCustomers == null)
            return NotFound();
        
        return Ok(premiumCustomers);
    } 

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer cus)
    {
        Customer? customer = await _customerService.CreateCustomer(cus);
        if(customer == null)
            return NoContent();

        return Ok(customer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer cus)
    {
        Customer? customer = await _customerService.UpdateCustomer(id, cus);
        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        Customer? deletedCustomer = await _customerService.DeleteCustomer(id);
        if(deletedCustomer == null)
            return NotFound();

        return Ok(deletedCustomer);
    }

}