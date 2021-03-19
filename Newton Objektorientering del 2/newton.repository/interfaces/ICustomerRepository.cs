using newton.domain.models.customer.interfaces;
using System.Collections.Generic;

namespace newton.repository.interfaces
{
    public interface ICustomerRepository
    {
        void Create(ICustomer customer);
        ICustomer GetById(int customerId);
        IEnumerable<ICustomer> GetAllCustomers();
        ICustomer Update(ICustomer customer);
        void Delete(int customerId);
    }
}
