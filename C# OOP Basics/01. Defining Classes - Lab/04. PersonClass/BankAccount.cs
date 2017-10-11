using System;

public class BankAccount
{
    private int id;
    private double balance;

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public double Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public void Deposit(double amount)
    {
        this.balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (this.balance - amount < 0)
        {
            Console.WriteLine($"Insufficient balance");
        }
        else
        {
            this.balance -= amount;
        }
    }

    public override string ToString()
    {
        return $"Account {this.id}, balance {this.balance}";
    }

    public void Print(int id, double balance)
    {
        Console.WriteLine($"Account ID{id}, balance {balance:F2}"); 
    }
}

