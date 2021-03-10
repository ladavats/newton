using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models
{
    public class NordeaBankAccountService : IBankAccountService
    {
        private readonly IList<IBankAccount> bankaccounts = new List<IBankAccount>();
        private int newCustomerId => bankaccounts.Count + 1;
        public NordeaBankAccountService()
        {
            bankaccounts.Add(new BankAccount(newCustomerId, "Peter", "Ladavats", "811225"));
            bankaccounts.Add(new BankAccount(newCustomerId, "Peter", "Ladavats", "811225"));
            bankaccounts.Add(new BankAccount(newCustomerId, "Peter", "Ladavats", "811225"));
            bankaccounts.Add(new BankAccount(newCustomerId, "Peter", "Ladavats", "811225"));
        }
        public IBankAccount CreateBankAccount(string firstName, string lastName, string socialSecurityNumber)
        {
            var newbankaccount = new BankAccount(newCustomerId, firstName, lastName, socialSecurityNumber);
            bankaccounts.Add(newbankaccount);
            return newbankaccount;
        }

        public void Deposit(int customerId, int amount)
        {
            var selectedBankAccount = bankaccounts.Where(o => o.CustomerId == customerId).Single();
            selectedBankAccount.Deposit(amount);
        }

        public IList<IBankAccount> GetAllBankAccounts()
        {
            return bankaccounts;
        }

        public IBankAccount GetBankAccount(int customerId)
        {
            return bankaccounts.Where(o => o.CustomerId == customerId).Single();
        }

        public void Withdraw(int customerId, int amount)
        {
            var selectedBankAccount = bankaccounts.Where(o => o.CustomerId == customerId).Single();
            selectedBankAccount.Withdraw(amount);
        }
    }
}