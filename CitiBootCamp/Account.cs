public abstract class Account : ITransaction
{
    protected string accountNumber;
    protected Customer accountHolder;
    protected float balance;


    public Account(string accountNumber, Customer accountHolder, float balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Account Number: {accountNumber} | Type: {GetType().Name}");
        Console.WriteLine($"Balance: ${balance}");
        Console.WriteLine($"Account holder: {accountHolder.GetName().Item1} {accountHolder.GetName().Item2}");
        Console.WriteLine("---------------------------------------");
    }


    public virtual void Deposit(float ammount)
    {
        
    }

    public abstract void Withdraw(float ammount);
}