/*
BankApp: Single flor console application
Main -> Welcome message -> Authentication/Authorization
*/
public class Program
{
    // Flow control
    public static void Main(string[] args)
    {
        List<Customer> customers = InitializeCustomers();
        
        Welcome();

        MenuOptions selectedOption = MenuOptions.DEBUG;
        Customer selectedCustomer = customers[0];

        while(selectedOption != MenuOptions.Exit)
        {
            Console.WriteLine("Selected Customer " + selectedCustomer.GetName().Item1 + " " + selectedCustomer.GetName().Item2);
            Console.WriteLine(
                "------------------ \n" +
                "|Select an option|: \n"+
                "------------------ \n" +
                "0) Create Account \n"+
                "1) View All Accounts \n"+
                "2) Deposit \n"+
                "3) Withdraw \n"+
                "4) Transfer \n"+
                "5) Close Account \n"+
                "6) Exit \n");

            string? input = Console.ReadLine();

            selectedOption= Enum.Parse<MenuOptions>(input);

            switch(selectedOption)
            {
                case MenuOptions.CreateAccount:
                    selectedCustomer.CreateAccount();
                    break;
                case MenuOptions.ViewAllAccounts:
                    selectedCustomer.ViewAccounts();
                    break;
                case MenuOptions.Deposit:
                    Console.WriteLine("Depositing");
                    break;
                case MenuOptions.Withdraw:
                    Console.WriteLine("Withdrawing");
                    break;
                case MenuOptions.Transfer:
                    Console.WriteLine("Transfering");
                    break;
                case MenuOptions.CloseAccount:
                    Console.WriteLine("Closing Account");
                    break;
                case MenuOptions.Exit:
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again");
                    break;
            }

            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine();

        }

        Console.WriteLine("Exited Successfully!");

    }

    public static List<Customer> InitializeCustomers(int customerCount = 3)
    {   
        List<Customer> customers = new();

        // Create X customers
        for(int i = 0; i < customerCount; i++)
            customers.Add(new Customer($"John {i}", "Doe"));

        // Give each customer a Checking and Savings account
        Random randNumbers = new();
        foreach(var customer in customers)
        {
            customer.AddAccount(new CheckingAccount(
                randNumbers.Next(1000, 2000).ToString(), customer, randNumbers.Next(500, 2000)));
             customer.AddAccount(new SavingsAccount(
                randNumbers.Next(1000, 2000).ToString(), customer, randNumbers.Next(500, 2000)));
        }

        return customers;
    }

    private static void Welcome()
    {
        Console.Clear();
        Console.WriteLine("Welcome to ABC Digital Bank");
        Console.WriteLine("---------------------------");
        Console.WriteLine();
    }
}