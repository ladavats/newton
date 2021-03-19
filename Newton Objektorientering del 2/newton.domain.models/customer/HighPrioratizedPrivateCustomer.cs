using newton.domain.models.customer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.customer
{
    public class HighPrioratizedPrivateCustomer : ICustomer
    {
        private int customerId { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string socialSecurityNumber { get; set; }
        private int balance { get; set; }
        private string info { get; set; }
        private float yearlySalary { get; set; }

        public int CustomerId => customerId;
        public string FirstName => firstName;
        public string LastName => lastName;
        public string SocialSecurityNumber => socialSecurityNumber;
        public int Balance => balance;
        public string Info => info;
        public float YearlySalary => yearlySalary;

        public HighPrioratizedPrivateCustomer(string firstName, string lastName, string socialSecurityNumber, float yearlySalary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.yearlySalary = yearlySalary;
        }

        public HighPrioratizedPrivateCustomer(int customerId, string firstName, string lastName, string socialSecurityNumber, string info, float yearlySalary)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.info = info;
            this.yearlySalary = yearlySalary;
        }
    }
}
