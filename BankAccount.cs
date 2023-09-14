using System;
namespace csharp_ConsAppBankSystem
{
	public class BankAccount
	{
        public int AccountNumber { get; }
        public string Currency { get; }
        public double Balance { get; set; }

        public BankAccount(int accountNumber, string currency, double initialBalance)
        {
            AccountNumber = accountNumber;
            Currency = currency;
            Balance = initialBalance;
        }
    }
}