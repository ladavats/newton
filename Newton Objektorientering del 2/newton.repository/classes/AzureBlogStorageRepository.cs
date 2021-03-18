using newton.repository.dto;
using newton.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.repository.classes
{
    class AzureBlobStorageRepository : IRepository
    {
        public void CreateBankAccount(CreateBankAccountDTO bankaccount)
        {
            throw new NotImplementedException();
        }

        public void CreateCustomer(CreateCustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        public BankAccountDTO GetBankAccount(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
