using System;

// Abstract class: BankAccount
abstract class BankAccount
{
    // Attributes
    protected int accountNumber;
    protected string customerName;
    protected double balance;

    // Constructors
    public BankAccount() { }

    public BankAccount(int accountNumber, string customerName, double balance)
    {
        this.accountNumber = accountNumber;
        this.customerName = customerName;
        this.balance = balance;
    }

    // Getters and setters
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }

    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    // Abstract methods
    public abstract void Deposit(double amount);

    public abstract void Withdraw(double amount);

    public abstract void CalculateInterest();

    // Print account information
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Balance: {balance}");
    }
}

// Concrete class: SavingsAccount
class SavingsAccount : BankAccount
{
    private double interestRate;

    // Constructor
    public SavingsAccount(int accountNumber, string customerName, double balance, double interestRate)
        : base(accountNumber, customerName, balance)
    {
        this.interestRate = interestRate;
    }

    // Public parameterless constructor
    public SavingsAccount() { }

    // Getters and setters
    public double InterestRate
    {
        get { return interestRate; }
        set { interestRate = value; }
    }

    // Implement abstract methods
    public override void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {balance}");
    }

    public override void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public override void CalculateInterest()
    {
        double interest = balance * (interestRate / 100);
        balance += interest;
        Console.WriteLine($"Interest calculated and added. New balance: {balance}");
    }
}

// Concrete class: CurrentAccount
class CurrentAccount : BankAccount
{
    private const double overdraftLimit = 1000; // Example overdraft limit

    // Constructor
    public CurrentAccount(int accountNumber, string customerName, double balance)
        : base(accountNumber, customerName, balance)
    {
    }

    // Public parameterless constructor
    public CurrentAccount() { }

    // Implement abstract methods
    public override void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {balance}");
    }

    public override void Withdraw(double amount)
    {
        double availableBalance = balance + overdraftLimit;
        if (amount <= availableBalance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit.");
        }
    }

    public override void CalculateInterest()
    {
        // Current account does not earn interest
        Console.WriteLine("No interest for current accounts.");
    }
}

// Bank class
class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank!");

        BankAccount account = null;

        Console.WriteLine("Choose account type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Current Account");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                account = CreateAccount<SavingsAccount>();
                break;
            case 2:
                account = CreateAccount<CurrentAccount>();
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
            account.CalculateInterest();
        }
    }

    // Method to create account based on user choice
    static T CreateAccount<T>() where T : BankAccount, new()
    {
        Console.WriteLine("Enter account number:");
        int accNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter customer name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter initial balance:");
        double balance = double.Parse(Console.ReadLine());

        if (typeof(T) == typeof(SavingsAccount))
        {
            Console.WriteLine("Enter interest rate:");
            double interestRate = double.Parse(Console.ReadLine());
            return new T() { AccountNumber = accNumber, CustomerName = name, Balance = balance }; // Here's the corrected line
        }
        else if (typeof(T) == typeof(CurrentAccount))
        {
            return new T() { AccountNumber = accNumber, CustomerName = name, Balance = balance };
        }
        else
        {
            throw new InvalidOperationException("Invalid accounttype.");
        }
    }
}