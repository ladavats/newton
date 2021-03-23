using newton.domain.models.bankaccount.interfaces;
using newton.domain.models.customer;
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
        public void Create(ICustomer customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                SocialSecurityNumber = customer.SocialSecurityNumber,
                Info = "Customer is also a programmer",
                YearlySalary = customer.YearlySalary
            };

            datacontext.Customers.InsertOnSubmit(newCustomer);
            datacontext.SubmitChanges();
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
            var customers = new List<ICustomer>();
            foreach (var entity in datacontext.Customers.ToList())
            {
                ICustomer customer = CustomerFactory.CreateCustomer(entity.FirstName, 
                                                                    entity.LastName, 
                                                                    entity.SocialSecurityNumber, 
                                                                    ((float)entity.YearlySalary),
                                                                    entity.Info);
                customers.Add(customer);
            }
            return customers;
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
