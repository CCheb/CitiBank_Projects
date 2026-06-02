namespace BankAPI.Models;

public class Account
{
    public int Id { get; set; }
    public string? AccountNumber { get; set; }
    public float Balance { get; set; }

    public Account(int iD, string accountNumber, float balance)
    {
        Id = iD;
        AccountNumber = accountNumber;
        Balance = balance;
    }
}