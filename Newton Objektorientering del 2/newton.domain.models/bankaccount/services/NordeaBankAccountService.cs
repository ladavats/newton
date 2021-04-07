using newton.domain.models.bankaccount.interfaces;
using newton.domain.models.customer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount.services
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

        public ICustomer GetNonPrioratizedCustomer(int customerId)
        {
            return new customer.PrivateCustomer("","","",122);
        }
    }
}
