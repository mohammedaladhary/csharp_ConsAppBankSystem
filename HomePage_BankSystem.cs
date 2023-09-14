using System;
using System.Collections.Generic;

namespace csharp_ConsAppBankSystem
{
    public class HomePage_BankSystem
    {
        private List<User> users = new List<User>();
        private List<string> transactionHistory = new List<string>();

        // Register a new user
        public void RegisterUser(string userName, string email, string password)
        {
            users.Add(new User(userName, email, password));
            //Console.WriteLine("\nUser registered successfully.");
        }

        // Login a user
        public User Login(string email, string password)
        {
            User user = users.Find(u => u.Email == email && u.Password == password);
            //if (user != null)
            //{
            //    Console.WriteLine("Login successful.");
            //}
            //else
            //{
            //    Console.WriteLine("Login failed. Please check your credentials.");
            //}
            return user;
        }

        // View current exchange rates
        public void ViewExchangeRates()
        {
            // Implement code to fetch and display exchange rates here
        }

        // Currency converter
        public double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            // Implement currency conversion logic here
            // You can use external APIs or predefined exchange rates
            return 0.0; // Placeholder, replace with actual conversion logic
        }

        // New Account
        public void AddAccount(User user, int accountNumber, string currency, double initialBalance)
        {
            user.Accounts.Add(new BankAccount(accountNumber, currency, initialBalance));
            Console.WriteLine("New account added successfully.");
        }

        public HomePage_BankSystem()
        {
        }
    }
}
