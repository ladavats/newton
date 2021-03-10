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
}