using newton.domain.models.insurance.interfaces;
using System.Collections.Generic;

namespace newton.repository.interfaces
{
    public interface IInsuranceRepository
    {
        IInsurance GetById(int insuranceId);
        IEnumerable<IInsurance> GetAllInsurances();
        IInsurance Update(IInsurance insuranceId);
        void Delete(int insuranceId);
    }
}
