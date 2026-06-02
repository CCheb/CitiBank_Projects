public class Customer
{
    private static uint customerID = 0;
    private string firstName;
    private string lastName;
    private List<Account>? accounts;

    public Customer(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        incrementCustomerID();
        accounts = [];
    }

    public void AddAccount(Account type)
    {
        accounts?.Add(type);
    }

    public (string, string) GetName()
    {
        return (firstName, lastName);
    }
    public void PrintCustomerInfo()
    {
        Console.WriteLine($"First name: {firstName} Last name: {lastName} CustomerID: {customerID}");
        Console.WriteLine($"Number of accounts: {accounts?.Count()}");
        Console.WriteLine();
    }

    public void CreateAccount()
    {   
        CreateAccountOptions selectedOption = CreateAccountOptions.Checking;
        
        Console.Clear();
        Console.WriteLine(
        "What type of account do you want to create? \n" +
        "0) Checking \n" +
        "1) Savings \n" +
        "2) Nothing");

        string? input = Console.ReadLine();
        selectedOption = Enum.Parse<CreateAccountOptions>(input);

        Random randNumbers = new();
        switch(selectedOption)
        {
            case CreateAccountOptions.Checking:
                AddAccount(new CheckingAccount(randNumbers.Next(1000, 2000).ToString(), this, 0.0f));
                Console.WriteLine("Sucessfully Created Checking account!");
                break;
            case CreateAccountOptions.Savings:
                AddAccount(new SavingsAccount(randNumbers.Next(1000, 2000).ToString(), this, 0.0f));
                Console.WriteLine("Sucessfully Created Savings account!");
                break;
            case CreateAccountOptions.None:
                break;
            default:
                Console.WriteLine("Invalid input, please try again");
                break;
        }
    }

    public void ViewAccounts()
    {   
        Console.Clear();
        if(accounts == null)
        {
            Console.WriteLine("This customer has no active accounts");
            return;
        }

        foreach(var account in accounts)
        {
            account.PrintReceipt();
        }
    }
    

    private static void incrementCustomerID()
    {
        customerID++;
    }

}