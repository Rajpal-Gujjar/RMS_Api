using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;            
        }

        [HttpGet]
        public AdminDTO Get(string userName, string password)
        {
            return _adminServices.GetAdmin(userName, password);
        }
    }
}
