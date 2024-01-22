using Microsoft.AspNetCore.Mvc;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAppliedController : ControllerBase
    {
        private readonly IJobAppliedServices _jobAppliedServices;

        public JobAppliedController(IJobAppliedServices jobAppliedServices)
        {
            try
            {
                _jobAppliedServices = jobAppliedServices;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<JobAppliedDTO> Get()
        {
            try
            {
                return _jobAppliedServices.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public JobAppliedDTO Get(int id)
        {
            try
            {
                return _jobAppliedServices.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Post(JobAppliedDTO value)
        {
            try
            {
                _jobAppliedServices.Insert(value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
