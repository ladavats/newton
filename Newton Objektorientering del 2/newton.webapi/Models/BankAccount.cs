using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models
{
    public class BankAccount : IBankAccount
    {
        private int customerId { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string socialSecurityNumber { get; set; }
        private int balance { get; set; }

        public int CustomerId => customerId;
        public string FirstName => firstName;
        public string LastName => lastName;
        public string SocialSecurityNumber => socialSecurityNumber;
        public int Balance => balance;

        public BankAccount(int customerId, string firstName, string lastName, string socialSecurityNumber)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.balance = 0;
        }

        public void Withdraw(int amount)
        {
            this.balance -= amount;
        }

        public void Deposit(int amount)
        {
            this.balance += amount;
        }
    }
}