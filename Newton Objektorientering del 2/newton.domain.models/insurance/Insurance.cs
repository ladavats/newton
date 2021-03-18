using newton.domain.models.insurance.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.insurance
{
    public class Insurance : IInsurance
    {
        public int InsuranceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
