using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.customer.interfaces
{
    public interface ICustomer
    {
        int CustomerId { get; }
        string FirstName { get; }
        string LastName { get; }
        string SocialSecurityNumber { get; }
        string Info { get; }
        float YearlySalary { get; }
    }
}
