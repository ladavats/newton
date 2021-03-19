using newton.domain.models.customer.interfaces;
using newton.repository.interfaces;
using System;
using System.Collections.Generic;

namespace newton.repository.repos
{
    public class OracleRepository : ICustomerRepository
    {
        public void Create(ICustomer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerId)
        {
            throw new NotImplementedException();
        }

        public IList<ICustomer> GetAllCustomers()
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
    }
}
