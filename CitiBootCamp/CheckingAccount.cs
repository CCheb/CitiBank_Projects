public class CheckingAccount : Account
{
    private const float overDraftLimit = -500f;
    public CheckingAccount(string accountNumber, Customer accountHolder, float balance) 
        : base(accountNumber, accountHolder, balance) {}

    public override void Withdraw(float ammount)
    {
        if(balance - ammount > overDraftLimit)
        {
            Console.WriteLine("Went beyond Over Draft Limit");
            return;
        }

        balance -= ammount;
        Console.WriteLine($"Current Balance now at: {balance}");
    }
}