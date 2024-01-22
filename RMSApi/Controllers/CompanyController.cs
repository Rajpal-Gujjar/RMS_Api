using Microsoft.AspNetCore.Mvc;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        [HttpGet]
        public IEnumerable<CompanyDTO> Get()
        {
            try
            {
                return _companyServices.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public CompanyDTO Get(int id)
        {
            try
            {
                return _companyServices.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
