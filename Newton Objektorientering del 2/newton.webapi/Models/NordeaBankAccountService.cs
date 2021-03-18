using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models
{
    public class NordeaBankAccountService : IBankAccountService
    {
        public void Deposit(int customerId, int amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int customerId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}