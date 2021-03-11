using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models.dto
{
    public abstract class CustomerRequest
    {
        public int CustomerId { get; set; }
        public int Amount { get; set; }
    }


    public interface ICustomerRequest
    {
        int CustomerId { get; set; }
        int Amount { get; set; }
    }


    public class CustomerWithdraw : CustomerRequest, ICustomerRequest
    {
        
    }

    public class CustomerDeposit : CustomerRequest, ICustomerRequest
    {
        
    }
}