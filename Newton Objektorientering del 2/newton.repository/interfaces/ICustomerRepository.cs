using newton.domain.models.customer.interfaces;
using System.Collections.Generic;

namespace newton.repository.interfaces
{
    public interface ICustomerRepository
    {
        ICustomer GetById(int customerId);
        IEnumerable<ICustomer> GetAllCustomers();
        ICustomer Update(ICustomer customer);
        void Delete(int customerId);
    }
}
