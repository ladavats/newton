using newton.domain.models.customer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.customer
{
    public class Customer : ICustomer
    {
        private int customerId { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string socialSecurityNumber { get; set; }
        private int balance { get; set; }

        private string info { get; set; }

        public int CustomerId => customerId;
        public string FirstName => firstName;
        public string LastName => lastName;
        public string SocialSecurityNumber => socialSecurityNumber;
        public int Balance => balance;

        public string Info => info;

        public Customer(string firstName, string lastName, string socialSecurityNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
        }

        public Customer(int customerId, string firstName, string lastName, string socialSecurityNumber, string info)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.info = info;
        }
    }
}
