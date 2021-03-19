using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.bankaccount.interfaces
{
    public interface IBankAccount
    {
        int AccountId { get; }
        float Balance { get; }

        void CalculateYearlyInterestRate();
    }
}
