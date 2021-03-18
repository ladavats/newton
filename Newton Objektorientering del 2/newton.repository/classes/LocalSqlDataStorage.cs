using newton.repository.dto;
using newton.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.repository.classes
{
    public class LocalSqlDataStorage : IRepositoryService
    {
        private readonly newton_bankDataContext datacontext;
        public LocalSqlDataStorage()
        {
            datacontext = new newton_bankDataContext();
        }

        public void CreateBankAccount(CreateBankAccountDTO bankaccount)
        {
            var new_bankaccount = new BankAccount
            {
                Balance = bankaccount.Balance
            };

            datacontext.BankAccounts.InsertOnSubmit(new_bankaccount);
            datacontext.SubmitChanges();
        }

        public void CreateCustomer(CreateCustomerDTO customer)
        {
            var new_customer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                SocialSecurityNumber = customer.SocialSecurityNumber
            };

            datacontext.Customers.InsertOnSubmit(new_customer);
            datacontext.SubmitChanges();
        }

        BankAccountDTO IRepositoryService.GetBankAccount(int bankAccountId)
        {
            return new BankAccountDTO();
        }

        CustomerDTO IRepositoryService.GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        
    }
}
