﻿using newton.domain.models.bankaccount.interfaces;
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
    public class AzureSqlDataStorage : ICustomerRepository, IInsuranceRepository, IBankAccountRepository
    {
        private readonly azure.azurebankdatabaseDataContext datacontext;

        public AzureSqlDataStorage()
        {
            datacontext = new azure.azurebankdatabaseDataContext("Data Source=newtonsqlserver.database.windows.net;Initial Catalog=bankdatabase;User ID=newtondbuser;Password=Gummiboll45;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False");

        }
        public void Create(ICustomer customer)
        {
            var newCustomer = new azure.Customer
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

        void IBankAccountRepository.Delete(int accountId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IBankAccount> IBankAccountRepository.GetAllBankAccounts()
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

        IBankAccount IBankAccountRepository.Update(IBankAccount account)
        {
            throw new NotImplementedException();
        }
    }
}