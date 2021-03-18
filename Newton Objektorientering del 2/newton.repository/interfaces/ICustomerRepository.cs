using newton.domain.models.customer.interfaces;
using System.Collections.Generic;

namespace newton.repository.interfaces
{
    public interface ICustomerRepository
    {
        void Create(ICustomer customer);
        ICustomer GetById(int customerId);
        IList<ICustomer> GetAllCustomers();
        ICustomer Update(ICustomer customer);
        void Delete(int customerId);
    }
}
