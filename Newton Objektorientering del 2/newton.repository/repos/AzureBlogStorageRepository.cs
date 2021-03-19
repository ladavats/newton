using newton.domain.models.bankaccount.interfaces;
using newton.domain.models.customer.interfaces;
using newton.domain.models.insurance.interfaces;
using newton.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.repository.repos
{
    class AzureBlobStorageRepository : ICustomerRepository, IInsuranceRepository, IBankAccountRepository
    {
        public void Create(ICustomer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBankAccount> GetAllBankAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICustomer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInsurance> GetAllInsurances()
        {
            throw new NotImplementedException();
        }

        public ICustomer GetById(int customerId)
        {
            throw new NotImplementedException();
        }

        public ICustomer Update(ICustomer customer)
        {
            throw new NotImplementedException();
        }

        public IInsurance Update(IInsurance insuranceId)
        {
            throw new NotImplementedException();
        }

        public IBankAccount Update(IBankAccount account)
        {
            throw new NotImplementedException();
        }

        IInsurance IInsuranceRepository.GetById(int insuranceId)
        {
            throw new NotImplementedException();
        }

        IBankAccount IBankAccountRepository.GetById(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
