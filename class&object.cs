using System;

// Customer class
class Customer
{
    // Attributes
    private int customerId;
    private string firstName;
    private string lastName;
    private string emailAddress;
    private string phoneNumber;
    private string address;

    // Constructors
    public Customer() { }

    public Customer(int id, string first, string last, string email, string phone, string addr)
    {
        customerId = id;
        firstName = first;
        lastName = last;
        emailAddress = email;
        phoneNumber = phone;
        address = addr;
    }

    // Getters and Setters
    public int CustomerId
    {
        get { return customerId; }
        set { customerId = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    // Print customer information
    public void PrintInfo()
    {
        Console.WriteLine($"Customer ID: {customerId}");
        Console.WriteLine($"Name: {firstName} {lastName}");
        Console.WriteLine($"Email: {emailAddress}");
        Console.WriteLine($"Phone: {phoneNumber}");
        Console.WriteLine($"Address: {address}");
    }
}

// Account class
class Account
{
    // Attributes
    private int accountNumber;
    private string accountType;
    private double accountBalance;

    // Constructors
    public Account() { }

    public Account(int number, string type, double balance)
    {
        accountNumber = number;
        accountType = type;
        accountBalance = balance;
    }

    // Getters and Setters
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public string AccountType
    {
        get { return accountType; }
        set { accountType = value; }
    }

    public double AccountBalance
    {
        get { return accountBalance; }
        set { accountBalance = value; }
    }

    // Methods
    public void Deposit(double amount)
    {
        accountBalance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {accountBalance}");
    }

    public void Withdraw(double amount)
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
        // Assuming fixed interest rate of 4.5%
        double interest = accountBalance * 0.045;
        accountBalance += interest;
        Console.WriteLine($"Interest calculated and added. New balance: {accountBalance}");
    }

    // Print account information
    public void PrintInfo()
    {
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Account Type: {accountType}");
        Console.WriteLine($"Account Balance: {accountBalance}");
    }
}

// Bank class
class Bank
{
    static void Main(string[] args)
    {
        Account account = new Account(123456, "Savings", 1000);
        Console.WriteLine("Initial Account Information:");
        account.PrintInfo();

        // Deposit
        account.Deposit(500);

        // Withdraw
        account.Withdraw(200);

        // Calculate Interest (for Savings account)
        if (account.AccountType == "Savings")
            account.CalculateInterest();

        Console.WriteLine("\nFinal Account Information:");
        account.PrintInfo();
    }
}
