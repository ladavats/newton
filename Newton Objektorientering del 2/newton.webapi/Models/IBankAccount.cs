using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.webapi.Models
{
    public interface IBankAccount
    {
        int CustomerId { get; }
        string FirstName { get;  }
        string LastName { get;  }
        string SocialSecurityNumber { get; }
        int Balance { get; }

        void Withdraw(int amount);
        void Deposit(int amount);
    }
}
