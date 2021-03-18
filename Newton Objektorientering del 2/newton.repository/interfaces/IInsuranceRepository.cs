using newton.repository.dto;

namespace newton.repository.interfaces
{
    public interface IInsuranceRepository
    {
        void Create(CreateInsuranceDTO insurance);
        GetInsuranceDTO Get(int insuranceId);
    }
}
