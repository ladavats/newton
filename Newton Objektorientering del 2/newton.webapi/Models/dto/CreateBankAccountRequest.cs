﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webapi.Models.dto
{
    public class CreateBankAccountRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}