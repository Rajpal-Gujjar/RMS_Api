using Microsoft.Extensions.Configuration;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Business.Services
{
    public class AdminServices : IAdminServices
    {
        public IConfiguration _configuration;

        public AdminServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AdminDTO Get()
        {
            return new AdminDTO()
            {
                UserName = _configuration["Admin:UserName"],
                Password = _configuration["Admin:Password"]
            };
        }

        public AdminDTO GetAdmin(string userName, string password)
        {
            if (Get().Password == password && Get().UserName == userName)
            {
                return Get();
            }
            return null;
        }
    }
}
