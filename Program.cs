using System;
using System.Collections.Generic;

namespace csharp_ConsAppBankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of HomePage_BankSystem
            HomePage_BankSystem homePage = new HomePage_BankSystem();
            User loggedInUser = null;

            while (true)
            {
                Console.Clear(); // Clear the console screen

                Console.WriteLine("\nBank System Menu:");
                Console.WriteLine("\n1. Register new user");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("\nEnter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear(); // Clear the console screen

                        // Register a new user
                        Console.Write("\nEnter username: ");
                        string userName = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        homePage.RegisterUser(userName, email, password);
                        Console.WriteLine("\nUser registered successfully. Press any key to get back to the main menu.");
                        Console.ReadKey(); // Wait for user input before clearing
                        break;
                    case 2:
                        Console.Clear(); // Clear the console screen

                        // Login
                        Console.Write("\nEnter email: ");
                        string loginEmail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string loginPassword = Console.ReadLine();
                        loggedInUser = homePage.Login(loginEmail, loginPassword);

                        if (loggedInUser != null)
                        {
                            Console.WriteLine("\nLogin successful.");
                            LoginPage_BankSystem loginPage = new LoginPage_BankSystem(loggedInUser, homePage);
                            bool loggedIn = true;

                            while (loggedIn)
                            {
                                Console.WriteLine("\nUser Menu:");
                                Console.WriteLine("1. Show user profile");
                                Console.WriteLine("2. Add account");
                                Console.WriteLine("3. Perform transaction");
                                Console.WriteLine("4. Show transaction history");
                                Console.WriteLine("5. Delete account");
                                Console.WriteLine("6. Logout");

                                Console.Write("\nEnter your choice: ");
                                int userChoice;
                                if (!int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    Console.WriteLine("\nInvalid input. Please enter a valid choice.");
                                    continue;
                                }

                                switch (userChoice)
                                {
                                    case 1:
                                        loginPage.ShowUserProfile();
                                        break;

                                    case 2:
                                        loginPage.AddAccount();
                                        break;

                                    case 3:
                                        // Implement transaction logic with user input
                                        Console.Write("\nEnter transaction type (withdraw, deposit, transfer): ");
                                        string transactionType = Console.ReadLine();
                                        Console.Write("Enter amount: ");
                                        if (double.TryParse(Console.ReadLine(), out double amount))
                                        {
                                            // You also need to specify source and target accounts for transfer
                                            // For simplicity, let's assume the user is performing a withdrawal or deposit here
                                            if (transactionType.ToLower() == "withdraw" || transactionType.ToLower() == "deposit")
                                            {
                                                loginPage.PerformTransaction(transactionType, amount, loggedInUser.Accounts[0]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid transaction type for this option.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input for amount.");
                                        }
                                        break;

                                    case 4:
                                        Console.Write("\nEnter the number of transactions to display: ");
                                        if (int.TryParse(Console.ReadLine(), out int numberOfTransactions))
                                        {
                                            loginPage.ShowTransactionHistory(numberOfTransactions);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input for the number of transactions.");
                                        }
                                        break;

                                    case 5:
                                        // Implement account deletion logic with user input
                                        Console.Write("Enter your email: ");
                                        string deleteEmail = Console.ReadLine();
                                        Console.Write("Enter your password: ");
                                        string deletePassword = Console.ReadLine();
                                        loginPage.DeleteAccount(deleteEmail, deletePassword);
                                        break;

                                    case 6:
                                        loggedIn = false;
                                        loggedInUser = null;
                                        Console.WriteLine("Logged out.");
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear(); // Clear the console screen
                            Console.WriteLine("Login failed. Please check your credentials.");
                            Console.ReadKey(); // Wait for user input before clearing
                        }
                        break;
                    case 3:
                        Console.Clear(); // Clear the console screen
                        Console.WriteLine("Exiting the Bank System.");
                        return;
                    default:
                        Console.Clear(); // Clear the console screen
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.ReadKey(); // Wait for user input before clearing
                        break;
                }
            }
        }
    }
}
