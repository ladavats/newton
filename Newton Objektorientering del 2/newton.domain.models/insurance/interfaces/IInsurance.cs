using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.domain.models.insurance.interfaces
{
    public interface IInsurance
    {
        int InsuranceId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
