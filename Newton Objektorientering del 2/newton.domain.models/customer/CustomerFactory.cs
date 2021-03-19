using newton.domain.models.customer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.customer
{
    public static class CustomerFactory
    {
        public static ICustomer CreateCustomer(string firstName, string lastName, string socialSecurityNumber, float yearlySalary) {
            switch (yearlySalary)
            {
                case float n when (n >= 100000):
                    return new HighPrioratizedPrivateCustomer(firstName, lastName, socialSecurityNumber, yearlySalary);
                default:
                    return new PrivateCustomer(firstName, lastName, socialSecurityNumber, yearlySalary);
            }
        }
    }
}
