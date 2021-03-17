using newton.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webclient.Models
{
    public class CreateBankAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }

        public bool WasSelectedColorRedInDropDown { get; set; }
        public bool DidUserSelectCheckUserAgreementBox { get; set; }

        public CreateBankAccountRequest GetDTO()
        {
            var requestDTO = new CreateBankAccountRequest();
            requestDTO.FirstName = this.FirstName;
            requestDTO.LastName = this.LastName;
            requestDTO.SocialSecurityNumber = this.SocialSecurityNumber;

            return requestDTO;
        }
    }
}