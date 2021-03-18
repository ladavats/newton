using newton.repository.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.repository.interfaces
{
    //Vi börjar med detta repository som en hård referens.
    //Sedan kan vi göra detta till ett annat webAPI.
    //Men i nuläget så drar vi in referenserna.
    public interface IRepositoryService
    {
        void CreateCustomer(CreateCustomerDTO customer);
        void CreateBankAccount(CreateBankAccountDTO bankaccount);
        CustomerDTO GetCustomer(int customerId);
        BankAccountDTO GetBankAccount(int bankAccountId);
    }
}
