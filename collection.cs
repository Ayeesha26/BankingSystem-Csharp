using System;
using System.Collections.Generic;
using System.Linq;

// Customer class
class Customer
{
}

// Account class
class Account
{
}

// Interface and classes for service providers as before

// HMBank class
class HMBank
{
    // Using List of Accounts
    private List<Account> accountsList;

    // Constructor
    public HMBank()
    {
        accountsList = new List<Account>();
    }

}

// BankApp class
class BankApp
{
    static void Main(string[] args)
    {
        // Implementation using List
        try
        {
            HMBank bank = new HMBank();

            // Operations using List
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Implementation using HashSet
        try
        {
            HMBank bank = new HMBank();

            // Operations using HashSet
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Implementation using Dictionary
        try
        {
            HMBank bank = new HMBank();

            // Operations using Dictionary
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
