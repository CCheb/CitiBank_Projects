public class SavingsAccount : Account
{
    private const double interestRate = 0.15f;
    public SavingsAccount(string accountNumber, Customer accountHolder, float balance) 
        : base(accountNumber, accountHolder, balance) {}
    public override void Withdraw(float ammount)
    {
        if(balance - ammount < 100.0f)
        {
            Console.WriteLine("Current balance below 100!");
            return;
        }
        
        balance -= ammount;
        Console.WriteLine($"Current Balance now at: {balance}");
    }
    
}