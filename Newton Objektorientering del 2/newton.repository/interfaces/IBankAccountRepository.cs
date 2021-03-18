using newton.domain.models.bankaccount.interfaces;
using System.Collections.Generic;

namespace newton.repository.interfaces
{
    public interface IBankAccountRepository
    {
        IBankAccount GetById(int accountId);
        IEnumerable<IBankAccount> GetAllBankAccounts();
        IBankAccount Update(IBankAccount account);
        void Delete(int accountId);
    }
}
