using System;
using System.Collections.Generic;
using csharp_ConsAppBankSystem;

namespace csharp_ConsAppBankSystem
{
	public class LoginPage_BankSystem
	{
        private User currentUser;
        private HomePage_BankSystem homePage_BankSystem;
        private List<User> users;
        private List<string> transactionHistory = new List<string>();


        public LoginPage_BankSystem(User user, HomePage_BankSystem homeP_system)
        {
            currentUser = user;
            homePage_BankSystem = homeP_system;
        }

        public void ShowUserProfile()
        {
            Console.WriteLine("User Profile:");
            Console.WriteLine($"Username: {currentUser.UserName}");
            Console.WriteLine($"Email: {currentUser.Email}");
            Console.WriteLine("Accounts:");

            foreach (var account in currentUser.Accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Currency: {account.Currency}");
                Console.WriteLine($"Balance: {account.Balance}");
            }
        }

        public void AddAccount()
        {
            Console.Write("Enter the currency of the new account: ");
            string currency = Console.ReadLine();
            Console.Write("Enter the initial balance: ");
            if (double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                homePage_BankSystem.AddAccount(currentUser, GenerateAccountNumber(), currency, initialBalance);
                Console.WriteLine("New account added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input for initial balance.");
            }
        }

        public void PerformTransaction(string transactionType, double amount, BankAccount sourceAccount, BankAccount targetAccount = null)
        {
            switch (transactionType.ToLower())
            {
                case "withdraw":
                    if (sourceAccount.Balance >= amount)
                    {
                        sourceAccount.Balance -= amount;
                        transactionHistory.Add($"Withdraw: {amount} {sourceAccount.Currency}");
                        Console.WriteLine("Withdrawal successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance for withdrawal.");
                    }
                    break;
                case "deposit":
                    sourceAccount.Balance += amount;
                    transactionHistory.Add($"Deposit: {amount} {sourceAccount.Currency}");
                    Console.WriteLine("Deposit successful.");
                    break;
                case "transfer":
                    if (sourceAccount.Balance >= amount)
                    {
                        sourceAccount.Balance -= amount;
                        targetAccount.Balance += amount;
                        transactionHistory.Add($"Transfer: {amount} {sourceAccount.Currency} from Account {sourceAccount.AccountNumber} to Account {targetAccount.AccountNumber}");
                        Console.WriteLine("Transfer successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance for transfer.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid transaction type.");
                    break;
            }
        }


        public void ShowTransactionHistory(int numberOfTransactionsToShow)
        {
            int startIndex = Math.Max(0, transactionHistory.Count - numberOfTransactionsToShow);

            for (int i = startIndex; i < transactionHistory.Count; i++)
            {
                Console.WriteLine(transactionHistory[i]);
            }
        }


        public void DeleteAccount(string email, string password)
        {
            User userToDelete = users.Find(u => u.Email == email && u.Password == password);

            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found or invalid credentials.");
            }
        }


        // Generate a unique account number
        private int GenerateAccountNumber()
        {
            // Implement a logic to generate a unique account number
            // For simplicity, you can use a random number generator here.
            Random rand = new Random();
            return rand.Next(100000, 999999);
        }
    }
}