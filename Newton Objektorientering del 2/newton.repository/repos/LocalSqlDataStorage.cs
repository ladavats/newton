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
    public class LocalSqlDataStorage : ICustomerRepository, IInsuranceRepository, IBankAccountRepository
    {
        private readonly newton_bankDataContext datacontext;
        public LocalSqlDataStorage()
        {
            datacontext = new newton_bankDataContext();
        }


        public void Delete(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICustomer> GetAllCustomers()
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

        //public void CreateBankAccount(CreateBankAccountDTO bankaccount)
        //{
        //    var new_bankaccount = new BankAccount
        //    {
        //        Balance = bankaccount.Balance
        //    };

        //    datacontext.BankAccounts.InsertOnSubmit(new_bankaccount);
        //    datacontext.SubmitChanges();
        //}

        //public void CreateCustomer(CreateCustomerDTO customer)
        //{
        //    var new_customer = new Customer
        //    {
        //        FirstName = customer.FirstName,
        //        LastName = customer.LastName,
        //        SocialSecurityNumber = customer.SocialSecurityNumber
        //    };

        //    datacontext.Customers.InsertOnSubmit(new_customer);
        //    datacontext.SubmitChanges();
        //}

        IInsurance IInsuranceRepository.GetById(int insuranceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInsurance> GetAllInsurances()
        {
            throw new NotImplementedException();
        }

        public IInsurance Update(IInsurance insuranceId)
        {
            throw new NotImplementedException();
        }

        IBankAccount IBankAccountRepository.GetById(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBankAccount> GetAllBankAccounts()
        {
            throw new NotImplementedException();
        }

        public IBankAccount Update(IBankAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
