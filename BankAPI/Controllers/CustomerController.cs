using Microsoft.AspNetCore.Mvc;
using BankAPI.Models;
using BankAPI.Services;
using System.Runtime.CompilerServices;

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
    public List<Customer> GetAllCustomers()
    {
        return _customerService.GetAllCustomers();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomerById(int id)
    {
        var customer = _customerService.GetCustomerById(id);
        // This might return null so we can return error codes!
        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("search")]
    public ActionResult<Customer> GetCustomerByName(string name)
    {   
        var customer = _customerService.GetCustomerByName(name);
        // This might return null so we can return error codes!

        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("premium")]
    public ActionResult<List<Customer>> GetAllPremiumCustomers()
    {
        List<Customer>? premiumCustomers = _customerService.GetAllPremiumCustomers();

        if(premiumCustomers == null)
            return NotFound();
        
        return Ok(premiumCustomers);
    } 

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer cus)
    {
        Customer? customer = _customerService.CreateCustomer(cus);
        if(customer == null)
            return NoContent();

        return Ok(customer);
    }

    [HttpPut("{id}")]
    public ActionResult<Customer> UpdateCustomer(int id, Customer cus)
    {
        Customer? customer = _customerService.UpdateCustomer(id, cus);
        if(customer == null)
            return NotFound();

        return Ok(customer);
    }

}