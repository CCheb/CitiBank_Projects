namespace BankAPI.Models;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public List<Account>? Accounts { get; set; }

}