namespace StartUp
{
    using System;
    using P01_1BillsPaymentSystem.Data;
    using P01_1BillsPaymentSystem.Data.Models;
    using System.Globalization;
    using P01_1BillsPaymentSystem.Data.Enum;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (BillsPaymantSystemContext context = new BillsPaymantSystemContext())
            {
                Console.WriteLine("Choose command: seed, userDetails, payBills, exit ");
                bool isFinished = true;

                while (isFinished)
                {
                    Console.Write("Enter command: ");
                    var command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "seed":
                            Seed(context);
                            break;
                        case "userdetails":
                            UserDetails(context);
                            break;
                        case "paybills":
                            PayBills(context);
                            break;
                        case "exit":
                            isFinished = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Command! Try again!");
                            break;
                    }

                    Console.Write("Do you wanna quit? Press y/n: ");
                    var quitCommand = Console.ReadLine();
                    if (quitCommand == "y")
                    {
                        break;
                    }
                    else
                    {
                        if (quitCommand == "n")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Don't be too smart motherfucker!");
                        }
                    }
                }
            }
        }

        private static void PayBills(BillsPaymantSystemContext context)
        {
            Console.Write("Enter userId: ");
            var userId = int.Parse(Console.ReadLine());
            Console.Write("Enter amount for bill pays: ");
            var amount = decimal.Parse(Console.ReadLine());

            try
            {
                var findUser = context.Users.Find(userId);

                if (findUser == null)
                {
                    Console.WriteLine($"User with id {userId} not found!");
                    return;
                }

                decimal allАvailableMoneyOfUser = 0m;

                var bankAccounts = context
                .BankAccounts.Join(context.PaymentMethods,
                    (ba => ba.BankAccountId),
                    (p => p.BankAccountId),
                    (ba, p) => new
                    {
                        UserId = p.UserId,
                        BankAccountId = ba.BankAccountId,
                        Balance = ba.Balance
                    })
                .Where(ba => ba.UserId == userId)
                .ToList();


                var creditCards = context
                    .CreditCards.Join(context.PaymentMethods,
                        (c => c.CreditCardId),
                        (p => p.CreditCardId),
                        (c, p) => new
                        {
                            UserId = p.UserId,
                            CreditCardId = c.CreditCardId,
                            LimitLeft = c.LimitLeft
                        })
                    .Where(c => c.UserId == userId)
                    .ToList();

                allАvailableMoneyOfUser += bankAccounts.Sum(b => b.Balance);
                allАvailableMoneyOfUser += creditCards.Sum(c => c.LimitLeft);

                if (allАvailableMoneyOfUser < amount)
                {
                    throw new InvalidOperationException("Insufficient funds!");
                }

                bool isPayBills = false;

                foreach (var bankAccount in bankAccounts.OrderBy(b => b.BankAccountId))
                {
                    var currentAccount = context.BankAccounts.Find(bankAccount.BankAccountId);

                    if (amount <= currentAccount.Balance)
                    {
                        currentAccount.Withdraw(amount);
                        isPayBills = true;
                    }
                    else
                    {
                        amount -= currentAccount.Balance;
                        currentAccount.Withdraw(currentAccount.Balance);
                    }

                    if (isPayBills)
                    {
                        context.SaveChanges();
                        Console.WriteLine("Bills have been successfully paid.");
                        return;
                    }
                }

                foreach (var creditCard in creditCards.OrderBy(c => c.CreditCardId))
                {
                    var currentCreditCard = context.CreditCards.Find(creditCard.CreditCardId);

                    if (amount <= currentCreditCard.LimitLeft)
                    {
                        currentCreditCard.Withdraw(amount);
                        isPayBills = true;
                    }
                    else
                    {
                        amount -= currentCreditCard.LimitLeft;
                        currentCreditCard.Withdraw(currentCreditCard.LimitLeft);
                    }

                    if (isPayBills)
                    {
                        context.SaveChanges();
                        Console.WriteLine("Bills have been successfully paid.");
                        return;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UserDetails(BillsPaymantSystemContext context)
        {
            int userId = 1;
            var user = context.Users
                 .Where(u => u.UserId == userId)
                 .Select(p => new
                 {
                     Name = $"{p.FirstName} {p.LastName}",

                     BankAccounts = p.PaymentMethods
                     .Where(t => t.Type == PaymentMethodType.BankAccount)
                     .Select(b => b.BankAccount),

                     CreditCards = p.PaymentMethods
                     .Where(t => t.Type == PaymentMethodType.CreditCard)
                     .Select(b => b.CreditCard),
                 }).ToArray();

            if (user.Count() == 0)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            foreach (var u in user)
            {
                Console.WriteLine($"User: {u.Name}");
                if (u.BankAccounts != null)
                {
                    Console.WriteLine($"Bank Accounts:");
                    foreach (var bank in u.BankAccounts)
                    {
                        Console.WriteLine($"-- ID: {bank.BankAccountId}");
                        Console.WriteLine($"--- Balance: {bank.Balance:F2}");
                        Console.WriteLine($"--- Bank: {bank.BankName}");
                        Console.WriteLine($"--- SWIFT: {bank.SWIFTCode}");
                    }
                }

                if (u.CreditCards != null)
                {
                    Console.WriteLine($"Credit Cards:");
                    foreach (var c in u.CreditCards)
                    {
                        Console.WriteLine($"-- ID: {c.CreditCardId}");
                        Console.WriteLine($"--- Limit: {c.Limit:F2}");
                        Console.WriteLine($"--- Money Owed: {c.MoneyOwed:F2}");
                        Console.WriteLine($"--- Limit Left: {c.LimitLeft}");
                        Console.WriteLine($"--- Expiration Date: {c.ExpirationDate:yyyy/MM}");
                    }
                }
            }
        }

        private static void Seed(BillsPaymantSystemContext context)
        {
            if (context.Users.Any())
            {
                Console.WriteLine("Database already was created!");
                return;
            }

            var user = new User()
            {
                FirstName = "Kamen",
                LastName = "Donev",
                Email = "kamendonev@abv.bg",
                Password = "112345",
            };

            var creditCard = new CreditCard[]
            {
                new CreditCard()
                {
                     ExpirationDate = DateTime.ParseExact("20.01.2022", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                      //Limit = 1000M,
                      //MoneyOwed = 100M,
                },



                new CreditCard()
                {
                     ExpirationDate = DateTime.ParseExact("23.10.2022", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                      //Limit = 2000M,
                      //MoneyOwed = 200M,
                },

                new CreditCard()
                {
                     ExpirationDate = DateTime.ParseExact("01.01.2018", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                      //Limit = 30000M,
                      //MoneyOwed = 300M,
                }
            };

            creditCard[0].Deposit(1000);
            creditCard[0].Withdraw(100);

            creditCard[1].Deposit(2000);
            creditCard[1].Withdraw(200);

            creditCard[2].Deposit(3000);
            creditCard[2].Withdraw(300);

            var bankAccount = new BankAccount()
            {
                BankName = "KaT_Ebe",
                SWIFTCode = "SusMa",
            };

            bankAccount.Deposit(3000);

            var paymantMethods = new PaymentMethod[]
            {
                new PaymentMethod()
                {
                    User = user,
                    CreditCard = creditCard[0],
                    Type = PaymentMethodType.CreditCard
                },

                new PaymentMethod()
                {
                    User = user,
                    CreditCard = creditCard[1],
                    Type = PaymentMethodType.CreditCard
                },

                new PaymentMethod()
                {
                    User = user,
                    CreditCard = creditCard[2],
                    Type = PaymentMethodType.CreditCard
                },

                  new PaymentMethod()
                {
                    User = user,
                    BankAccount = bankAccount,
                    Type = PaymentMethodType.BankAccount
                }
            };

            context.Users.Add(user);
            context.CreditCards.AddRange(creditCard);
            context.BankAccounts.Add(bankAccount);
            context.PaymentMethods.AddRange(paymantMethods);

            context.SaveChanges();
        }
    }
}
