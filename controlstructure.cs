using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    // Task 1: Conditional Statements
    static void Task1()
    {
        Console.WriteLine("Task 1: Loan Eligibility Check");
        Console.Write("Enter your credit score: ");
        int creditScore = int.Parse(Console.ReadLine());
        Console.Write("Enter your annual income: ");
        double annualIncome = double.Parse(Console.ReadLine());

        if (creditScore > 700 && annualIncome >= 50000)
        {
            Console.WriteLine("Congratulations! You are eligible for a loan.");
        }
        else
        {
            Console.WriteLine("Sorry, you are not eligible for a loan.");
        }
    }

    // Task 2: Nested Conditional Statements
    static void Task2()
    {
        Console.WriteLine("\nTask 2: ATM Transaction Simulation");
        Console.WriteLine("Options: 1. Check Balance  2. Withdraw  3. Deposit");
        Console.Write("Enter your current balance: ");
        double balance = double.Parse(Console.ReadLine());
        Console.Write("Enter the transaction type (1, 2, or 3): ");
        int transactionType = int.Parse(Console.ReadLine());

        switch (transactionType)
        {
            case 1:
                Console.WriteLine($"Your current balance is: {balance}");
                break;
            case 2:
                Console.Write("Enter the amount to withdraw: ");
                double withdrawAmount = double.Parse(Console.ReadLine());
                if (withdrawAmount > balance || withdrawAmount % 100 != 0)
                {
                    Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                }
                else
                {
                    balance -= withdrawAmount;
                    Console.WriteLine($"Withdrawal successful. Remaining balance: {balance}");
                }
                break;
            case 3:
                Console.Write("Enter the amount to deposit: ");
                double depositAmount = double.Parse(Console.ReadLine());
                balance += depositAmount;
                Console.WriteLine($"Deposit successful. Updated balance: {balance}");
                break;
            default:
                Console.WriteLine("Invalid transaction type.");
                break;
        }
    }

    // Task 3: Loop Structures
    static void Task3()
    {
        Console.WriteLine("\nTask 3: Compound Interest Calculation");
        Console.Write("Enter the number of customers: ");
        int numCustomers = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numCustomers; i++)
        {
            Console.WriteLine($"\nCustomer {i}:");
            Console.Write("Enter initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter annual interest rate (%): ");
            double annualInterestRate = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of years: ");
            int years = int.Parse(Console.ReadLine());

            double futureBalance = initialBalance * Math.Pow(1 + annualInterestRate / 100, years);
            Console.WriteLine($"Future balance after {years} years: {futureBalance}");
        }
    }

    // Task 4: Looping, Array and Data Validation
    static void Task4()
    {
        Console.WriteLine("\nTask 4: Bank Account Balance Check");
        Dictionary<int, double> accounts = new Dictionary<int, double>()
        {
            {123456, 1000},
            {234567, 5000},
            {345678, 200}
        };

        int accountNumber;
        bool validAccount = false;

        do
        {
            Console.Write("Enter your account number: ");
            accountNumber = int.Parse(Console.ReadLine());

            if (accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine($"Your account balance is: {accounts[accountNumber]}");
                validAccount = true;
            }
            else
            {
                Console.WriteLine("Invalid account number. Please try again.");
            }
        } while (!validAccount);
    }

    // Task 5: Password Validation
    static void Task5()
    {
        Console.WriteLine("\nTask 5: Password Validation");
        Console.Write("Create your password: ");
        string password = Console.ReadLine();

        bool validPassword = false;

        if (password.Length >= 8)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    validPassword = true;
                    break;
                }
            }
        }

        if (validPassword)
        {
            Console.WriteLine("Password is valid.");
        }
        else
        {
            Console.WriteLine("Password is invalid. Password must be at least 8 characters long and contain at least one digit.");
        }
    }

    // Task 6: Password Validation
    static void Task6()
    {
        Console.WriteLine("\nTask 6: Bank Transaction History");
        List<string> transactions = new List<string>();

        string transaction;
        bool exit = false;

        while (!exit)
        {
            Console.Write("Enter a transaction (or 'exit' to quit): ");
            transaction = Console.ReadLine();

            if (transaction.ToLower() == "exit")
            {
                exit = true;
            }
            else
            {
                transactions.Add(transaction);
            }
        }

        Console.WriteLine("\nTransaction History:");
        foreach (string t in transactions)
        {
            Console.WriteLine(t);
        }
    }
}
