using newton.repository.dto;
using newton.repository.interfaces;
using System;

namespace newton.repository.classes
{
    public class LocalSqlInsuranceStorage : IInsuranceRepository
    {
        private readonly newton_bankDataContext datacontext;
        public LocalSqlInsuranceStorage()
        {
            datacontext = new newton_bankDataContext();
        }
        public void Create(CreateInsuranceDTO insurance)
        {
            var new_insurance = new Insurance
            {
                Name = insurance.Name,
                Description = insurance.Description
            };
            datacontext.Insurances.InsertOnSubmit(new_insurance);
            datacontext.SubmitChanges();
        }

        public GetInsuranceDTO Get(int insuranceId)
        {
            throw new NotImplementedException();
        }
    }
}
