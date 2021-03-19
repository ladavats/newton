using System;

namespace newton.dto
{
    public class CreateCustomerRequestDto : ICreateBankAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public float YearlySalary { get; set; }
    }

    public interface ICreateBankAccount
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string SocialSecurityNumber { get; set; }
    }
}
