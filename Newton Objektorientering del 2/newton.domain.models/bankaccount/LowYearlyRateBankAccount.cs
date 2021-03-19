using newton.domain.models.bankaccount.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount
{
    public class LowYearlyRateBankAccount : IBankAccount
    {
        private const float YearlyInterestRate = 1.006f;
        private int accountId { get; set; }
        private float balance { get; set; }
        public int AccountId => accountId;
        public float Balance => balance;

        public LowYearlyRateBankAccount(int accountId, float balance)
        {
            this.accountId = accountId;
            this.balance = balance;
        }

        public void CalculateYearlyInterestRate()
        {

            this.balance += balance * YearlyInterestRate;
        }
    }
}
