// Bank account management
// OOPs based mini project

using System;


interface IPrintable
{
    void PrintReceipt();
}

abstract class Account
{
    public int AccountNumber;
    public string HolderName;
    public double Balance;

    public Account(int accNo, string name, double balance)
    {
        AccountNumber = accNo;
        HolderName = name;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than 0.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Deposited ₹{amount}. New balance: ₹{Balance}");
    }

    public abstract void Withdraw(double amount);

    public void DisplayDetails()
    {
        Console.WriteLine($"\nAccount Number: {AccountNumber}");
        Console.WriteLine($"Holder Name: {HolderName}");
        Console.WriteLine($"Balance: ₹{Balance}");
    }
}

class SavingsAccount : Account, IPrintable
{
    private const double MinBalance = 500;

    public SavingsAccount(int accNo, string name, double balance) : base(accNo, name, balance) { }

    public override void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than 0.");
            return;
        }

        if (Balance - amount >= MinBalance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn ₹{amount}. New balance: ₹{Balance}");
        }
        else
        {
            Console.WriteLine($"Withdrawal failed. Minimum balance ₹{MinBalance} must be maintained.");
        }
    }

    public void PrintReceipt()
    {
        Console.WriteLine("\n=== TRANSACTION RECEIPT ===");
        Console.WriteLine($"Account: {AccountNumber} | Name: {HolderName} | Balance: ₹{Balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Bank Account Management System ===");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter initial balance (minimum ₹500): ");
        double balance = double.Parse(Console.ReadLine());

        if (balance < 500)
        {
            Console.WriteLine("Initial balance must be at least ₹500. Exiting...");
            return;
        }

        int accountNumber = 1001;
        SavingsAccount acc = new SavingsAccount(accountNumber, name, balance);

        acc.DisplayDetails();

        Console.Write("\nEnter amount to deposit: ");
        double depositAmount = double.Parse(Console.ReadLine());
        acc.Deposit(depositAmount);

        Console.Write("\nEnter amount to withdraw: ");
        double withdrawAmount = double.Parse(Console.ReadLine());
        acc.Withdraw(withdrawAmount);

        acc.PrintReceipt();
    }
}





