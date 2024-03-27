using System;

// Account class
class Account
{
    // Attributes
    protected int accountNumber;
    protected string accountType;
    protected double accountBalance;

    // Constructors
    public Account() { }

    public Account(int number, string type, double balance)
    {
        accountNumber = number;
        accountType = type;
        accountBalance = balance;
    }

    // Methods
    public virtual void Deposit(double amount)
    {
        accountBalance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {accountBalance}");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= accountBalance)
        {
            accountBalance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {accountBalance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    // Print account information
    public void PrintInfo()
    {
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Account Type: {accountType}");
        Console.WriteLine($"Account Balance: {accountBalance}");
    }
}

// SavingsAccount class
class SavingsAccount : Account
{
    private double interestRate;

    public SavingsAccount(int number, string type, double balance, double rate) : base(number, type, balance)
    {
        interestRate = rate;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= accountBalance)
        {
            accountBalance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {accountBalance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public void CalculateInterest()
    {
        double interest = accountBalance * (interestRate / 100);
        accountBalance += interest;
        Console.WriteLine($"Interest calculated and added. New balance: {accountBalance}");
    }
}

// CurrentAccount class
class CurrentAccount : Account
{
    private double overdraftLimit;
    private const double MAX_OVERDRAFT_LIMIT = 1000; // Example overdraft limit

    public CurrentAccount(int number, string type, double balance, double limit) : base(number, type, balance)
    {
        overdraftLimit = limit;
    }

    public override void Withdraw(double amount)
    {
        double availableBalance = accountBalance + overdraftLimit;
        if (amount <= availableBalance)
        {
            accountBalance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {accountBalance}");
        }
        else
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit.");
        }
    }
}

// Bank class
class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank!");

        Account account = null;

        Console.WriteLine("Choose account type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Current Account");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                account = new SavingsAccount(123456, "Savings", 1000, 4.5);
                break;
            case 2:
                account = new CurrentAccount(789012, "Current", 2000, 500);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        if (account != null)
        {
            Console.WriteLine("\nInitial Account Information:");
            account.PrintInfo();

            // Deposit
            account.Deposit(500.0);

            // Withdraw
            account.Withdraw(300.0);

            // Printing final account information
            Console.WriteLine("\nFinal Account Information:");
            account.PrintInfo();

            // Calculate Interest (for Savings account)
            if (account is SavingsAccount)
            {
                Console.WriteLine("\nCalculating interest for Savings Account:");
                ((SavingsAccount)account).CalculateInterest();
                Console.WriteLine("Updated Account Information:");
                account.PrintInfo();
            }
        }
    }
}
