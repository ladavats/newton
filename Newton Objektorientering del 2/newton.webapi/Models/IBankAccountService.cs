using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.webapi.Models
{
    public interface IBankAccountService
    {
        void Withdraw(int customerId, int amount);
        void Deposit(int customerId, int amount);
    }
}
