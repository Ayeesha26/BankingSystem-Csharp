using System;

// Customer class
class Customer
{
    // Attributes
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    // Constructors
    public Customer() { }

    public Customer(int customerID, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
    {
        CustomerID = customerID;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    // Method to print customer details
    public void PrintCustomerDetails()
    {
        Console.WriteLine($"Customer ID: {CustomerID}");
        Console.WriteLine($"Name: {FirstName} {LastName}");
        Console.WriteLine($"Email: {EmailAddress}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Address: {Address}");
    }
}

// Account class
class Account
{
    // Static variable for generating account numbers
    private static long lastAccNo = 1000;

    // Attributes
    public long AccountNumber { get; private set; }
    public string AccountType { get; set; }
    public float Balance { get; set; }
    public Customer Customer { get; set; }

    // Constructor
    public Account(string accountType, Customer customer, float balance = 0)
    {
        AccountNumber = ++lastAccNo;
        AccountType = accountType;
        Balance = balance;
        Customer = customer;
    }

    // Method to print account details
    public void PrintAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Type: {AccountType}");
        Console.WriteLine($"Balance: {Balance}");
        Console.WriteLine("Customer Details:");
        Customer.PrintCustomerDetails();
    }
}

// Child class: SavingsAccount
class SavingsAccount : Account
{
    // Attribute specific to SavingsAccount
    public float InterestRate { get; set; }

    // Constructor
    public SavingsAccount(Customer customer, float interestRate, float balance = 500)
        : base("Savings", customer, balance)
    {
        InterestRate = interestRate;
    }
}

// Child class: CurrentAccount
class CurrentAccount : Account
{
    // Attribute specific to CurrentAccount
    public float OverdraftLimit { get; set; }

    // Constructor
    public CurrentAccount(Customer customer, float overdraftLimit, float balance = 0)
        : base("Current", customer, balance)
    {
        OverdraftLimit = overdraftLimit;
    }
}

// Child class: ZeroBalanceAccount
class ZeroBalanceAccount : Account
{
    // Constructor
    public ZeroBalanceAccount(Customer customer)
        : base("ZeroBalance", customer)
    {
    }
}

// Interface for Customer Service Provider
interface ICustomerServiceProvider
{
    float GetAccountBalance(long accountNumber);
    float Deposit(long accountNumber, float amount);
    float Withdraw(long accountNumber, float amount);
    void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
    void GetAccountDetails(long accountNumber);
}

// Interface for Bank Service Provider
interface IBankServiceProvider : ICustomerServiceProvider
{
    Account[] ListAccounts();
    void CreateAccount(Customer customer, long accNo, string accType, float balance);
    void CalculateInterest();
}

// Implementation class for Customer Service Provider
class CustomerServiceProviderImpl : ICustomerServiceProvider
{
    public float GetAccountBalance(long accountNumber)
    {
        // Implementation to retrieve balance
        throw new NotImplementedException();
    }

    public float Deposit(long accountNumber, float amount)
    {
        // Implementation to deposit
        throw new NotImplementedException();
    }

    public float Withdraw(long accountNumber, float amount)
    {
        // Implementation to withdraw
        throw new NotImplementedException();
    }

    public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
    {
        // Implementation to transfer
        throw new NotImplementedException();
    }

    public void GetAccountDetails(long accountNumber)
    {
        // Implementation to get account details
        throw new NotImplementedException();
    }
}

// Implementation class for Bank Service Provider
class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
{
    private Account[] accountList;
    private string branchName;
    private string branchAddress;

    public BankServiceProviderImpl(string branchName, string branchAddress)
    {
        this.branchName = branchName;
        this.branchAddress = branchAddress;
        accountList = new Account[100]; // Initialize array for accounts
    }

    public Account[] ListAccounts()
    {
        // Implementation to list accounts
        throw new NotImplementedException();
    }

    public void CreateAccount(Customer customer, long accNo, string accType, float balance)
    {
        // Implementation to create account
        throw new NotImplementedException();
    }

    public void CalculateInterest()
    {
        // Implementation to calculate interest
        throw new NotImplementedException();
    }
}

// BankApp class
class BankApp
{
    static void Main(string[] args)
    {
        // Implementation of banking operations
        throw new NotImplementedException();
    }
}
