using newton.domain.models.bankaccount.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount
{
    public class HighYearlyRateBankAccount : IBankAccount
    {
        private const float VeryHighYearlyInterestRate = 1.106f;
        private int accountId { get; set; }
        private float balance { get; set; }
        public int AccountId => accountId;
        public float Balance => balance;

        public HighYearlyRateBankAccount(int accountId, float balance)
        {
            this.accountId = accountId;
            this.balance = balance;
        }

        public void CalculateYearlyInterestRate()
        {

            this.balance += balance * VeryHighYearlyInterestRate;
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
