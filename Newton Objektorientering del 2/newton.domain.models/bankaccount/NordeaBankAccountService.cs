using newton.domain.models.bankaccount.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount
{
    public class NordeaBankAccountService : IBankAccountService
    {
        public void Deposit(IList<IBankAccount> accounts, int amount)
        {
            foreach (var account in accounts)
                account.Deposit(amount);
        }

        public void Withdraw(IList<IBankAccount> accounts, int amount)
        {
            foreach (var account in accounts)
                account.Withdraw(amount);
        }
    }
}
