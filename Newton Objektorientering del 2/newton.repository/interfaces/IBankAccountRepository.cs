using newton.domain.models.bankaccount.interfaces;
using newton.repository.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
