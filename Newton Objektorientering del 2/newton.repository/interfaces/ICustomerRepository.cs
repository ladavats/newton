using newton.domain.models.customer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
