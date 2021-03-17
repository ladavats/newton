using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models.dto.dataaccess
{
    public class BankAccount 
    {
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
    }
}