using System;
using System.Collections.Generic;
namespace csharp_ConsAppBankSystem
{
	public class User
	{
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
        public List<BankAccount> Accounts { get; } = new List<BankAccount>();

        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}