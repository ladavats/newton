using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.webclient.Models
{
    public interface IApiEndpoints
    {
        string GetCustomers { get; }
        string CreateCustomer { get; }
    }
}
