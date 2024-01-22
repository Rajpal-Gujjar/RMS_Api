using RMSApi.Common.DTO;

namespace RMSApi.Business.IServices
{
    public interface ICompanyServices
    {
        CompanyDTO Get(int id);
        IEnumerable<CompanyDTO> GetAll();
    }
}
