using System;

// Custom exception for insufficient funds
class InsufficientFundException : Exception
{
    public InsufficientFundException(string message) : base(message)
    {
    }
}

// Custom exception for invalid account
class InvalidAccountException : Exception
{
    public InvalidAccountException(string message) : base(message)
    {
    }
}

// Custom exception for overdraft limit exceeded
class OverDraftLimitExceededException : Exception
{
    public OverDraftLimitExceededException(string message) : base(message)
    {
    }
}

// Customer class
class Customer
{
    // Attributes and methods as before
}

// Account class
class Account
{
    // Attributes and methods as before
}

// Interface and classes for service providers as before

// BankApp class
class BankApp
{
    static void Main(string[] args)
    {
        try
        {
            // Implementation of banking operations
            throw new NotImplementedException();
        }
        catch (InsufficientFundException ex)
        {
            Console.WriteLine($"Insufficient funds: {ex.Message}");
        }
        catch (InvalidAccountException ex)
        {
            Console.WriteLine($"Invalid account: {ex.Message}");
        }
        catch (OverDraftLimitExceededException ex)
        {
            Console.WriteLine($"Overdraft limit exceeded: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
