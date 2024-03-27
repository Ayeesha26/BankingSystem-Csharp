using System;
using System.Collections.Generic;

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
    // Attributes
    public long AccountNumber { get; private set; }
    public string AccountType { get; set; }
    public float Balance { get; set; }
    public Customer Customer { get; set; }

    // Static variable to generate unique account numbers
    private static long nextAccountNumber = 1001;

    // Constructors
    public Account() { }

    public Account(string accountType, float balance, Customer customer)
    {
        AccountNumber = GenerateAccountNumber();
        AccountType = accountType;
        Balance = balance;
        Customer = customer;
    }

    // Method to generate unique account numbers
    private long GenerateAccountNumber()
    {
        return nextAccountNumber++;
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

// Bank class
class Bank
{
    private List<Account> accounts = new List<Account>();

    // Method to create a new bank account
    public void CreateAccount(Customer customer, string accType, float balance)
    {
        Account account = new Account(accType, balance, customer);
        accounts.Add(account);
        Console.WriteLine("Account created successfully!");
        Console.WriteLine("Account Details:");
        account.PrintAccountDetails();
    }

    // Method to retrieve the balance of an account
    public float GetAccountBalance(long accountNumber)
    {
        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accountNumber)
                return acc.Balance;
        }
        return -1; // Account not found
    }

    // Method to deposit into an account
    public float Deposit(long accountNumber, float amount)
    {
        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accountNumber)
            {
                acc.Balance += amount;
                return acc.Balance;
            }
        }
        return -1; // Account not found
    }

    // Method to withdraw from an account
    public float Withdraw(long accountNumber, float amount)
    {
        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accountNumber)
            {
                if (acc.Balance >= amount)
                {
                    acc.Balance -= amount;
                    return acc.Balance;
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                    return acc.Balance;
                }
            }
        }
        return -1; // Account not found
    }

    // Method to transfer between accounts
    public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
    {
        float fromBalance = Withdraw(fromAccountNumber, amount);
        if (fromBalance != -1)
        {
            Deposit(toAccountNumber, amount);
            Console.WriteLine($"Transfer of {amount} successful from Account {fromAccountNumber} to Account {toAccountNumber}.");
        }
        else
        {
            Console.WriteLine("Transfer failed. Invalid account number or insufficient balance.");
        }
    }

    // Method to get account and customer details
    public void GetAccountDetails(long accountNumber)
    {
        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accountNumber)
            {
                Console.WriteLine("Account Details:");
                acc.PrintAccountDetails();
                return;
            }
        }
        Console.WriteLine("Account not found.");
    }
}

// BankApp class
class BankApp
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Get Account Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Transfer");
            Console.WriteLine("6. Get Account Details");
            Console.WriteLine("7. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter customer details:");
                    Console.WriteLine("Customer ID:");
                    int custId = int.Parse(Console.ReadLine());
                    Console.WriteLine("First Name:");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Last Name:");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Email Address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Phone Number:");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Address:");
                    string address = Console.ReadLine();
                    Customer customer = new Customer(custId, fName, lName, email, phone, address);
                    Console.WriteLine("Enter account type:");
                    string accType = Console.ReadLine();
                    Console.WriteLine("Enter initial balance:");
                    float balance = float.Parse(Console.ReadLine());
                    bank.CreateAccount(customer, accType, balance);
                    break;
                case 2:
                    Console.WriteLine("Enter account number:");
                    long accNumber = long.Parse(Console.ReadLine());
                    float accBalance = bank.GetAccountBalance(accNumber);
                    if (accBalance != -1)
                    {
                        Console.WriteLine($"Account Balance: {accBalance}");
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter account number:");
                    long depositAccNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter amount to deposit:");
                    float depositAmount = float.Parse(Console.ReadLine());
                    float newBalance = bank.Deposit(depositAccNumber, depositAmount);
                    if (newBalance != -1)
                    {
                        Console.WriteLine($"New balance: {newBalance}");
                    }
                    else
                    {
                        Console.WriteLine("Deposit failed. Account not found.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter account number:");
                    long withdrawAccNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter amount to withdraw:");
                    float withdrawAmount = float.Parse(Console.ReadLine());
                    float afterWithdrawBalance = bank.Withdraw(withdrawAccNumber, withdrawAmount);
                    if (afterWithdrawBalance != -1)
                    {
                        Console.WriteLine($"New balance: {afterWithdrawBalance}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter source account number:");
                    long fromAccNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter destination account number:");
                    long toAccNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter amount to transfer:");
                    float transferAmount = float.Parse(Console.ReadLine());
                    bank.Transfer(fromAccNumber, toAccNumber, transferAmount);
                    break;
                case 6:
                    Console.WriteLine("Enter account number:");
                    long accDetailsNumber = long.Parse(Console.ReadLine());
                    bank.GetAccountDetails(accDetailsNumber);
                    break;
                case 7:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

