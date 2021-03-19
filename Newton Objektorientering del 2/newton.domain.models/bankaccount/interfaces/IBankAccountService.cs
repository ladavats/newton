using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount.interfaces
{
    public interface IBankAccountService
    {
        void Withdraw(IList<IBankAccount> accounts, int amount);
        void Deposit(IList<IBankAccount> accounts, int amount);
    }
}
