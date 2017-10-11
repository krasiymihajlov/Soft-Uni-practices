using System;
using System.Collections.Generic;

public class StartUpMain
{
    public static void Main()
    {
        Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            int id = int.Parse(tokens[1]);
            int amount;

            switch (command)
            {
                case "Create":
                    if (bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine($"Account already exists");
                    }
                    else
                    {
                        BankAccount bankAccaunt = new BankAccount();
                        bankAccaunt.ID = id;
                        bankAccounts[id] = bankAccaunt;
                    }
                    break;
                case "Deposit":
                    amount = int.Parse(tokens[2]);
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    else
                    {
                        bankAccounts[id].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    amount = int.Parse(tokens[2]);
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    else
                    {
                        bankAccounts[id].Withdraw(amount);
                    }
                    break;
                case "Print":
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    else
                    {
                        bankAccounts[id].Print(bankAccounts[id].ID, bankAccounts[id].Balance);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

