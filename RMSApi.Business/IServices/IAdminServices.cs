using RMSApi.Common.DTO;

namespace RMSApi.Business.IServices
{
    public interface IAdminServices
    {
        AdminDTO Get();
        AdminDTO GetAdmin(string userName, string password);
    }
}