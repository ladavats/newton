using System;

namespace newton.dto
{
    public class CreateBankAccountRequest : ICreateBankAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }

    public interface ICreateBankAccount
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string SocialSecurityNumber { get; set; }
    }
}
