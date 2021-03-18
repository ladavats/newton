using newton.domain.models.bankaccount.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount
{
    public class BankAccount : IBankAccount
    {
        private int accountId { get; set; }
        private float balance { get; set; }
        public int AccountId => accountId;
        public float Balance => balance;

        public BankAccount(int accountId, float balance)
        {
            this.accountId = accountId;
            this.balance = balance;
        }
    }
}
